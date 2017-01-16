module.exports = function (ngModule) {
    ngModule.controller("SidebarController", ["$scope", "UserService", function ($scope, UserService) {
        $scope.currentUser = {};

        UserService.getCurrentUser().success(function (data) {
            $scope.currentUser = data;
        }).error(function (data) {
            console.log("Error fetching the current user!! " + data);
        });

        $scope.rate = 3;
    }]);
};