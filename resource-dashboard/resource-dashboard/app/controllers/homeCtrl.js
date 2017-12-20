﻿app.controller("homeCtrl", ["$http", "$scope", "$uibModal", function ($http, $scope, $uibModal) {
    var baseUrl = 'http://localhost:52185';

    $scope.categories = ["Javascript", "PHP", "MySQL", "C#", "HMTL", "CSS", ".NET", "Python"];

    let getResources = () => {
        $http.get(baseUrl + "/api/resources").then((results) => {
            $scope.resources = results.data;
        });
    }

    getResources();

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
                "tags" : newArray
            }
            console.log(newObj);
            postResource(newObj);
        });


    };

    let postResource = (res) => {
        console.log(res.tags);
        $http.post(baseUrl + '/api/resources', {
            ResourceName: res.Name,
            Description: res.Desc,
            Category: res.category,
            ResourceUrl: res.Url,
            TagNames: res.tags
        })
            .then(result => { getResources(); console.log(result) })
            .catch(error => { console.log(error) })
    }

}]);