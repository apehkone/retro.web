(function() {
    'use strict';

    angular
        .module('app')
        .controller('editController', editController);

    editController.$inject = ["$location", "$routeParams", "retroRepository", "retroItemRepository", "RetroItem"];

    function editController($location, $routeParams, retroRepository, retroItemRepository, RetroItem) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'editController';

        activate();

        function activate() {
            vm.model = retroRepository.get({ id: $routeParams.id });
        }

        vm.addItem = function (parent) {
            vm.model.categories.forEach(function(category) {
                if (category.id === parent.id) {
                    var item = new RetroItem();
                    item.retrospectiveId = vm.model.id;
                    item.categoryId = parent.categoryId;
                    category.items.push(item);
                    return;
                }
            });
        };

        vm.saveItem = function (parent, item) {
            item.retrospectiveId = vm.model.id;
            item.categoryId = parent.id;
            retroItemRepository.save(item, function(result) {
                item.id = result.id; 
            });
        };

        vm.deleteItem = function (parent, item) {
            var category = vm.model.categories.indexOf(parent);
            var index = vm.model.categories[category].items.indexOf(item);
            retroItemRepository.delete({ 'id': item.id, 'categoryId' : parent.id, "retrospectiveId" : vm.model.id }, function() {
                vm.model.categories[category].items.splice(index, 1);
            });
        };
    }
})();