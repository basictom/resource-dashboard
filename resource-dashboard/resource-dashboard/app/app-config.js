app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/home",
        {
            templateUrl: "/app/views/home.html",
            controller: "homeCtrl"
        });
}]);