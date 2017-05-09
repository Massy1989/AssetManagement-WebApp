// assetsController.js
(function () {

    "use strict";

    // Getting the existing module
    angular.module("app-applications")
        .controller("assetsController", assetsController);

    function assetsController($http) {
        var vm = this;

        //vm.assets = [{
        //    name: "AssetName",
        //    created: new Date()
        //}, {
        //    name: "Asset2Name",
        //    created: new Date()
        //}];

        vm.assets = [];

        vm.newAsset = {};

        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/assets")
            .then(function (response) {
                // Success
                angular.copy(response.data, vm.assets);
            }, function (error) {
                // Failure
                vm.errorMessage = "Failed to load data: " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });

        vm.addAsset = function () {
            //vm.assets.push({ name: vm.newAsset.name, created: new Date() });
            //vm.newAsset = {};

            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/assets", vm.newAsset)
                .then(function (response) {
                    // success
                    vm.assets.push(response.data)
                    vm.newAsset = {};
                }, function () {
                    // failure
                    vm.errorMessage = "Failed to save new asset"
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        };
    }
})();