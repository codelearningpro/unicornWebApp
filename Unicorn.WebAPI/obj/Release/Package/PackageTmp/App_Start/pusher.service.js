(function () {
    'use strict';

    angular
        .module('app')
        .factory('PusherService', PusherService);

    PusherService.$inject = ['$http'];
    function PusherService($http) {
        var service = {};

        service.SendMessage = SendMessage;


        return service;

        function SendMessage(message) {

            var url = '/api/customer/SendMessage/' + message;

            return $http.post(url).then(handleSuccess, handleError('Error creating pusher message.'));
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
