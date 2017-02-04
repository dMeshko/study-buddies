module.exports = function(ngModule) {
    require("./providers")(ngModule);
    require("./config")(ngModule);
    require("./states")(ngModule);
    require("./run")(ngModule);
};