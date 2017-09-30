module.exports = function(ngModule) {
    ngModule.controller("RegisterUserController", ["$scope", "UserService", "$state", "$rootScope", function ($scope, UserService, $state, $rootScope) {
        $scope.user = {};

        $scope.registerUser = function(form) {
            if (form.$valid) {
                UserService.saveUser($scope.user)
                    .then(function(response) {
                            $rootScope.currentUser.id = response.data;
                            $state.go("app.home");
                        },
                        function(response) {
                            $scope.parseErrorMessage(response.data);
                        });
            };
        };

        $scope.resetForm = function() {
            $scope.user = {};
        };
        $scope.resetForm();
    }]);
};