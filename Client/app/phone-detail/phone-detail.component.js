'use strict';

angular.
    module('phoneDetail').
    component('phoneDetail', {
        templateUrl: 'phone-detail/phone-detail.template.html',
        controller: ['$routeParams', 'Phone',
            function PhoneDetailController($routeParams, Phone){
                var self = this;
                self.loading = true;
				
				self.phoneEditID = $routeParams.phoneId;
                
                Phone.get({phoneId: 'Phones/' + $routeParams.phoneId})
                .$promise.then(function (phone) { 
                    self.setImage(phone.Images[0]);
                    self.phone = phone;
                    self.loading = false;
                }).catch(function(error){
                    alert('Server error. Update page or try again later.');
                }).finally(function() {
                    self.loading = false;
                });
                
                self.setImage = function setImage(imageUrl){
                    self.mainImageUrl = imageUrl;
                };
                
                self.onDblclick = function onDblclick(imageUrl){
                    alert('You double-clicked image: ' + imageUrl);
                };
            }
        ]
});