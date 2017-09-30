module.exports = function (ngModule) {
    ngModule.run(["$rootScope", "Helpers", function ($rootScope, Helpers) {
        $rootScope.parseErrorMessage = function (data) {
            Helpers.parseErrorMessage(data);
        }

        $rootScope.currentUser = {
            //id: "2F27D7B7-B62E-4E00-B5DD-A71500019A2C",
            //id: "a3d62a43-84a3-460a-8a03-a7a3011e696b",
            id: "d349f94a-a002-49e3-8618-2be0768e0f83",
            //id: "70FE7E5A-42BD-4BBB-B6F4-A714018ABD53",
            name: "Darko Meshkovski"
        };
    }
    ]);
};