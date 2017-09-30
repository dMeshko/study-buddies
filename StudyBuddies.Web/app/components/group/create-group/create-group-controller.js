module.exports = function(ngModule) {
    ngModule.controller("CreateGroupController", [
        "$scope", "GroupService", "SubjectService", "$state",
        function ($scope, GroupService, SubjectService, $state) {
            $scope.model = {
                name: "",
                description: "",
                groupCapacity: 0,
                admin: $scope.currentUser,
                subject: null
            };

            $scope.createGroup = function() {
                GroupService.createGroup($scope.model)
                    .then(function(response) {
                        $state.go("app.groups.details", { id: response.data });
                    }, function(response) {
                        $scope.parseErrorMessage(response.data);
                    });
            };

            $scope.subjects = [];
            SubjectService.getAllSubjects()
                .then(function(response) {
                    $scope.subjects = response.data;
                }, function(response) {
                    $scope.parseErrorMessage(response.data);
                });
        }]);
}