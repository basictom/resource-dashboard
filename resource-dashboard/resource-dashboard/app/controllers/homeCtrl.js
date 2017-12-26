app.controller("homeCtrl", ["$http", "$scope", "$uibModal", "tagsInputConfig", function ($http, $scope, $uibModal, tagsInputConfig) {
    const baseUrl = 'http://localhost:52185';

    $scope.categories = ["Javascript", "PHP", "MySQL", "C#", "HMTL", "CSS", ".NET", "Python"];
    $scope.resources = [];
    $scope.search = [];

    getResources();

    async function getResources(){
        await $http.get(baseUrl + "/api/resources").then((results) => {
            $scope.resources = results.data;
            console.log($scope.resources.length);

            $scope.currentPage = 1;
            $scope.numPerPage = 10;
            $scope.maxSize = $scope.resources.length;

            $scope.$watch("currentPage + numPerPage", function () {
                var begin = (($scope.currentPage - 1) * $scope.numPerPage)
                    , end = begin + $scope.numPerPage;

                $scope.resources = $scope.resources.slice(begin, end);
            });

        });
    }

    
    

    $scope.openDialog = function () {

        $scope.resource = {};

        $uibModal.open({
            templateUrl: 'add-new-modal.html',
            resolve: {
                resource: function () {
                    console.log($scope.resource);
                    return $scope.resource;
                }
            },
            controller: function ($scope, $uibModalInstance, resource) {
                console.log(resource);
                $scope.resource = resource;
                $scope.searchTags = ($query) => {
                    return $http.get(baseUrl + '/api/resources/tags?query=' + $query).then((result) => {
                        console.log(result);
                        return result.data;
                    });
                };
                $scope.ok = function () {
                    $uibModalInstance.close({
                        resource: this.resource
                    });
                };
            }
        }).result.then(function (r) {
            var res = r.resource;
            const tagArray = res.tags.map(x => Object.values(x));
            let newArray = [].concat.apply([], tagArray);
            var newObj = {
                "Desc": res.Desc,
                "Url": res.Url,
                "Name": res.Name,
                "category": res.category,
                "tags": newArray
            }
            postResource(newObj);
        });


    };

    let postResource = (res) => {
        $http.post(baseUrl + '/api/resources', {
            ResourceName: res.Name,
            Description: res.Desc,
            Category: res.category,
            ResourceUrl: res.Url,
            TagNames: res.tags
        })
            .then(result => { getResources(); })
            .catch(error => { console.log(error) })
    }

    $scope.searchTags = ($query) => {
        return $http.get(baseUrl + '/api/resources/tags?query=' + $query).then((result) => {
            return result.data;
        });
    }

    $scope.searchForResources = () => {
        let vals = $scope.search;
        let query = vals.map(x => x.text).join(',');
        $http.get(baseUrl + '/api/resources/bytagname?tags=' + query).then((result) => {
            $scope.resources = result.data;
        }).catch((error) => {
            console.log(error);
        })
    }




    


}]);