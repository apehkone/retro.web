(function() {
    "use strict";

    angular.module("app").factory("Retro", function () {
        // ReSharper disable once InconsistentNaming
        function Retro(dto) {
            this.id = null;
            this.description = null;
            this.createdOn = null;
            this.updatedOn = null;
            this.selectedTemplate = null;

            if (dto) {
                this.load(dto);
            }
        }

        Retro.prototype = {
            load: function(input) {
                this.id = input ? input.id : "";
                this.description = input ? input.description : "";
                this.createdOn = input ? input.createdOn : "";
                this.updatedOn = input ? input.updatedOn : "";
            },

            clear: function() {
                this.id = null;
                this.description = null;
                this.createdOn = null;
                this.updatedOn = null;
            }
        };

        return Retro;
    });
})();

(function () {
    "use strict";

    angular.module("app").factory("RetroCategory", function () {
        // ReSharper disable once InconsistentNaming
        function RetroCategory(dto) {
            this.id = null;
            this.description = null;
            this.createdOn = null;
            this.updatedOn = null;
            
            if (dto) {
                this.load(dto);
            }
        }

        RetroCategory.prototype = {
            load: function (input) {
                this.id = input ? input.id : "";
                this.retrospectiveId = input ? input.retrospectiveId : "";
                this.categoryId = input ? input.categoryId : "";
                this.description = input ? input.description : "";
                this.createdOn = input ? input.createdOn : "";
                this.updatedOn = input ? input.updatedOn : "";
            },

            clear: function () {
                this.id = null;
                this.retrospectiveId = null;
                this.categoryId = null;
                this.description = null;
                this.createdOn = null;
                this.updatedOn = null;
            }
        };

        return RetroCategory;
    });
})();


(function () {
    "use strict";

    angular.module("app").factory("RetroItem", function () {
        // ReSharper disable once InconsistentNaming
        function RetroItem(dto) {
            this.id = null;
            this.retrospectiveId = null;
            this.categoryId = null;
            this.description = null;
            this.createdOn = null;
            this.updatedOn = null;
            this.votes = null;

            if (dto) {
                this.load(dto);
            }
        }

        RetroItem.prototype = {
            load: function(input) {
                this.id = input ? input.id : "";
                this.retrospectiveId = input ? input.retrospectiveId : "";
                this.categoryId = input ? input.categoryId : "";
                this.description = input ? input.description : "";
                this.createdOn = input ? input.createdOn : "";
                this.updatedOn = input ? input.updatedOn : "";
                this.votes = input ? input.votes : null;
            },

            clear: function() {
                this.id = null;
                this.retrospectiveId = null;
                this.categoryId = null;
                this.description = null;
                this.createdOn = null;
                this.updatedOn = null;
                this.votes = null;
            }
        };

        return RetroItem;
    });
})();
