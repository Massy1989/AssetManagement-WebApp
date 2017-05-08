// assetsController.js
(function () {

    "use strict";

    // Getting the existing module
    angular.module("app-assets")
        .controller("assetsController", assetsController);

    function assetsController() {
        var vm = this;

        vm.assets = [{
            name: "AssetName",
            created: new Date()
        }, {
            name: "Asset2Name",
            created: new Date()
        }];

        vm.newAsset = {};

        vm.addAsset = function () {
            vm.assets.push({ name: vm.newAsset.name, created: new Date() });
            vm.newAsset = {};
        };


    }
})();