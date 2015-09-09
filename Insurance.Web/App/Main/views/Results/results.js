(function() {
    var controllerId = 'app.views.results';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'localStorageService', 'abp.services.app.customer', 'notificationService', function ($scope, $state, $stateParams, localStorageService, customerService, notificationService) {

            var Constants = {
                STORAGE_KEY: 'user_name'
            };

            var getTitleString = function (title) {
                var value = "";
                switch (title) {
                    case "0":
                        value = "Mr.";
                        break;
                    case "1":
                        value = "Ms.";
                        break;
                    case "2":
                        value = "Miss.";
                        break;
                    case "3":
                        value = "Dr.";
                        break;
                }
                return value;
            };

            var initialize= function() {
                var user = angular.copy(localStorageService.get(Constants.STORAGE_KEY));
                var titleString = getTitleString(user.title);

                angular.extend($scope,
                {
                    title: titleString,
                    firstName: user.firstName,
                    lastName: user.lastName,
                    premium: $stateParams.premium,
                    gender: $stateParams.gender,
                    dob: $stateParams.dob,
                    coverAmount: $stateParams.coverAmount,
                    isProtect: $stateParams.isProtect,
                    smoking: $stateParams.smoking
                });

                $scope.insuranceType = $stateParams.isProtect=="true"?"Income Protection":"Life insurance"

            }

            initialize();

            $scope.purchase = function() {
                abp.ui.setBusy( //Set whole page busy until createCustomer complete
                    null,
                    customerService.createCustomer({
                        title: $scope.title,
                        firstName: $scope.firstName,
                        lastName: $scope.lastName,
                        gender: $scope.gender,
                        dateOfBirth: $scope.dob,
                        smoking: $scope.smoking,
                        premium: $scope.premium,
                        isProtect: $scope.isProtect,
                        coverAmount: $scope.coverAmount
                    }).success(function () {
                        notificationService.success({ message: "Configurations! You have successfully purchased this policy." });
                    })
                );
            };

        }
    ]);
})();