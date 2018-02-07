
app.service('CRUDService', function ($http) {
    //**********----Get Record----***************
    this.getAllCompanies = function (apiRoute) {
        return $http.get(apiRoute);
    }
});