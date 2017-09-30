module.exports = function (ngModule) {
    ngModule.controller("ListGroupsController", [
        "$scope", "GroupService",
        function ($scope, GroupService) {
            $scope.model = {
                user: {
                    id: "3F6E0CC2-020C-424E-B57C-7C9BDC427EF8"
                },
                group: {},
                status: {
                    id: 0
                }
            };

            $scope.groups = [];
            GroupService.getAllGroupsWhereNoRequestIsSent($scope.model.user.id)
                .then(function(response) {
                    $scope.groups = response.data;
                }, function(response) {
                    $scope.parseErrorMessage(response.data);
                });

            $scope.joinGroup = function(groupId) {
                $scope.model.group.id = groupId;
                GroupService.sendGroupRequest($scope.model);
            };

            $scope.deleteGroup = function(groupId) {
                GroupService.deleteGroup(groupId)
                    .then(function(response) {
                        $scope.groups = $scope.groups.filter(function(item) {
                            if (item.id === groupId)
                                return false;
                            return true;
                        });
                    }, function(response) {
                        $scope.parseErrorMessage(response.data);
                    });
            };
        }]);
}