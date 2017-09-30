module.exports = function (ngModule) {
    ngModule.config(['cfpLoadingBarProvider', "$httpProvider", function (cfpLoadingBarProvider, $httpProvider) {
        cfpLoadingBarProvider.includeSpinner = false;
    }
    ]);
};