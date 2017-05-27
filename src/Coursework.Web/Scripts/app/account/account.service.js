(function (angular) {

  angular
    .module("appModule")
    .factory("accountService", accountService);

  accountService.$inject = ['apiService', 'notificationService', '$http', '$base64', '$cookieStore', '$rootScope'];

  function accountService(apiService, notificationService, $http, $base64, $cookieStore, $rootScope) {
    function login(user, completed) {
      apiService.post('/api/account/authenticate', user,
      completed,
      loginFailed);
    }

    function register(user, completed) {
      apiService.post('/api/account/register', user,
      completed,
      registrationFailed);
    }

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

    function loginFailed(response) {
      notificationService.displayError(response.data);
    }

    function registrationFailed() {
      notificationService.displayError('Registration failed. Try again.');
    }

    function isUserLoggedIn() {
      return $rootScope.repository.loggedUser != null;
    }


    var service = {
      login: login,
      register: register,
      saveCredentials: saveCredentials,
      removeCredentials: removeCredentials,
      isUserLoggedIn: isUserLoggedIn
    }

    return service;
  }
}
)(angular)