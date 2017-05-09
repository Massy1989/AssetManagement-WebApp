// graphingController.js
(function () {

    "use strict";

    //Getting the existing module
    angular.module("app")
        .controller("graphingController", graphingController);

    function graphingController($scope, $http) {
        var vm = $scope;
        //vm.myData = [];
        //vm.myChartOptions = {};

        vm.pieDataset = [];
        vm.pieOptions = {
            series: {
                pie: {
                    show: true,
                    radius: 1,
                    innerRadius: 0.2,
                    label: {
                        show: true,
                        radius: 2 / 3,
                        formatter: _labelFormatter,
                        threshold: 0.05
                    }
                }
            }
        }

        function _labelFormatter(label, series) {
            return "<div style='font-size:8pt; text-align:center; padding:2px; color:white;'>" + label + "<br/>" + Math.round(series.percent) + "%</div>";
        };

        vm.assetCounts = [];
        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/assets/quantity")
            .then(function (response) {
                // Success
                angular.forEach(response.data, function (resultObj, key) {
                    vm.pieDataset[key] = {
                        label: resultObj.assetType.description,
                        data: resultObj.quantity
                    }
                });
            }, function (error) {
                // Failure
                vm.errorMessage = "Failed to load data: " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });

        //var pieSeries = Math.floor(Math.random() * 6) + 3;

        //for (var i = 0; i < pieSeries; i++) {
        //    vm.pieDataset[i] = {
        //        label: 'Series' + (i + 1),
        //        data: Math.floor(Math.random() * 100) + 1
        //    };
        //}

    }
})();