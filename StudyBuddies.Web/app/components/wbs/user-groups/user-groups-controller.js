module.exports = function (ngModule) {
    ngModule.controller("UserGroupsController", ["$scope", "$http", "GroupService", function ($scope, $http, GroupService) {
        $scope.user = {};

        $scope.groups = [];
        $scope.groups = [];
        $http.post("http://localhost:9090/userGroups?userID=" + $scope.currentUser.id)
        .then(function (response) {
            response.data.forEach(function (item) {
                GroupService.getGroupById(item).then(function (response) {
                    $scope.groups.push(response.data);
                }, function (response) {
                    $scope.parseErrorMessage(response.data);
                });
            });
        }, function (response) {
            $scope.parseErrorMessage(response.data);
        });
    }]);
};