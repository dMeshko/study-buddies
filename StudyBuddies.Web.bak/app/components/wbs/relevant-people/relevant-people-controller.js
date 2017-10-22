module.exports = function (ngModule) {
    ngModule.controller("RelevantPeopleController", ["$scope", "$http", "UserService", function ($scope, $http, UserService) {
        $scope.user = {};

        $scope.users = [];
        $http.post("http://localhost:9090/relevantPeople?userID=" + $scope.currentUser.id)
        .then(function (response) {
            response.data.forEach(function (item) {
                UserService.getUserById(item).then(function (response) {
                    var user = response.data;
                    user.institutionNames = response.data.institutions.map(x => x.name).join(", ");
                    $scope.users.push(user);
                }, function (response) {
                    $scope.parseErrorMessage(response.data);
                });
            });
        }, function (response) {
            $scope.parseErrorMessage(response.data);
        });
    }]);
};