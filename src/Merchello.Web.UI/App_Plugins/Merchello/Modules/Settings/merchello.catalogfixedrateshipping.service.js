﻿(function (merchelloServices, undefined) {


    /**
        * @ngdoc service
        * @name umbraco.resources.MerchelloCatalogFixedRateShippingService
        * @description Loads in data for shipping providers and store shipping settings
        **/
    merchelloServices.MerchelloCatalogFixedRateShippingService = function ($http, umbRequestHelper) {

        return {

            getAllShipCountryRateTableProviders: function (id) {

                return umbRequestHelper.resourcePromise(
                   $http({
                       url: umbRequestHelper.getApiUrl('merchelloCatalogRateTableShippingApiBaseUrl', 'GetAllShipCountryRateTableProviders'),
                       method: "GET",
                       params: { id: id }
                   }),
                   'Failed to retreive shipping rate table providers');
            },

            createRateTableShipMethod: function (rateTableShipMethod) {

                return umbRequestHelper.resourcePromise(
                    $http.post(umbRequestHelper.getApiUrl('merchelloCatalogRateTableShippingApiBaseUrl', 'AddRateTableShipMethod'),
                        rateTableShipMethod
                    ),
                    'Failed to create rateTableShipMethod');
            },

            saveRateTableShipMethod: function (rateTableShipMethod) {

                return umbRequestHelper.resourcePromise(
                    $http.post(umbRequestHelper.getApiUrl('merchelloCatalogRateTableShippingApiBaseUrl', 'PutRateTableShipMethod'),
                        rateTableShipMethod
                    ),
                    'Failed to savw rateTableShipMethod');
            },

        };
    }

    angular.module('umbraco.resources').factory('merchelloCatalogFixedRateShippingService', merchello.Services.MerchelloCatalogFixedRateShippingService);

}(window.merchello.Services = window.merchello.Services || {}));