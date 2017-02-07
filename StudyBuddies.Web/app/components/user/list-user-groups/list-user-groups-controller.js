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
        }]);
}