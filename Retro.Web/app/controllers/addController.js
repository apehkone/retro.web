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
        vm.model.selectedTemplate = null;
        vm.model.templates = [{ code: "1", description: "Todo" }, { code: "2", description: "Pros and Cons" }, { code: "3", description: "Scrum Retrospective" }, { code: "4", description: "4 Sections" }];

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
