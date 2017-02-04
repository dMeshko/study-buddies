module.exports = function (ngModule) {
    ngModule.controller("ViewUserProfileController", ["$scope", "$stateParams", "UserService", function ($scope, $stateParams, UserService) {
        $scope.user = {};

        UserService.getUserById($stateParams.id)
            .success(function (data) {
                $scope.user = data;
            })
            .error(function (data) {
                console.log("Error getting the user details");
            });

        $scope.deleteProfile = function (id) {
            UserService.deleteUser(id)
                .success(function() {
                    console.log("the user is gone now!");
                })
                .error(function(data) {
                    console.log("Delete failed because: " + data);
                    alert(JSON.stringify(data));
                });
        }
    }
    ]);
};