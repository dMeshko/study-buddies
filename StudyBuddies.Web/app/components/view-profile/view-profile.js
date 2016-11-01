module.exports = function (ngModule) {
    ngModule.controller("ViewUserProfileController", ["$scope", function ($scope) {
        console.log("view it!");
    }
    ]);
};