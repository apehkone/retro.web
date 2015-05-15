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
        vm.selectedItem = null;

        activate();

        function activate() {
            vm.model = retroRepository.get({ id: $routeParams.id });
        }

        vm.addItem = function (parent) {
            vm.model.categories.forEach(function (category) {
                if (category.id === parent.id) {
                    var item = new RetroItem();
                    item.retrospectiveId = vm.model.id;
                    item.categoryId = parent.categoryId;
                    vm.editItem(category, item);
                }
            });
        };

        vm.editItem = function (parent, item) {
            vm.selectedCategory = parent;
            vm.selectedItem = item;
            $('#editCtrl').modal('show');
        };

        vm.saveItem = function (parent, item) {
            item.retrospectiveId = vm.model.id;
            item.categoryId = parent.id;
            retroItemRepository.save(item, function (result) {

                vm.model.categories.forEach(function (category) {
                    if (category.id === parent.id) {
                        var found = false;
                        category.items.forEach(function(i) {
                            if (i.id == result.id) {
                                found = true; 
                            }
                        });

                        if (!found) {
                            item.id = result.id;
                            category.items.push(item);
                        }
                    }
                });
                $('#editCtrl').modal('hide');
            });
        };

        vm.deleteItem = function (parent, item) {
            var category = vm.model.categories.indexOf(parent);
            var index = vm.model.categories[category].items.indexOf(item);
            retroItemRepository.delete({ 'id': item.id, 'categoryId' : parent.id, "retrospectiveId" : vm.model.id }, function() {
                vm.model.categories[category].items.splice(index, 1);
                $('#editCtrl').modal('hide');
            });
        };

        vm.onDragComplete = function (targetCategory, source) {
            if (!source) return;

            source.category.items.splice(source.category.items.indexOf(source.item), 1);
            targetCategory.items.push(source.item);

            retroItemRepository.delete({ 'id': source.item.id, 'categoryId': source.category.id, "retrospectiveId": vm.model.id }, function () {
                source.item.retrospectiveId = vm.model.id;
                source.item.categoryId = targetCategory.id;
                source.item.id = null;
                retroItemRepository.save(source.item, function(result) {
                    source.item.id = result.id;
                });
            });
        };
    }
})();