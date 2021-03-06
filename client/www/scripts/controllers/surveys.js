'use strict';

/**
 * @ngdoc function
 * @name TeamVSurveyClient.controller:SurveyCtrl
 * @description
 * # SurveyCtrl
 * Controller of the TeamVSurveyClient
 */
angular.module('TeamVSurveyClient')
  .controller('SurveysCtrl', ['$scope', '$location', 'SurveySingleton',
    function ($scope, $location, SurveySingleton) {
			console.log('About to call getSurveys()');

      function getSurveys() {
        SurveySingleton.list().then(function(data){
           $scope.surveys = data.data;
           console.log(data);
         });
      }

          //.success(function (surveys) {
          //  $scope.surveys = surveys;
          //  console.log($scope.surveys);
          //})
          //.error(function (error) {
          //  console.log(error);
          //});
      //}

      getSurveys();

      $scope.goSurvey = function(survey){
        console.log('going to survey');
        console.log(survey);
        console.log('#/survey/' + survey.Id);

        $location.path('/survey/' + survey.Id);
      };

		}
	]);
