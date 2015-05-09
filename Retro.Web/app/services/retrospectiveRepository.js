(function() {
    "use strict";

    angular.module("app").factory("retroRepository", function($resource) {
        return $resource("api/retro/:id");
    });

})();


(function() {
    "use strict";

    angular.module("app").factory("retroItemRepository", function($resource) {
        return $resource("api/retroitem/:id?retrospectiveId=:retrospectiveId&categoryId=:categoryId");
    });

})();                                                                                   