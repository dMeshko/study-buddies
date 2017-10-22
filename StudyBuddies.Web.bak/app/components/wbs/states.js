module.exports = function (ngModule) {
    ngModule.run([
        "refs", function (refs) {
            var $stateProvider = refs.get("$stateProvider");

            $stateProvider
                .state("app.wbs",
                {
                    url: "wbs",
                    abstract: true,
                    views: {
                        "content@": {
                            template: require("./home/tiles.html"),
                            controller: "TilesController"
                        }
                    }
                })
                .state("app.wbs.home",
                {
                    url: "" //<-- Empty string for "app" state to override the / abstract state
                })
                .state("app.wbs.possibleUserGroups",
                {
                    url: "/wbs-by-area",
                    views: {
                        "content@": {
                            template: require("./group-suggestions-by-area/group-suggestions-by-area.html"),
                            controller: "GroupSuggestionsByArea"
                        }
                    }
                })
                 .state("app.wbs.userGroups",
                {
                    url: "/wbs-user-groups",
                    views: {
                        "content@": {
                            template: require("./user-groups/user-groups.html"),
                            controller: "UserGroupsController"
                        }
                    }
                })
                .state("app.wbs.relevantUserPosts",
                {
                    url: "/wbs-relevant-user-posts",
                    views: {
                        "content@": {
                            template: require("./relevant-user-posts/relevant-user-posts.html"),
                            controller: "RelevantUserPostsController"
                        }
                    }
                })
            .state("app.wbs.relevantPeople",
                {
                    url: "/wbs-relevant-people",
                    views: {
                        "content@": {
                            template: require("./relevant-people/relevant-people.html"),
                            controller: "RelevantPeopleController"
                        }
                    }
                })
            .state("app.wbs.relevantGroups",
                {
                    url: "/wbs-relevant-groups",
                    views: {
                        "content@": {
                            template: require("./relevant-groups/relevant-groups.html"),
                            controller: "RelevantGroupsController"
                        }
                    }
                });
        }
    ]);
};