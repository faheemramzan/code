(function () {
    angular.module('myApp')
    .factory('SharedService', ['$rootScope', 'CompanyService', function ($rootScope, companyService) {

        var broadcastUpdateCompaniesEvent = function () {
            $rootScope.$broadcast('UpdateCompaniesEvent');
        };

        var data = {
            companies: [],
            addCompany: function (company) {
                this.companies.push(company);
                broadcastUpdateCompaniesEvent();
            }
        };

        companyService.get().then(
            function (response) {
                data.companies = response.data;
                broadcastUpdateCompaniesEvent();
            },
            function (error) { }
        );

        return data;
    }]);

})();