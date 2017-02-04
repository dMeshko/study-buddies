module.exports = function(ngModule) {
    ngModule.controller("CreateGroupController", [
        "$scope", "GroupService", "SubjectService",
        function ($scope, GroupService, SubjectService) {
            $scope.model = {
                name: "",
                description: "",
                groupCapacity: 0,
                admin: {
                    id: "50C308F7-E2E5-4529-8BA8-A700017C712D",
                    name: "Darko Meshkovski"
                },
                subject: null
            };

            $scope.createGroup = function() {
                GroupService.createGroup($scope.model)
                    .success(function(response) {
                        alert("DONE" + response);
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