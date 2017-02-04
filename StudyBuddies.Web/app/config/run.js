module.exports = function (ngModule) {
    ngModule.run(["$rootScope", "Helpers", function ($rootScope, Helpers) {
        $rootScope.parseErrorMessage = function (data) {
            Helpers.parseErrorMessage(data);
        }

        $rootScope.currentUser = {
            id: "50C308F7-E2E5-4529-8BA8-A700017C712D",
            name: "Darko Meshkovski"
        };
    }
    ]);
};