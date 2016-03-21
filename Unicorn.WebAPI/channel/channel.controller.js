(function () {
    'use strict';

    angular
        .module('app')
        .controller('ChannelController', ChannelController);

    ChannelController.$inject = ['$location','ChannelService'];

    function ChannelController($location, ChannelService) {

        var vm = this;

        vm.channel = channel;

        function channel() {

            ChannelService.createChannel(vm.message, function (response) {
                if (response.success) {

                } else {

                }
            });
        };
    }

})();
