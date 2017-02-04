module.exports = function (ngModule) {
    ngModule.run([
        "refs", function (refs) {
            var $stateProvider = refs.get("$stateProvider");

            $stateProvider
                .state("app.groups",
                {
                    url: "groups",
                    abstract: true,
                    views: {
                        "content@": {
                            template: require("./list-groups/list-groups.html"),
                            controller: "ListGroupsController"
                        }
                    }
                })
                .state("app.groups.list",
                {
                    url: "" //<-- Empty string for "app" state to override the / abstract state
                })
                .state("app.groups.details",
                {
                    url: "/details/:id",
                    views: {
                        "content@": {
                            template: require("./group-details/group-details.html"),
                            controller: "ViewGroupDetailsController"
                        }
                    }
                })
                .state("app.groups.create",
                {
                    url: "/create",
                    views: {
                        "content@": {
                            template: require("./create-group/create-group.html"),
                            controller: "CreateGroupController"
                        }
                    }
                });
            }
    ]);
};