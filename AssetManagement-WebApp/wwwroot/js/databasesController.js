// applicationsController.js
(function () {

    "use strict";

    // Getting the existing module
    angular.module("app")
        .controller("dataController", dataController);
    angular.module("app")
        .controller("paginationController", paginationController);

    function dataController($scope, $http) {
        var vm = $scope;

        vm.currentPage = 1;
        vm.pageSize = 10;

        vm.assets = [];

        vm.newAsset = {};

        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/assets?type=Database")
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
            //vm.assets.push({ name: vm.newAsset.name, created: new Date() });a

            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/assets", vm.newAsset)
                .then(function (response) {
                    // success
                    //vm.assets.push(response.data)
                    vm.assets.push("This is a test");
                    vm.newAsset = {};
                }, function () {
                    // failure
                    vm.errorMessage = "Failed to save new asset"
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        };

        vm.pageChangeHandler = function (num) {
            console.log('assets page changed to ' + num);
        };
    }

    function paginationController($scope) {
        var vm = this;
        vm.pageChangeHandler = function (num) {
            console.log('going to page ' + num);
        };
    }
})();