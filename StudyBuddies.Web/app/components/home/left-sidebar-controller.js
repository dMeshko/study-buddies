module.exports = function (ngModule) {
    ngModule.controller("LeftSidebarController", ["$scope", "UserService", function ($scope, UserService) {
        $scope.user = {};

        UserService.getUserById($scope.currentUser.id)
            .success(function (data) {
                $scope.user = data;
            }).error(function (data) {
                $scope.parseErrorMessage(data);
            });
    }]);
};