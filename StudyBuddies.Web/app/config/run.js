module.exports = function (ngModule) {
    ngModule.run(["$rootScope", "Helpers", function ($rootScope, Helpers) {
        $rootScope.parseErrorMessage = function (data) {
            Helpers.parseErrorMessage(data);
        }

        $rootScope.currentUser = {
            //id: "2F27D7B7-B62E-4E00-B5DD-A71500019A2C",
            id: "DB69A5E9-2537-47CC-8151-A714018A667E",
            //id: "70FE7E5A-42BD-4BBB-B6F4-A714018ABD53",
            name: "Darko Meshkovski"
        };
    }
    ]);
};