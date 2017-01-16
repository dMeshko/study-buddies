module.exports = function (ngModule) {
    ngModule.config([
        "$stateProvider", function ($stateProvider) {
            $stateProvider
                .state("admin",
                {
                    url: "/admin",
                    views: {
                        "content": {
                            template: require("app/admin/home.html")
                        }
                    }
                });
        }
    ]);
}