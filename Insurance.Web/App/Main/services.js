
angular.module('app').factory('notificationService', [
    '$http', '$q', '$filter', function ($http, $q, $filter) {

        function getMessage(args) {
            var message;
            console.log('args', args);
            message = args.message;
            return message;
        }

        return {

            success: function (args) {
                toastr.success(getMessage(args));
            },

            error: function (args) {
                toastr.error(getMessage(args));
            },

            warn: function(args) {
                toastr.warning(getMessage(args));
            }
        };
    }
]);