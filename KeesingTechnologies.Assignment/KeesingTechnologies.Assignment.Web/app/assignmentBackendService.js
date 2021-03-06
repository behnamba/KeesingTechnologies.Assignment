﻿"use strict";

angular.module("assignmentApp")
    .factory("assignmentBackendService", ["$http", function ($http) {
        var catBackendService = {};

        $http.defaults.headers.post["Content-Type"] = "application/json; charset=utf-8";

        catBackendService.getDocuments = function (canceler) {
            return $http.get("v1/document/get", {
                params: {
                }, withCredentials: true, timeout: canceler.promise
            });
        }

        catBackendService.getDocumentsDetails = function (documentId, canceler) {
            return $http.get("v1/document/get/" + documentId, {
                params: {
                }, withCredentials: true, timeout: canceler.promise
            });
        }

        //catBackendService.sendPayment = function (canceler, payment) {
        //    // return $http.post("v1/payment", { model: payment });
        //    return $http({
        //        //Content-Type: 'application/json',
        //        url: 'v1/payment/SendPayment',
        //        method: "POST",
        //        data: { 'Description': payment.Description, 'Status': payment.Status, 'ProductId': payment.ProductId, 'CreatedDate': payment.CreatedDate, 'Price': payment.Price, 'ProductTagId': payment.ProductTagId }
        //    });
        //}

        return catBackendService;
    }]);