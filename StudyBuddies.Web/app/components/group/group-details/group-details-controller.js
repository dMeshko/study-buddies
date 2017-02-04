module.exports = function(ngModule) {
    ngModule.controller("ViewGroupDetailsController", [
        "$scope", "$stateParams", "GroupService", function($scope, $stateParams, GroupService) {
            var groupId = $stateParams.id;
            $scope.group = {};
            GroupService.getGroupById(groupId)
                .success(function (data) {
                    $scope.group = data;
                })
                .error(function (response) {
                    $scope.parseErrorMessage(response);
                });
        }
    ]);
};