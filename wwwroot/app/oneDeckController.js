(function () {
    'use strict';

    var controllerId = 'oneDeckController';

    angular.module('GameApp').controller(controllerId,['$scope','$http', oneDeckController]);

    function oneDeckController($scope, $http) {
        $scope.deck = [];

        $scope.getOneDeck = function() {
            $http.get('/api/onedeck/list').success(function(data) {
                $scope.deck = data.deck;
                console.log($scope.deck);
            }).error(function(error) {
                console.log(error);
            });
        }

        $scope.shuffleOneDeck = function() { 
            $http.get('/api/onedeck/shuffle').success(function(data) {
                $scope.getOneDeck();
            }).error(function(error){
                console.log(error);
            });
        };

        $scope.sortOneDeck = function() {
            $http.get('/api/onedeck/sort').success(function(data){
                $scope.getOneDeck();
            }).error(function(error){
                console.log(error);
            });
        }
        $scope.getOneDeck();

        }
})();