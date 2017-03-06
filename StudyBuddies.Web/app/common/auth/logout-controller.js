module.exports = function (ngModule) {
    ngModule.controller("LogoutController", ["$state", "$rootScope", function ($state, $rootScope) {
        $rootScope.currentUser = {};
        $state.go("app.login");
    }]);
}