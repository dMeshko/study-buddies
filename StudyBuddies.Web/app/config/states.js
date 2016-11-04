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
                            template: require("app/common/header.html")
                        },
                        "content": {
                            template: require("app/components/home/content.html")
                        },
                        "footer": {
                            controller: "FooterController",
                            //templateUrl: "./app/home/footer.html"
                            template: require("app/common/footer.html")
                        },
                        "left@app": {
                            template: require("app/components/home/sidebar.html"),
                            controller: "SidebarController"
                        },
                        "main@app": {
                            template: require("app/components/home/home.html"),
                            controller: "HomeController"
                        }
                    }
                })
                .state("app.profile",
                {
                    url: "profile/:id",
                    views: {
                        "main@app": {
                            template: require("app/components/view-profile/view-profile.html"),
                            controller: "ViewUserProfileController"
                        }
                    }
                })
                .state("app.register",
                {
                    url: "register",
                    views: {
                        "content@": {
                            template: require("app/components/register-user/register-user.html"),
                            controller: "RegisterUserController"
                        }
                    }
                }
                );
        }
    ]);
};