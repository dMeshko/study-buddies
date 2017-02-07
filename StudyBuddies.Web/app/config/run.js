module.exports = function (ngModule) {
    ngModule.run(["$rootScope", "Helpers", function ($rootScope, Helpers) {
        $rootScope.parseErrorMessage = function (data) {
            Helpers.parseErrorMessage(data);
        }

        $rootScope.currentUser = {
            id: "33CA1AB3-3AFC-4308-9179-A71101711844",
            name: "Darko Meshkovski"
        };
    }
    ]);
};