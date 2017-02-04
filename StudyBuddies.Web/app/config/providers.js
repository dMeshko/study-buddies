module.exports = function (ngModule) {
    var refs = {};

    ngModule.provider("refs", function () {
        this.$get = function() {
            return {
                get: function(name) {
                    return refs[name];
                }
            };
        };

        this.injectRef = function (name, ref) {
            refs[name] = ref;
        };
    });
};