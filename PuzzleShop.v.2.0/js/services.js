'use strict';

angular.module('angular-client-side-auth')
.factory('Auth', function($http, $cookieStore){

    var accessLevels = routingConfig.accessLevels
        , userRoles = routingConfig.userRoles
        , currentUser = $cookieStore.get('user') || { username: '', role: userRoles.public };

    $cookieStore.remove('user');

    function changeUser(user) {
        angular.extend(currentUser, user);
    }

    return {
        
        authorize: function (accessLevel, role) {
            //JSON.parse(role)
            if(role === undefined) {
                role = currentUser.role;
            }

            return accessLevel.bitMask & role.bitMask;
        },
        isLoggedIn: function(user) {
            if(user === undefined) {
                user = currentUser;
            }
            return user.role.title === userRoles.user.title || user.role.title === userRoles.admin.title;
        },
        register: function (user, success, error) {
            var user2 = {
                username: user.username,
                password: user.password,
                role_Title: user.role.title,
                role_bitMask: user.role.bitMask
            };
           
           
            $http.post('/api/LoginApi/PostRegistration', user2 ).success(function (res) {
                changeUser(res);
                //success();
                $cookieStore.put("user2", "user");
                var x = $cookieStore.get('user');
                ////var favoriteCookie = $cookies.get('myFavorite');
                console.log(res);
               
            }).error(error);
        },
        login: function (user, success, error) {
            $http.post('/api/LoginApi/PostLogin', user).success(function (user) {
                changeUser(user);
                success(user);
            }).error(error);
        },
        logout: function(success, error) {
            $http.post('/logout').success(function(){
                changeUser({
                    username: '',
                    role: userRoles.public
                });
                success();
            }).error(error);
          
        },
        accessLevels: accessLevels,
        userRoles: userRoles,
        user: currentUser
    };
});

angular.module('angular-client-side-auth')
.factory('Users', function($http) {
    return {
        getAll: function(success, error) {
            $http.get('/users').success(success).error(error);
        }
    };
});
