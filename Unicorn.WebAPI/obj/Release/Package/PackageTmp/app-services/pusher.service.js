(function () {
    'use strict';

    angular
        .module('app')
        .factory('PusherService', PusherService);

    PusherService.$inject = ['$rootScope', '$http'];


    function PusherService($rootScope, $http) {

        var service = {};

        service.SendMessage = SendMessage;
        
        return service;

        
        function SendMessage(message) {

            var message1 = $rootScope.globals.currentUser.username.replace('@savewithsprout.com', '|') + message;

            var url = '/api/customer/SendMessage/' + message1;

            return $http.post(url).then(handleSuccess, handleError('Error sending message'));
        }

        
        // private functions
        function handleSuccess(res) {
            return res.data;
        }

        function handleError(error) {
            return function () {
                return { success: false, message: error };
            };
        }
    }

})();
