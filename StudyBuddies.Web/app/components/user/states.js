module.exports = function (ngModule) {
    ngModule.run([
        "refs", function (refs) {
            var $stateProvider = refs.get("$stateProvider");

            $stateProvider
                .state("app.users",
                {
                    url: "users",
                    abstract: true,
                    views: {
                        "content@": {
                            template: require("./list-users/list-users.html"),
                            controller: "ListUsersController"
                        }
                    }
                })
                .state("app.users.list",
                {
                    url: "" //<-- Empty string for "app" state to override the / abstract state
                })
                .state("app.users.profile",
                {
                    url: "/profile/:id",
                    views: {
                        "content@": {
                            template: require("./view-profile/view-profile.html"),
                            controller: "ViewUserProfileController"
                        }
                    }
                })
                 .state("app.users.profile.groups",
                {
                    url: "/groups",
                    views: {
                        "content@": {
                            template: require("./list-user-groups/list-user-groups.html"),
                            controller: "ListUserGroupsController"
                        }
                    }
                })
                .state("app.users.register",
                {
                    url: "/register",
                    views: {
                        "content@": {
                            template: require("./register-user/register-user.html"),
                            controller: "RegisterUserController"
                        }
                    }
                });
        }
    ]);
};