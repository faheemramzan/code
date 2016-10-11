(function () {

    angular.module('myApp')
    .controller('personsController', ['$scope', '$rootScope', 'SharedService', 'PersonService', function ($scope, $rootScope, sharedService, personService) {

        $scope.personSharedService = sharedService;
        $scope.persons = [];
        $scope.selectedCompanyFilter = null;

        var isPersonsLoaded = false;

        $scope.noCustomerFilter = { Key: null, Name: 'Välj' };
        var updateCompanies = function (customers) {
            $scope.companies = [$scope.noCustomerFilter].concat(customers);
        }

        updateCompanies([]);

        $rootScope.$on('UpdateCompaniesEvent', function () {
            updateCompanies(sharedService.companies);

            if (isPersonsLoaded) {
                return;
            }

            personService.get().then(
                function (response) {
                    isPersonsLoaded = true;
                    $scope.persons = response.data;
                },
                function (error) { }
            );
        });        

        var initNewPerson = function () {
            $scope.newPerson = { Key: null, Name: '', CompanyKey: null };
        };

        initNewPerson();

        $scope.add = function () {

            if ($.trim($scope.newPerson.Name)=='') {
                alert('Ange namn');
                return;
            }

            $scope.newPerson.CompanyKey = $scope.newPersonCompany.Key;           

            personService.add($scope.newPerson).then(
                function (response) {
                    $scope.persons.push(response.data);
                    initNewPerson();
                    $scope.newPersonCompany = $scope.noCustomerFilter;
                },
                function (error) { }
            );

            return false;
        };

        $scope.getCompanyName = function (companyKey) {
            if (!companyKey) {
                return '';
            }

            return $.grep($scope.companies, function (company) { return company.Key == companyKey; })[0].Name;
        };

        $scope.setSelectedCompanyFilter = function (company) {
            $scope.selectedCompanyFilter = company;
        };

        $scope.personsFilter = function (company) {
            return function (person) {
                if (!company || !company.Key) {
                    return true;
                }
                return person.CompanyKey == company.Key;
            }
        };

        $rootScope.$on('ShowPersonsEvent', function (event, company) {
            $scope.selectedCompany = company;
            $scope.setSelectedCompanyFilter(company);

            $('.nav-tabs a[href="#tab-persons"]').tab('show');
        });

    }]);
    
})();