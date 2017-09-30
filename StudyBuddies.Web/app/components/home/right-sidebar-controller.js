module.exports = function (ngModule) {
    ngModule.controller("RightSidebarController", ["$scope", "GroupService", function ($scope, GroupService) {
        $scope.grpups = [];
        GroupService.getAllGroupsWhereNoRequestIsSent($scope.currentUser.id)
            .then(function(response) {
                $scope.groups = response.data;
            }, function(response) {
                $scope.parseErrorMessage(response.data);
            });
    }]);
};