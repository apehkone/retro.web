(function () {
    'use strict';

    angular
        .module('app')
        .controller('addController', addController);

    addController.$inject = ["$location", "retroRepository", "Retro"];

    function addController($location, retroRepository, Retro) {
        var vm = this;
        vm.title = "addController";

        vm.model = new Retro();

        activate();

        function activate() { }

        vm.submit = function () {
            retroRepository.save(vm.model, function (item) {
                $location.path("/edit/" +item.id);
            });

        };

        vm.cancel = function() {
            $location.path("/main");
        };
    }
})();
