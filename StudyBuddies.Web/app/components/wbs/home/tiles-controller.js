module.exports = function (ngModule) {
    ngModule.controller("TilesController", ["$scope", "UserService", function ($scope, UserService) {
        $scope.user = {};

    }]);
};