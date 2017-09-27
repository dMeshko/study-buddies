namespace StudyBuddies {
    export interface IReferenceProvider extends angular.IServiceProvider {
        injectRef(name: string, ref: angular.ui.IUrlRouterProvider | angular.ui.IStateProvider): void;
    }

    export interface IReferenceProviderGetterInterface {
        get(name: string): angular.ui.IUrlRouterProvider | angular.ui.IStateProvider;
    }

    class ReferenceProvider implements IReferenceProvider {
        private refs: { [key: string]: angular.ui.IUrlRouterProvider | angular.ui.IStateProvider } = {};

        $get(): IReferenceProviderGetterInterface {
            return {
                get: (name: string): angular.ui.IUrlRouterProvider | angular.ui.IStateProvider => {
                    return this.refs[name];
                }
            };
        }

        injectRef(name: string, ref: angular.ui.IUrlRouterProvider | angular.ui.IStateProvider): void {
            this.refs[name] = ref;
        }
    }

    angular.module("study.buddies")
        .provider("refs", ReferenceProvider);
}