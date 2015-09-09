(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',
        'ui.router',
        'ui.bootstrap',
        'ui.jq',
        'abp',
        'LocalStorageModule'
    ]);


    app.config([
    '$stateProvider', '$urlRouterProvider', 'localStorageServiceProvider', (function () {
        function configRoutes($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/selection');
            $stateProvider

                .state('selection', {
                    url: '/selection?firstName&lastName&isProtect&title',
                    templateUrl: '/App/Main/views/selection/selection.cshtml',
                    menu: 'Selection' //Matches to name of 'Selection' menu in InsuranceNavigationProvider
                    
                })
                .state('results', {
                    url: '/results?premium&gender&dob&coverAmount&isProtect&smoking',
                    templateUrl: '/App/Main/views/results/results.cshtml'
                });
        }

        function configLocalStorage(localStorageServiceProvider) {
            localStorageServiceProvider.setPrefix('tal');
            localStorageServiceProvider.setStorageType('sessionStorage');
        }

        //function configExceptionHandling($provide) {
        //    $provide.decorator("$exceptionHandler", [
        //        '$delegate', '$injector', (function () {

        //            function getStackTrace(err) {
        //                var stackTrace = printStackTrace({ e: err });
        //                if ($.isArray(stackTrace)) {
        //                    stackTrace = stackTrace.join('\n');
        //                }
        //                return stackTrace;
        //            }

        //            return function ($delegate, $injector) {
        //                return function (exception, cause) {

        //                    alert('An unexpected error has occurred.');

        //                    var clientLogService = $injector.get("abp.services.app.clientLog");

        //                    clientLogService.logException({
        //                        message: exception.message,
        //                        stackTrace: getStackTrace(exception)
        //                    });

        //                    $delegate(exception, cause);
        //                };
        //            }
        //        })()
        //    ]);
        //}

        return function ($stateProvider, $urlRouterProvider, localStorageServiceProvider) {
            configLocalStorage(localStorageServiceProvider);
            configRoutes($stateProvider, $urlRouterProvider);
            //configExceptionHandling($provide);
        }
    })()
    ]);

})();

