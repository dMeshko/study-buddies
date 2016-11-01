module.exports = function (ngModule) {
    ngModule.controller("HomeController", ["$scope", "UserService", function ($scope, UserService) {
        $scope.users = [];

            UserService.getAllUsers().success(function(response) {
                $scope.users = response;
            }).error(function() {
                console.log("error!!");
            });


        }
    ]);
};