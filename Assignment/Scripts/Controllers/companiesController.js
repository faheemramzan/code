(function () {
    angular.module('myApp')
    .controller('companiesController', ['$scope', '$rootScope', 'SharedService', 'CompanyService', function ($scope, $rootScope, sharedService, companyService) {
        
        $scope.sharedService = sharedService;
        $scope.companies = sharedService.companies;
        

        $rootScope.$on('UpdateCompaniesEvent', function () {
            $scope.companies = sharedService.companies;
        });        

        var initNewCompany = function () {
            $scope.newCompany = { Key: null, Name: '' };
        };

        initNewCompany();

        $scope.add = function () {            

            if ($.trim($scope.newCompany.Name) == '') {
                alert('Ange namn');
                return;
            }

            companyService.add($scope.newCompany).then(
                function (response) {
                    sharedService.addCompany(response.data)
                    initNewCompany();
                },
                function (error) { }
            );

            return false;
        };

        $scope.showPersons = function (company) {
            $rootScope.$broadcast('ShowPersonsEvent', company);
        };

    }]);

})();