(function () {
    "use strict";

    angular
        .module("app")
        .controller("mainController", mainController);

    mainController.$inject = ["$location", "retroRepository"];

    function mainController($location, retroRepository) {
        var vm = this;
        vm.title = "";

        activate();

        function activate() {
            vm.items = retroRepository.query();
        }

        vm.add = function () {
            $location.path("/add");
        }
    }
})();