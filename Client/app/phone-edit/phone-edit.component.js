'use strict';

angular.
    module('phoneEdit')
    .component('phoneEdit', {
        templateUrl: 'phone-edit/phone-edit.template.html',
        controller: ['$scope', '$http', '$routeParams', 'Phone',
            function PhoneEditController($scope, $http, $routeParams, Phone){
                var self = this;
                self.loading = true;
                
                Phone.get({phoneId: 'Phones/' + $routeParams.phoneId})
                .$promise.then(function (phone) { 
                    self.phone = phone;
                    self.loading = false;
                }).catch(function(error){
                    alert('Server error. Update page or try again later.');
                }).finally(function() {
                    self.loading = false;
                });
                
                self.removeImage = function removeImage(imageUrl){
                    for(var i = 0; i < self.phone.Images.length; i++){
                        if(self.phone.Images[i].localeCompare(imageUrl) == 0){
                            self.phone.Images.splice(i,1);
                        }
                    }
                };
                
                self.somefunc = function (){
                    var output = '<b> Image for uploading: </b>';
                    
                    for (var value of self.formdata.values()) {
                        output += '<li>' + value.name + '</li>';
                    }
                    
                    document.getElementById('result').innerHTML = output;
                };
                
                self.getTheFiles = function ($files) {
                    self.formdata = new FormData();
                    angular.forEach($files, function (value, key) {
                        self.formdata.append(key, value);
                    });
                    self.somefunc();
                };
                
                self.clearField = function clearField(id){
                    if(document.getElementById(id).value == 'No data'){
                        document.getElementById(id).value = '';
                    }                    
                };

                
                self.uploadFiles = function () {
                    self.loading = true;
                    $http({
                        method: 'POST',
                        url: 'http://localhost:4871/api/Phones/Upload',
                        data: self.formdata,
                        headers: {
                            'Content-Type': undefined
                        }
                    }).success(function(response){
                        self.phone.Images = response.concat(self.phone.Images);
                        document.getElementById('result').innerHTML = '';
                        self.loading = false;
                    }).error(function(response){
                        alert('Server error. Update page or try again later. ');
                        self.loading = false;
                    });
                };              
                
                self.btnClick = function btnClick(){
                    self.loading = true;
                    
                    var outData = new Phone();
                    outData.ID = $routeParams.phoneId;
                    outData.Name = self.phone.Name;
                    outData.Description = self.phone.Description;
                    outData.Availabilities = self.phone.Availabilities;
                    outData.BatteryType = self.phone.BatteryType;
                    outData.BatteryTalkTime = self.phone.BatteryTalkTime;
                    outData.BatteryStandbyTime = self.phone.BatteryStandbyTime;
                    outData.StorageRAM = self.phone.StorageRAM;
                    outData.StorageFlash = self.phone.StorageFlash;
                    outData.ConnectivityCell = self.phone.ConnectivityCell;
                    outData.ConnectivityWiFi = self.phone.ConnectivityWiFi;
                    outData.ConnectivityBluetooth = self.phone.ConnectivityBluetooth;
                    outData.ConnectivityInfrared = self.phone.ConnectivityInfrared;
                    outData.ConnectivityGPS = self.phone.ConnectivityGPS;
                    outData.PlatformType = self.phone.PlatformType;
                    outData.PlatrormVersion = self.phone.PlatrormVersion;
                    outData.PlatformUI = self.phone.PlatformUI;
                    outData.Width = self.phone.Width;
                    outData.Height = self.phone.Height;
                    outData.Depth = self.phone.Depth;
                    outData.Weight = self.phone.Weight;
                    outData.DisplayScreenSize = self.phone.DisplayScreenSize;
                    outData.DisplayScreenResolution = self.phone.DisplayScreenResolution;
                    outData.DisplayTouchScreen = self.phone.DisplayTouchScreen;
                    outData.HardwareCPU = self.phone.HardwareCPU;
                    outData.HardwareUSB = self.phone.HardwareUSB;
                    outData.HardwareAudioJack = self.phone.HardwareAudioJack;
                    outData.HardwareFMRadio = self.phone.HardwareFMRadio;
                    outData.HardwareAccelerometer = self.phone.HardwareAccelerometer;
                    outData.HardwarePhysicalKeyboard = self.phone.HardwarePhysicalKeyboard;
                    outData.CameraPrimary = self.phone.CameraPrimary;
                    outData.CameraFeatures = self.phone.CameraFeatures;
                    outData.AdditionalFeatures = self.phone.AdditionalFeatures;
                    outData.Images = self.phone.Images;
                    
                    outData.$update({phoneId: 'Phones/' + $routeParams.phoneId})
                    .then(function (response) { 
                        self.loading = false;
                        document.location.href = "#!/phones";
                    }).catch(function(error){
                        alert('Server error. Update page or try again later.');
                    }).finally(function() {
                        self.loading = false;
                    });
                };
            }
        ]
});