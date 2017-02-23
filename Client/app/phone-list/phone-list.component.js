'use strict';

angular.
    module('phoneList').
    component('phoneList', {
        templateUrl: 'phone-list/phone-list.template.html',
        controller: ['Phone',
            function PhoneListController(Phone){
                var self = this;
                self.loading = true;
				
                Phone.query().$promise.then(function (phones) { 
                    self.phones = phones;
                    self.loading = false;
					
						// Разбиение на страницы в контроллере
					self.currentPage = 0; 
					self.pageSize = 5;
					self.setCurrentPage = function(currentPage) {
						self.currentPage = currentPage;
					}

					self.getNumberAsArray = function (num) {
						return new Array(num);
					};

					self.numberOfPages = function() {
						return Math.ceil(self.phones.length / self.pageSize);
					};
					
                }).catch(function(error){
                    alert('Server error. Update page or try again later.');
                }).finally(function() {
                    self.loading = false;
                });
				
                this.orderProp = 'ID';
            }
        ]
});