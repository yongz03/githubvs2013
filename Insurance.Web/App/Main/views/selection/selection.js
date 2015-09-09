(function() {
    var controllerId = 'app.views.selection';
    angular.module('app').controller(controllerId, [
        '$scope', '$window', '$timeout', '$state', '$stateParams', 'localStorageService', 'notificationService', function($scope, $window, $timeout, $state, $stateParams, localStorageService, notificationService) {

            var DELAY_TIME_BEFORE_POSTING = 500;
            var Constants = {
                STORAGE_KEY: 'user_name'
            };

            var rates={};
            var currentTimeout = null;
            var storageService = localStorageService;

            $scope.activateTab = function(tabItem) {
                $scope.tabItems.forEach(function(item) {
                    item.isActive = false;
                });
                tabItem.isActive = true;
                $scope.isProtect = tabItem.isProtect;
                $scope.maxValue = tabItem.maxValue;

            };

            $scope.isFormValid = function() {
                var form = $scope.selectionForm;
                return form.$valid && form.$dirty && $scope.coverAmount != undefined;
            }

            $scope.calculatePremium = function() {

                if ($scope.isFormValid()) {
                    if (currentTimeout) {
                        $timeout.cancel(currentTimeout);
                    }
                    currentTimeout = $timeout(function() {
                        calculate();
                    }, DELAY_TIME_BEFORE_POSTING);

                }
            }

            $scope.getQuote = function() {
                storageService.set(Constants.STORAGE_KEY, { firstName: $scope.firstName, lastName: $scope.lastName, title: $scope.title });
                var dob = getDateOnlyFromDatePicker(angular.copy($scope.dob));

                var params = { premium: angular.copy($scope.premium), gender: getGender($scope.gender), dob: dob, coverAmount: angular.copy($scope.coverAmount), isProtect: angular.copy($scope.isProtect), smoking: angular.copy($scope.smoking) };
                $state.go('results', params);
            }

            var calculate = function() {
                var gender = getGender($scope.gender);
                var age = getAgeFromDob();
                var coverAmount = $scope.coverAmount;

                var rate = getRateFrom(gender, age, $scope.isProtect);
                if (!rate.pricePerThousandCover) {
                    rate.pricePerThousandCover = 0;
                }

                $scope.premium = rate.pricePerThousandCover * coverAmount / 1000;
            };

            var getGender = function(gender) {
                return gender == 0 ? 'M' : 'F';
            }

            var getAgeFromDob = function() {
                var today = new Date();
                var birthDate = new Date($scope.dob);
                var age = today.getFullYear() - birthDate.getFullYear();
                var m = today.getMonth() - birthDate.getMonth();
                if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
                    age--;
                }

                return age;
            };
            var getRateFrom = function(gender, age, isProtect) {
                var returnRate = {};
                for (var i = 0; i < rates.length; i++) {
                    var rate = rates[i];
                    if (rate.gender === gender && rate.isProtect === isProtect) {
                        if (rate.minAge <= age && rate.maxAge >= age) {
                            returnRate = rate;
                            break;
                        }
                    }
                }

                return returnRate;
            };

            var getDateOnlyFromDatePicker = function(dob) {
                dob.setHours(24, dob.getTimezoneOffset(), 0, 0);
                return dob.toISOString().slice(0, 10)
            };

            var getTitleFromString = function(title) {
                var numTitle;
                switch (title) {
                case "mr":
                    numTitle = "0";
                    break;
                case "ms":
                    numTitle = "1";
                    break;
                case "miss":
                    numTitle = "2";
                    break;
                case "dr":
                    numTitle = "3";
                    break;
                }

                return numTitle;
            }

            var initialize = function() {
                $scope.tabItems = [{ text: 'Life Insurance', isActive: true, isProtect: false, maxValue: 100000 }, { text: 'Income Protection', isActive: false, isProtect: true, maxValue: 5000 }];
                var ratesString = abp.setting.get("Rates");
                var reatesScripts = JSON.parse(ratesString);
                rates = reatesScripts.rates;

                var tabItem = $scope.tabItems[0];
                $scope.maxValue = tabItem.maxValue;
                $scope.isProtect = tabItem.isProtect;

                if ($stateParams.title)
                    $scope.title = getTitleFromString($stateParams.title);

                $scope.firstName = $stateParams.firstName || '';
                $scope.lastName = $stateParams.lastName || '';
                $scope.isProtect = $stateParams.isProtect || false;

                if ($stateParams.isProtect == "true") {
                    tabItem = $scope.tabItems[1];
                    $scope.maxValue = tabItem.maxValue;
                    $scope.isProtect = tabItem.isProtect;
                    $scope.activateTab(tabItem);
                }

            }

            initialize();
        }
    ]);
})();