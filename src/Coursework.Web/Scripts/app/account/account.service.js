(function (angular) {

  angular
    .module("appModule")
    .factory("accountService", accountService);

  accountService.$inject = ['apiService'];

  function accountService(apiService) {
    function login(user) {
      return  apiService.post('/api/account/authenticate', user);
    }

    function register(user) {
      return apiService.post('/api/account/register', user);
    }

    var service = {
      login: login,
      register: register
    }

    return service;
  }
}
)(angular)