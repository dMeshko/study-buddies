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
                if (response.hasOwnProperty("modelState"))
                    angular.forEach(response.modelState, function (value) {
                        errorMessages += "<p>" + value[0] + "</p>";
                    });
                else
                    angular.forEach(response, function (value) {
                        errorMessages += "<p>" + value + "</p>";
                    });

            Notification.error({ message: errorMessages, title: "Please correct the following fields:"});
        };

        return factory;
    }]);
};