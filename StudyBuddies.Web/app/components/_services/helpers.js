module.exports = function (ngModule) {
    ngModule.factory("Helpers", [
        "Notification",
        function (Notification) {
        var factory = {};

        factory.parseErrorMessage = function(response) {
            var errorMessages = "";

            if (typeof response === "string")
                errorMessages = response;
            else
                angular.forEach(response.modelState, function (value) {
                    errorMessages += "<p>" + value[0] + "</p>";
                });

            Notification.error({ message: errorMessages, title: "Please correct the following fields:"});
        };

        return factory;
    }]);
};