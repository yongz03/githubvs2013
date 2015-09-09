using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Abp.EntityFramework;
using Castle.Core.Internal;
using Insurance.Attributes;
using Insurance.Customers;
using Insurance.Rates;

namespace Insurance.EntityFramework
{
    public class InsuranceDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public InsuranceDbContext()
            : base("Default")
        {
            
        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in InsuranceDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of InsuranceDbContext since ABP automatically handles it.
         */
        public InsuranceDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public InsuranceDbContext(DbConnection connection)
            : base(connection, true)
        {
        }

        private const string SchemaName = "TAL";

        public virtual IDbSet<Customer> Customers { get; set; }
        public virtual IDbSet<Insurances.Insurance> Insurances { get; set; }
        public virtual IDbSet<Rate> Rates { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().Property(p => p.Id).HasColumnOrder(1);
            modelBuilder.Entity<Customer>().Property(p => p.DateOfBirth).HasColumnName("DOB");
            modelBuilder.Entity<Insurances.Insurance>().Property(p => p.Id).HasColumnOrder(1);
            modelBuilder.Entity<Rate>().Property(p => p.Id).HasColumnOrder(1);

            HandleDecimalPrecision(modelBuilder);
        }

        private void HandleDecimalPrecision(DbModelBuilder modelBuilder)
        {
            IEnumerable<Type> types = GetDbContextApplicableTypes();

            foreach (Type classType in types)
            {
                foreach (
                    var propAttr in
                        classType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .Where(p => p.GetCustomAttribute<DecimalPrecisionAttribute>() != null)
                            .Select(
                                p => new { prop = p, attr = p.GetCustomAttribute<DecimalPrecisionAttribute>(true) }))
                {
                    object entityConfig =
                        modelBuilder.GetType()
                            .GetMethod("Entity")
                            .MakeGenericMethod(classType)
                            .Invoke(modelBuilder, null);
                    ParameterExpression param = Expression.Parameter(classType, "c");
                    Expression property = Expression.Property(param, propAttr.prop.Name);
                    LambdaExpression lambdaExpression = Expression.Lambda(property, true,
                        new[] { param });
                    DecimalPropertyConfiguration decimalConfig;
                    if (propAttr.prop.PropertyType.IsGenericType &&
                        propAttr.prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        MethodInfo methodInfo =
                            entityConfig.GetType().GetMethods().Where(p => p.Name == "Property").ToList()[7];
                        decimalConfig =
                            (DecimalPropertyConfiguration)methodInfo.Invoke(entityConfig, new object[] { lambdaExpression });
                    }
                    else
                    {
                        MethodInfo methodInfo =
                            entityConfig.GetType().GetMethods().Where(p => p.Name == "Property").ToList()[6];
                        decimalConfig =
                            (DecimalPropertyConfiguration)methodInfo.Invoke(entityConfig, new object[] { lambdaExpression });
                    }
                    decimalConfig.HasPrecision(propAttr.attr.Precision, propAttr.attr.Scale);
                }
            }
        }

        private IEnumerable<Type> GetDbContextApplicableTypes()
        {
            IEnumerable<Type> types = from t in Assembly.GetAssembly(typeof(DecimalPrecisionAttribute)).GetTypes()
                                      let tableAttribute = t.GetAttribute<TableAttribute>()
                                      where t.IsClass && tableAttribute != null && string.Equals(tableAttribute.Schema, SchemaName)
                                      select t;
            return types;
        }
    }
}
