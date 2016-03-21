(function () {
    'use strict';

    angular
        .module('app')
        .controller('PusherController', PusherController);

    PusherController.$inject = ['$location','PusherService'];

    function PusherController($location, PusherService) {

        var vm = this;

        vm.pusher = pusher;

        function pusher() {

            PusherService.SendMessage(vm.message, function (response) {
                if (response.success) {

                } else {

                }
            });
        };
    }

})();
