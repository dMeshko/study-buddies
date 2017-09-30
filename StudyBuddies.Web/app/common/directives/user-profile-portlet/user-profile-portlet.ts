namespace StudyBuddies {
    function userProfilePortlet(): angular.IDirective {
        return {
            restrict: "E",
            templateUrl: "app/common/directives/user-profile-portlet/user-profile-portlet.html",
            link: (scope: angular.IScope, element: JQLite, attributes: angular.IAttributes): void => {
                
            }
        };
    }

    angular.module("study.buddies")
        .directive("userProfilePortlet", userProfilePortlet);
}