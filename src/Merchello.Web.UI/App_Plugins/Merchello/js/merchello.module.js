﻿// Bootstrap the Merchello angular module
(function() {
    angular.module('merchello', [
        'umbraco.filters',
        'umbraco.directives',
        'umbraco.services',
        'merchello.filters',
        'merchello.directives',
        'merchello.reports',
        'merchello.resources',
        'merchello.services'
    ]);
    angular.module('merchello.models', []);
    angular.module('merchello.filters', []);
    angular.module('merchello.directives', []);
    angular.module('merchello.resources', []);
    angular.module('merchello.services', ['merchello.models']);
    angular.module('merchello.reports', ['merchello.models', 'merchello.resources'])
    //// Assert our dependencies
    angular.module('umbraco.packages').requires.push('merchello');

}());

