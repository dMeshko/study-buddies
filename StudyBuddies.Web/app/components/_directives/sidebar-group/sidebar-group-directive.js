module.exports = function (ngModule) {
    ngModule.directive("sidebarGroup", function (GroupService, $state, $rootScope) {
        var frontpageGroupDirective = {
            restrict: "E",
            scope: {
                group: "="
            },
            template: require("./sidebar-group.html"),
            link: function ($scope, $element, $attributes) {
                $scope.model = {
                    user: {
                        id: $rootScope.currentUser.id
                    },
                    group: {
                        id: ""
                    }
                };
                $scope.joinGroup = function(groupId) {
                    $scope.model.group.id = groupId;
                    GroupService.sendGroupRequest($scope.model)
                        .then(function(response) {
                            delete $scope.group;
                        }, function(response) {
                            $rootScope.parseErrorMessage(response.data);
                        });
                };
            }
        };

        return frontpageGroupDirective;
    });
}