
app.controller('ProductsCtrl', ['$scope', 'CRUDService', 'uiGridConstants',
    function ($scope, CRUDService, uiGridConstants) {
        $scope.gridOptions = [];

        //Pagination
        $scope.pagination = {
            paginationPageSizes: [15, 25, 50, 75, 100, "All"],
            ddlpageSize: 15,
            pageNumber: 1,
            pageSize: 15,
            totalItems: 0,

            getTotalPages: function () {
                return Math.ceil(this.totalItems / this.pageSize);
            },
            pageSizeChange: function () {
                if (this.ddlpageSize == "All")
                    this.pageSize = $scope.pagination.totalItems;
                else
                    this.pageSize = this.ddlpageSize

                this.pageNumber = 1
                $scope.GetAllCompanies();
            },
            firstPage: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber = 1
                    $scope.GetAllCompanies();
                }
            },
            nextPage: function () {
                if (this.pageNumber < this.getTotalPages()) {
                    this.pageNumber++;
                    $scope.GetAllCompanies();
                }
            },
            previousPage: function () {
                if (this.pageNumber > 1) {
                    this.pageNumber--;
                    $scope.GetAllCompanies();
                }
            },
            lastPage: function () {
                if (this.pageNumber >= 1) {
                    this.pageNumber = this.getTotalPages();
                    $scope.GetAllCompanies();
                }
            }
        };

        //ui-Grid Call
        $scope.GetAllCompanies = function () {
            $scope.loaderMore = true;
            $scope.lblMessage = 'loading please wait....!';
            $scope.result = "color-green";

            $scope.highlightFilteredHeader = function (row, rowRenderIndex, col, colRenderIndex) {
                if (col.filters[0].term) {
                    return 'header-filtered';
                } else {
                    return '';
                }
            };
            $scope.gridOptions = {
                useExternalPagination: true,
                useExternalSorting: true,
                enableFiltering: true,
                enableSorting: true,
                enableRowSelection: true,
                enableSelectAll: true,
                enableGridMenu: true,

                columnDefs: [
                    { name: "CompanyID", displayName: "Company ID", width: '10%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CompanyName", title: "Company Name", width: '30%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CompanyAddress", title: "Company Address", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "CompanyPhoneNumber", title: "Company Phone #", width: '20%', headerCellClass: $scope.highlightFilteredHeader },
                    { name: "IsActive", title: "Is Company Active", width: '10%', headerCellClass: $scope.highlightFilteredHeader }
                ],
                exporterAllDataFn: function () {
                    return getPage(1, $scope.gridOptions.totalItems, paginationOptions.sort)
                    .then(function () {
                        $scope.gridOptions.useExternalPagination = false;
                        $scope.gridOptions.useExternalSorting = false;
                        getPage = null;
                    });
                },
            };

            var NextPage = (($scope.pagination.pageNumber - 1) * $scope.pagination.pageSize);
            var NextPageSize = $scope.pagination.pageSize;
            var apiRoute = 'GetAllCompanies';
            var result = CRUDService.getAllCompanies(apiRoute);
            result.then(
                function (response) {
                    $scope.pagination.totalItems = response.data.recordsTotal;
                    $scope.gridOptions.data = response.data.companyList;
                    $scope.loaderMore = false;
                },
            function (error) {
                console.log("Error: " + error);
            });
        }

        //Default Load
        $scope.GetAllCompanies();

        //Selected Call
        $scope.GetByID = function (model) {
            $scope.SelectedRow = model;
        };
    }
]);