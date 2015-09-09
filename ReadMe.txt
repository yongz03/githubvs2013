Instructions to setup and run the solution:
1. Load the solution in VS 2013, and set insurance.web project as startup project
2. Change db server name to your localhost db server in Insurance.web project;if you use sql express, please make sure that sql server service is started.
3. run update-database in vs package manager console in order to create db, make sure that the default project in package manager console is set to be Insurance.EntityFramework
4. run the solution in Vs by pressing F5(the initial url http://localhost:6234/)
5. Follow the app to go step by step
6. the button will be enabled when all requied data are entered and values are valid, or premium amount is not zero.
7. the purchase button will save all data to db and notice users.
8. third party query string to access the selection page is ?firstNam=*&lastName=*&isProtect=*&title=*,
assuming here that the third party only passes these data to us
