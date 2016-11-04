module.exports = function (ngModule) {
    ngModule.controller("ViewUserProfileController", ["$scope", "$stateParams", "UserService", function ($scope, $stateParams, UserService) {
        $scope.user = {};

            UserService.getUserById($stateParams.id)
                .success(function(data) {
                    $scope.user = data;
                })
                .error(function(data) {
                    console.log("Error getting the user details");
                });
        }
    ]);
};