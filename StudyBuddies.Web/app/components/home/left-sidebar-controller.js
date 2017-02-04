module.exports = function (ngModule) {
    ngModule.controller("LeftSidebarController", ["$scope", "UserService", function ($scope, UserService) {
        $scope.currentUser = {};

        UserService.getCurrentUser().success(function (data) {
            $scope.currentUser = data;
        }).error(function (data) {
            $scope.parseErrorMessage(data);
        });

        $scope.rate = 3;
    }]);
};