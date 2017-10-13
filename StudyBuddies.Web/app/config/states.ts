/// <reference path="providers.ts" />

namespace StudyBuddies {
    class AppInitialStates {
        static $inject: Array<string> = ["$stateProvider", "$urlRouterProvider", "$locationProvider", "refsProvider"];

        constructor(public $stateProvider: angular.ui.IStateProvider,
            public $urlRouterProvider: angular.ui.IUrlRouterProvider,
            public $locationProvider: angular.ILocationProvider,
            public refsProvider: IReferenceProvider) {
            // default url
            this.$urlRouterProvider.otherwise("/");

            // use the HTML5 History API
            this.$locationProvider.html5Mode(true);

            refsProvider.injectRef("$stateProvider", $stateProvider);
            this.$stateProvider
                .state("app",
                    {
                        url: "/",
                        abstract: true,
                        views: {
                            "header": {
                                controller: "HeaderController",
                                controllerAs: "vm",
                                templateUrl: "app/common/layout/header/header.html"
                            },
                            "content": {
                                templateUrl: "app/common/layout/content.html"
                            },
                            "footer": {
                                controller: "FooterController",
                                controllerAs: "vm",
                                templateUrl: "app/common/layout/footer/footer.html"
                            }
                        }
                    });
        }
    }

    angular.module("study.buddies")
        .config(AppInitialStates);
}