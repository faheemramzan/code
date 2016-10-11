(function () {
    angular.module('myApp')
    .service('PersonService', ['$http', function ($http) {
        this.get = function () {
            return $http.get('/api/persons');
        };

        this.add = function (person) {
            var request = $http({
                method: "post",
                url: "/api/persons/add",
                data: person
            });
            return request;
        }
    }]);

})();