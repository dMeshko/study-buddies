module.exports = function (ngModule) {
    ngModule.controller("LeftSidebarController", ["$scope", "UserService", function ($scope, UserService) {
        $scope.user = {};

        UserService.getUserById($scope.currentUser.id)
            .then(function(response) {
                $scope.user = response.data;
                $scope.userInstitutions = response.data.institutions.map(x => x.name).join(", ");
            }, function (response) {
                $scope.parseErrorMessage(response.data);
            });
    }]);
};