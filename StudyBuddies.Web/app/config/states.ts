namespace StudyBuddies {
    class AppInitialStates {
        static $inject: Array<string> = ["$stateProvider", "$urlRouterProvider", "refsProvider"];

        constructor(public $stateProvider: angular.ui.IStateProvider,
            public $urlRouterProvider: angular.ui.IUrlRouterProvider,
            public refsProvider: IReferenceProvider) {
            this.$urlRouterProvider.otherwise("/");

            refsProvider.injectRef("$urlRouterProvider", $urlRouterProvider);
            refsProvider.injectRef("$stateProvider", $stateProvider);

            this.$stateProvider
                .state("app",
                {
                    url: "/",
                    abstract: true,
                    views: {
                        "header": {
                            controller: "HeaderController",
                            templateUrl: "app/common/layout/header/header.html"
                        },
                        "content": {
                            templateUrl: "app/common/layout/content.html"
                        },
                        "footer": {
                            controller: "FooterController",
                            templateUrl: "app/common/layout/footer/footer.html"
                        }
                    }
                });
        }
    }

    angular.module("study.buddies")
        .config(AppInitialStates);
}