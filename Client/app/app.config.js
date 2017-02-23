'use strict';

angular.
    module('phonecatApp').
    config(['$locationProvider', '$routeProvider',
           function config($locationProvider, $routeProvider){
               $locationProvider.hashPrefix('!');
               
               $routeProvider.
                    when('/phones', {
                        template: '<phone-list></phone-list>'
               }).
                    when('/phones/add', {
                        template: '<phone-add></phone-add>'
               }).
                    when('/phones/edit/:phoneId', {
                        template: '<phone-edit></phone-edit>'
               }).   
                    when('/phones/:phoneId', {
                        template: '<phone-detail></phone-detail>'
               }).                    
                    otherwise('/phones');
           }
    ]);