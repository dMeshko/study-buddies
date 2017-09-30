module.exports = function (ngModule) {
    ngModule.controller("ListUserGroupsController", [
        "$scope", "GroupService",
        function ($scope, GroupService) {
            $scope.groups = [];
            GroupService.getAllMemberingGroups($scope.currentUser.id)
                .then(function(response) {
                    $scope.groups = response.data;
                }, function(response) {
                    $scope.parseErrorMessage(response.data);
                });

            $scope.deleteGroup = function (groupId) {
                GroupService.deleteGroup(groupId)
                    .then(function(response) {
                        $scope.groups = $scope.groups.filter(function (item) {
                            if (item.id === groupId)
                                return false;
                            return true;
                        });
                    }, function(response) {
                        $scope.parseErrorMessage(response);
                    });
            };
        }]);
}