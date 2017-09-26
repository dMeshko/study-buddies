namespace StudyBuddies {
    export let refs: { [key: string]: angular.ui.IUrlRouterProvider | angular.ui.IStateProvider } = {};

    export interface IReferenceProvider extends angular.IServiceProvider {
        injectRef(name: string, ref: angular.ui.IUrlRouterProvider | angular.ui.IStateProvider): void;
    }

    export interface IReferenceProviderGetterInterface {
        get(name: string): angular.ui.IUrlRouterProvider | angular.ui.IStateProvider;
    }

    class ReferenceProvider implements IReferenceProvider {
        $get(): IReferenceProviderGetterInterface {
            return {
                get: (name: string): angular.ui.IUrlRouterProvider | angular.ui.IStateProvider => {
                    return refs[name];
                }
            };
        }

        injectRef(name: string, ref: angular.ui.IUrlRouterProvider | angular.ui.IStateProvider): void {
            refs[name] = ref;
        }
    }

    angular.module("study.buddies")
        .provider("refs", ReferenceProvider);
}