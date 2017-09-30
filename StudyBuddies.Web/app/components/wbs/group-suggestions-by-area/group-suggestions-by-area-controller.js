module.exports = function (ngModule) {
    ngModule.controller("GroupSuggestionsByArea", ["$scope", "$http", "GroupService", function ($scope, $http, GroupService) {
        $scope.user = {};

        $scope.areas = [];

        $http.get("http://web.studybuddies.com/api/area")
            .then(function(response) {
                $scope.areas = response.data;
            }, function (response) {
                $scope.parseErrorMessage(response.data);
            });

        $scope.groups = [];
        $scope.fetchGroups = function(fieldName) {
            $scope.groups = [];
            $http.post("http://localhost:9090/possibleUserGroups?userID=" + $scope.currentUser.id + "&field=" + fieldName)
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
        };


    }]);
};