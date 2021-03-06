'use strict';

/**
 * @ngdoc function
 * @name TeamVSurveyClient.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the TeamVSurveyClient
 */
angular.module('TeamVSurveyClient')
  .controller('CompleteCtrl', ['$scope', '$location', 'SurveySingleton', '$routeParams',
    function ($scope, $location, SurveySingleton, $routeParams) {

      function getSurvey() {
        console.log('Loading surveys');
        SurveySingleton.list().then(function (data) {
          $scope.surveys = data.data;

          console.log($scope.surveys);

          var survey = {};
          console.log('Searching for survey [' + $routeParams.survey_id + '] in surveys ' + $scope.surveys.length);
          angular.forEach($scope.surveys, function(item){
            if (item.Id == $routeParams.survey_id) {
              $scope.questionnaire = item;
              console.log('Found questionnaire' + $scope.questionnaire);
            }
          });
        });
      }

      getSurvey();

      $scope.okay = function () {
        $location.path('/survey/' + $routeParams.survey_id);
      }

    }
  ]);
