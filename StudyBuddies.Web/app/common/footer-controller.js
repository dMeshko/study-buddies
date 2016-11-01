module.exports = function(ngModule) {
    ngModule.controller("FooterController", ["$scope", "SITE_NAME", function ($scope, SITE_NAME) {
        $scope.currentYear = new Date().getFullYear();
        $scope.siteName = SITE_NAME;
    }]);
};