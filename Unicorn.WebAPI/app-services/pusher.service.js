(function () {
    'use strict';

   
    angular
        .module('app')
        .factory('PusherService', PusherService);


    

    PusherService.$inject = ['$rootScope', 'appConfig', '$http'];
    
    function PusherService($rootScope, appConfig, $http) {

        var service = {};

        service.SendMessage = SendMessage;
        
        return service;

        
        function SendMessage(message) {

            
            message = $rootScope.globals.currentUser.username.replace('@savewithsprout.com', '|') + message;

            var url = appConfig.apiRoot + 'api/customer/SendMessage/' + message;

            
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
