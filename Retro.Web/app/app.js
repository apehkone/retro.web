(function () {
    var app = angular.module("app", ["ngRoute", "ngResource"]);

    app.config([
        "$routeProvider",
        function ($routeProvider) {
            var viewBase = "/app/views/";

            $routeProvider
                .when("/main", {
                    templateUrl: viewBase + "main.html"
                })
                .when("/add", {
                    templateUrl: viewBase + "add.html"
                })
                .when("/edit/:id", {
                    templateUrl: viewBase + "edit.html"
                })

                .otherwise({ redirectTo: "/main" });
        }
    ]);
})();
