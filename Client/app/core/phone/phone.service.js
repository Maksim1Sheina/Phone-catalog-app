'use strict';

angular.
    module('core.phone').
    factory('Phone', ['$resource',
        function($resource){
            return $resource('http://localhost:4871/api/:phoneId', {}, {
                query: {
                    method: 'GET',
                    params: {phoneId: 'Phones'},
                    isArray: true
                },
                
                save: {
                    method: 'POST',
                    params: {phoneId: 'Phones'}
                },
                
                uploadphoto: {
                    method: 'POST',
                    params: {phoneId: 'Phones/Upload'},
                    headers: { 'Content-Type': undefined }
                },
                
                update: {
                    method: 'PUT',
                    params: {phoneId: 'Phones'}
                }
            });
        }
]);