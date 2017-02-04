module.exports = function (ngModule) {
    ngModule.controller("ListUsersController", ["$scope", "UserService", function ($scope, UserService) {
        $scope.user = {};

    }]);
};