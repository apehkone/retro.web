(function () {
    "use strict";

    angular
        .module("app")
        .controller("pageController", pageController);

    pageController.$inject = ["$location", "$scope"]; 

    function pageController($location, $scope) {
        var vm = this;

        vm.title = "This is from page controller";

        activate();

        function activate() { }
    }
})();
