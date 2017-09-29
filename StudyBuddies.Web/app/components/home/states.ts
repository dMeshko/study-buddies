/// <reference path="../../config/providers.ts" />

namespace StudyBuddies {
    class HomeStates {
        static $inject: Array<string> = ["refs"];

        private $stateProvider: angular.ui.IStateProvider;

        constructor(refs: IReferenceProvider) {
            this.$stateProvider = refs.get("$stateProvider");

            this.$stateProvider
                .state("app.home",
                {
                    url: "", // empty string for "app" state to override the / abstract state
                    views: {
                        "left@app": {
                            templateUrl: "app/components/home/left-sidebar/left-sidebar.html",
                            controller: "LeftSidebarController"
                        },
                        "main@app": {
                            templateUrl: "app/components/home/main/home.html",
                            controller: "HomeController"
                        },
                        "right@app": {
                            templateUrl: "app/components/home/right-sidebar/right-sidebar.html",
                            controller: "RightSidebarController"
                        }
                    }
                });
        }
    }

    angular.module("study.buddies")
        .run(HomeStates);
}