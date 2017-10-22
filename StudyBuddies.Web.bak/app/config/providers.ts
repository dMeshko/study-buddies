namespace StudyBuddies {
    interface IReferenceProviderGetter {
        get(name: string): angular.ui.IStateProvider;
    }    

    export interface IReferenceProvider extends angular.IServiceProvider, IReferenceProviderGetter {
        injectRef(name: string, ref: angular.ui.IUrlRouterProvider | angular.ui.IStateProvider): void;
        get(name: string): angular.ui.IStateProvider;
    }

    class ReferenceProvider implements IReferenceProvider {
        private refs: { [key: string]: angular.ui.IStateProvider } = {};

        $get(): IReferenceProviderGetter {
            return {
                get: (name: string): angular.ui.IStateProvider => {
                    return this.refs[name];
                }
            };
        }

        injectRef(name: string, ref: angular.ui.IStateProvider): void {
            this.refs[name] = ref;
        }

        get(name: string): angular.ui.IStateProvider {
            return this.refs[name];
        }
    }

    angular.module("study.buddies")
        .provider("refs", ReferenceProvider);
}