namespace StudyBuddies {
    export let refs: { [key: string]: angular.ui.IUrlRouterProvider | angular.ui.IStateProvider } = {};

    class ReferenceProvider implements angular.IServiceProvider {
        $get() {
            return {
                get(name: string) {
                    return refs[name];
                }
            };
        }

        injectRef(name: string, ref: angular.ui.IUrlRouterProvider | angular.ui.IStateProvider) {
            refs[name] = ref;
        }
    }

    angular.module("study.buddies").provider("refs", ReferenceProvider);
}