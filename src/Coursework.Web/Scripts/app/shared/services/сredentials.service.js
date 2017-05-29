(function (angular) {

  angular
    .module("appModule")
    .factory("credentialsService", credentialsService);

  credentialsService.$inject = ['$http', '$base64', '$cookieStore', '$rootScope'];

  function credentialsService($http, $base64, $cookieStore, $rootScope) {
    function saveCredentials(user) {
      var membershipData = $base64.encode(user.username + ':' + user.password);

      $rootScope.repository = {
        loggedUser: {
          username: user.username,
          authdata: membershipData
        }
      };

      $http.defaults.headers.common['Authorization'] = 'Basic ' + membershipData;
      $cookieStore.put('repository', $rootScope.repository);
    }

    function removeCredentials() {
      $rootScope.repository = {};
      $cookieStore.remove('repository');
      $http.defaults.headers.common.Authorization = '';
    };

    function isUserLoggedIn() {
      return $rootScope.repository.loggedUser != null;
    }

    var service = {
      saveCredentials: saveCredentials,
      removeCredentials: removeCredentials,
      isUserLoggedIn: isUserLoggedIn
    }

    return service;
  }
})(angular);