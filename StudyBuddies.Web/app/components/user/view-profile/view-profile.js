module.exports = function (ngModule) {
    ngModule.controller("ViewUserProfileController", ["$scope", "$stateParams", "UserService", function ($scope, $stateParams, UserService) {
        $scope.user = {};

            UserService.getUserById($stateParams.id)
                .then(function(response) {
                    $scope.user = response.data;
                }, function(response) {
                    $scope.parseErrorMessage(response.data);
                });

        $scope.deleteProfile = function (id) {
            UserService.deleteUser(id)
                .then(function(response) {
                    alert("deleted");
                }, function(response) {
                    $scope.parseErrorMessage(response.data);
                });
        }
    }
    ]);
};