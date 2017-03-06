module.exports = function (ngModule) {
    ngModule.controller("ListUserGroupsController", [
        "$scope", "GroupService",
        function ($scope, GroupService) {
            $scope.groups = [];
            GroupService.getAllMemberingGroups($scope.currentUser.id)
                .success(function (response) {
                    $scope.groups = response;
                })
                .error(function (response) {
                    $scope.parseErrorMessage(response);
                });

            $scope.deleteGroup = function (groupId) {
                GroupService.deleteGroup(groupId)
                    .success(function (data) {
                        $scope.groups = $scope.groups.filter(function (item) {
                            if (item.id === groupId)
                                return false;
                            return true;
                        });
                    })
                    .error(function (response) {
                        $scope.parseErrorMessage(response);
                    });
            };
        }]);
}