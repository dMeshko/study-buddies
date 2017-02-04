module.exports = function (ngModule) {
    ngModule.controller("RightSidebarController", ["$scope", "GroupService", function ($scope, GroupService) {
        $scope.grpups = [];
        GroupService.getAllGroupsWhereNoRequestIsSent($scope.currentUser.id)
                .success(function (response) {
                    $scope.groups = response;
            })
                .error(function (response) {
                    $scope.parseErrorMessage(response);
                });

    }]);
};