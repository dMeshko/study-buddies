module.exports = function (ngModule) {
    ngModule.config([
        "$stateProvider", "$urlRouterProvider", function ($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise("/"); //for undefined state go to the default/home

            $stateProvider
                .state("app",
                {
                    url: "/",
                    views: {
                        "header": {
                            controller: "HeaderController",
                            template: require("./common/header.html")
                        },
                        "content": {
                            template: require("./components/home/content.html")
                        },
                        "footer": {
                            controller: "FooterController",
                            //templateUrl: "./app/home/footer.html"
                            template: require("./common/footer.html")
                        },
                        "left@app": {
                            template: require("./components/home/sidebar.html")
                        },
                        "main@app": {
                            template: require("./components/home/home.html"),
                            controller: "HomeController"
                        }
                    }
                })
                .state("app.profile",
                {
                    url: "profile",
                    views: {
                        "content@": {
                            template: require("./components/view-profile/view-profile.html")
                        }
                    }
                });;
        }
    ]);
};