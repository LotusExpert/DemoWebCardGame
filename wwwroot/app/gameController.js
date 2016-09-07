(function () {
    'use strict';

    var controllerId = 'gameController';

    angular.module('GameApp').controller(controllerId,['$scope','$http', gameController]);

    function gameController($scope, $http) {
        $scope.decks = [];
        
        $scope.getDecks = function() {
            $http.get('/api/decks').success(function(data) {
                $scope.decks = data;
            }).error(function(error) {
                console.log(error);
            });
        }

        $scope.shuffleDeck = function(index) {
            $http.get('/api/shuffledeck?deckindex=' + index).success(function(data){
                $scope.getDecks();
            }).error(function(error){
                console.log(error);
            });
        }

        $scope.addDeck = function() {
            $http.get('/api/adddeck').success(function (data) {
                $scope.getDecks();
            }).error(function(error){
                console.log(error);
            });
        };

        $scope.removeDeck = function(index) {
            $http.get('/api/removedeck?deckindex=' + index).success(function (data) {
                $scope.getDecks();
            }).error(function(error){
                console.log(error);
            });
        };

        $scope.sortDeck = function(index) {
           $http.get('/api/sortdeck?deckindex=' + index).success(function (data) {
                $scope.getDecks();
            }).error(function(error){
                console.log(error);
            });
        };

        $scope.discardCard = function(index) {
            $http.get('/api/discard?deckindex=' + index).success(function (data) {
                $scope.getDecks();
            }).error(function(error){
                console.log(error);
            });
        };

        $scope.getDecks();
    }
})();

