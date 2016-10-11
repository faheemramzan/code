(function () {
    angular.module('myApp')
    .service('CompanyService', ['$http', function ($http) {
        this.get = function () {
            return $http.get('/api/companies');
        };

        this.add = function (company) {
            var request = $http({
                method: "post",
                url: "/api/companies/add",
                data: company
            });
            return request;
        }
    }]);

})();