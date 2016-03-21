(function () {
    'use strict';


    angular
        .module('app')
        .factory('ChannelService', ChannelService);


    ChannelService.$inject = ['$rootScope', 'appConfig', '$http'];

    function ChannelService($rootScope, appConfig, $http) {

        var service = {};

        service.createChannel = createChannel;

        return service;


        function createChannel(message) {

            var userId = $rootScope.globals.currentUser.userId;

            alert(userId);

            return message;
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
