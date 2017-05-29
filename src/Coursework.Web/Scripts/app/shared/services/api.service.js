(function (angular) {
  angular.module("appModule")
    .factory('apiService', apiService);

  apiService.$inject = ['$http', '$q', '$location', 'notificationService', 'credentialsService', '$rootScope'];

  function apiService($http, $q, $location, notificationService, credentialsService, $rootScope) {
    var service = {
      get: get,
      post: post
    };

    function get(url, config) {
      return $q((resolve, reject) => {
        $http.get(url, config)
          .then(result => {
            resolve(result);
          },
            error => {
              if (error.status == '401') {
                notificationService.displayError('Authentication required.');
                credentialsService.removeCredentials();
                $rootScope.previousState = $location.path();
                $location.path('/');
              } else {
                reject(error);
              }
            })
        .catch(response => {
          resolve(response);
        });
      });
    }

    function post(url, data) {
      return $q((resolve, reject) => {
        $http.post(url, data)
          .then(result => {
            resolve(result);
          },
            error => {
              if (error.status == '401') {
                notificationService.displayError('Authentication required.');
                credentialsService.removeCredentials();
                $rootScope.previousState = $location.path();
                $location.path('/');
              } else {
                reject(error);
              }
            });
      });
    }

    return service;
  }

})(angular);