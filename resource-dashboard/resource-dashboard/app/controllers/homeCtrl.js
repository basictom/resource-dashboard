app.controller("homeCtrl", ["$http", "$scope", "$uibModal", "tagsInputConfig", function ($http, $scope, $uibModal, tagsInputConfig) {
    const baseUrl = 'http://localhost:52185';

    $scope.categories = ["Javascript", "PHP", "MySQL", "C#", "HMTL", "CSS", ".NET", "Python"];
    $scope.resources = [];
    $scope.search = [];

    getResources();

    async function getResources() {
        await $http.get(baseUrl + "/api/resources").then((results) => {
            $scope.resources = results.data;
        });
    }

    $scope.openResource = (obj) => {
        $scope.obj = obj;

        $uibModal.open({
            templateUrl: 'show-resource-modal.html',
            resolve: {
                resObj: () => {
                    return $scope.obj = obj;
                }
            },
            controller: ($scope, $uibModalInstance, resObj) => {
                console.log(resObj);
                $scope.obj = resObj;
                $scope.ok = () => {
                    $uibModalInstance.close({
                        resource: this.obj
                    });
                };
            }
        });
    }




    $scope.openDialog = () => {

        $scope.resource = {};
        console.log($scope.resource);

        $uibModal.open({
            templateUrl: 'add-new-modal.html',
            resolve: {
                resource: () => {
                    return $scope.resource;
                    console.log($scope.resource);
                }
            },
            controller: ($scope, $uibModalInstance, resource) => {
                console.log(resource);
                $scope.resource = resource;
                $scope.searchTags = ($query) => {
                    return $http.get(baseUrl + '/api/resources/tags?query=' + $query).then((result) => {
                        console.log(result);
                        return result.data;
                    });
                };
                $scope.send = (val) => {
                    console.log("scoped values", val);

                    let tagArray = val.tags.map(x => Object.values(x));
                    let newArray = [].concat.apply([], tagArray);
                    let newObj = {
                        "Desc": val.Desc,
                        "Url": val.Url,
                        "Name": val.Name,
                        "category": val.category,
                        "tags": newArray
                    }
                    postResource(newObj);
                    $uibModalInstance.close({
                        resource: this.resource
                    });
                };
                $scope.cancel = () => {
                    $uibModalInstance.close({
                        resource: this.resource
                    });
                }
            }
        });
        //.result.then(function (response) {
        //let res = response.resource;

        // });


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
        console.log(vals.length);
        if (vals.length === 0) {
            return getResources();
        } else {
            let query = vals.map(x => x.text).join(',');
            $http.get(baseUrl + '/api/resources/bytagname?tags=' + query).then((result) => {
                $scope.resources = result.data;
            }).catch((error) => {
                console.log(error);
            })
        }
    }

}]);