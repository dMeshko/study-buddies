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
                    .success(function(data) {
                        $state.go("app.groups.details", { id: data });
                    })
                    .error(function (response) {
                        $scope.parseErrorMessage(response);
                    });
            };

            $scope.subjects = [];
            SubjectService.getAllSubjects()
                .success(function (data) {
                    $scope.subjects = data;
                })
                .error(function (response) {
                    $scope.parseErrorMessage(response);
                });
        }]);
}