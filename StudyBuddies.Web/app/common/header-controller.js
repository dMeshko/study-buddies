module.exports = function(ngModule) {
    ngModule.controller("HeaderController", ["$scope", "SITE_NAME", function ($scope, SITE_NAME) {
        $scope.siteName = SITE_NAME;
    }]);
}