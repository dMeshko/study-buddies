module.exports = function (ngModule) {
    ngModule.controller("HomeController", ["$scope", "UserService", function ($scope, UserService) {
        $scope.users = [];

            UserService.getAllUsers().success(function(data) {
                $scope.users = data;
            }).error(function(data) {
                console.log("Unable to fetch the users!! " + data);
            });
        }
    ]);
};