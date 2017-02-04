module.exports = function (ngModule) {
    ngModule.controller("ListGroupsController", [
        "$scope", "GroupService", "Helpers",
        function ($scope, GroupService, Helpers) {
            $scope.model = {
                user: {
                    id: "3F6E0CC2-020C-424E-B57C-7C9BDC427EF8"
                },
                group: {},
                status: {
                    id: 0
                }
            };

            $scope.groups = [];
            GroupService.getAllGroupsWhereNoRequestIsSent($scope.model.user.id)
                .success(function (response) {
                    $scope.groups = response;
                })
                .error(function (response) {
                    Helpers.parseErrorMessage(response);
                });

            $scope.joinGroup = function(groupId) {
                $scope.model.group.id = groupId;
                GroupService.sendGroupRequest($scope.model);
            };
        }]);
}