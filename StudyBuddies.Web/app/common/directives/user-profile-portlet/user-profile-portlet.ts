namespace StudyBuddies {
    class UserProfilePortletDirective implements angular.IDirective {
        static instance(): angular.IDirective {
            return new UserProfilePortletDirective();
        }

        restrict: string = "E";
        templateUrl: string | ((tElement: JQLite, tAttrs: Object) => string) = "app/common/directives/user-profile-portlet/user-profile-portlet.html";
        link: angular.IDirectiveLinkFn = (scope: angular.IScope, element: JQLite, attributes: angular.IAttributes): void => {

        };
    }

    angular.module("study.buddies")
        .directive("userProfilePortlet", UserProfilePortletDirective.instance);
}