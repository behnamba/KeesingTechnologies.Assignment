"use strict";

angular.module("assignmentApp").controller("assignmentMainController", ["$scope", "$q", "$log", "$filter", "assignmentBackendService",
        function ($scope, $q, $log, $filter, assignmentBackendService) {
            var main = this;
            main.title = "Keesing Technologies Assignment :-)";

            // to optimize the performance of the request 
            var documentCanceler = $q.defer();
            var documentDetailsCanceler = $q.defer();
            var postDocumentsCanceler = $q.defer();

            // show loading 
            main.documentLoading = true;

            // to handel showing the order list
            main.documentSelected = false;

            // customer grid config
            main.dcoumentGridOptions = {
                data: null,
                enableRowHeaderSelection: false,
                multiSelect: false,
                onRegisterApi: function (gridApi) {
                    gridApi.selection.on.rowSelectionChanged(null, function (row) {
                        // show order list
                        main.documentSelected = true;

                        // load Order data
                        loadDocumentDetails(row.entity.Id);
                    });
                }
            };

            // load customers
            assignmentBackendService.getDocuments(documentCanceler)
                .success(function (data) {
                    main.dcoumentGridOptions.data = data;
                    main.documentLoading = false;
                })
                .error(function (data) {
                    alert(data.Message);
                    main.documentLoading = false;
                });

            function loadDocumentDetails(documentId) {
                // show loading 
                main.documentDetailsLoading = true;

                assignmentBackendService.getDocumentsDetails(documentId, documentDetailsCanceler)
                .success(function (data) {
                    main.selectedDocument = data;
                    main.documentDetailsLoading = false;
                })
                .error(function (data) {
                    alert(data.Message);
                    main.documentDetailsLoading = false;
                });
            }

            $scope.$on('$destroy', function () {
                documentCanceler.resolve();
                documentDetailsCanceler.resolve();
                postDocumentsCanceler.resolve();
            });
        }]);
