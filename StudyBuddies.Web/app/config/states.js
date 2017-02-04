module.exports = function (ngModule) {
    ngModule.config([
        "$stateProvider", "$urlRouterProvider", "refsProvider", function ($stateProvider, $urlRouterProvider, refsProvider) {
            $urlRouterProvider.otherwise("/"); //for undefined state go to the default/home

            refsProvider.injectRef('$urlRouterProvider', $urlRouterProvider);
            refsProvider.injectRef('$stateProvider', $stateProvider);

            $stateProvider
                .state("app",
                {
                    url: "/",
                    abstract: true,
                    views: {
                        "header": {
                            controller: "HeaderController",
                            template: require("app/common/header.html")
                        },
                        "content": {
                            template: require("app/components/home/content.html")
                        },
                        "footer": {
                            controller: "FooterController",
                            template: require("app/common/footer.html")
                        },
                        "left@app": {
                            template: require("app/components/home/left-sidebar.html"),
                            controller: "LeftSidebarController"
                        },
                        "main@app": {
                            template: require("app/components/home/home.html"),
                            controller: "HomeController"
                        },
                        "right@app": {
                            template: require("app/components/home/right-sidebar.html"),
                            controller: "RightSidebarController"
                        }
                    }
                })
                .state("app.home",
                {
                    url: "" //<-- Empty string for "app" state to override the / abstract state
                });
        }
    ]);
};