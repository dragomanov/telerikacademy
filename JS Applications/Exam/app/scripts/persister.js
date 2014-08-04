/// <reference path="http-requester.js" />
/// <reference path="sha1.js" />

define(['class', 'sha1', 'http-requester'], function(Class, CryptoJS, httpRequester) {
    var nickname = localStorage.getItem("nickname");
    var sessionKey = localStorage.getItem("sessionKey");
    var filter = localStorage.getItem("filter");

    function saveUserData(userData) {
        localStorage.setItem("nickname", userData.username);
        localStorage.setItem("sessionKey", userData.sessionKey);
        nickname = userData.username;
        sessionKey = userData.sessionKey;
    }

    function clearUserData() {
        localStorage.removeItem("nickname");
        localStorage.removeItem("sessionKey");
        nickname = "";
        sessionKey = "";
    }

    function setFilter(filter) {
        localStorage.setItem("filter", JSON.stringify(filter));
        this.filter = filter;
    }

    var MainPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersister(this.rootUrl);
            this.posts = new PostsPersister(this.rootUrl);
        },
        isUserLoggedIn: function () {
            var isLoggedIn = nickname != null && sessionKey != null;
            return isLoggedIn;
        },
        nickname: function () {
            return nickname;
        }
    });

    var UserPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
        },
        login: function (user, success, error) {
            var url = this.rootUrl + "auth";
            var userData = {
                username: user.username,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
            };

            httpRequester.postJSON({url: url, data: userData},
                function (data) {
                    saveUserData(data);
                    success(data);
                }, error);
        },
        register: function (user, success, error) {
            var url = this.rootUrl + "user";
            var userData = {
                username: user.username,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
            };
            httpRequester.postJSON({url: url, data: userData},
                function (data) {
                    saveUserData(data);
                    success(data);
                }, error);
        },
        logout: function (success, error) {
            var url = this.rootUrl + "user";
            httpRequester.putJSON({url: url, headers: {'X-SessionKey': sessionKey}}, function (data) {
                clearUserData();
                success(data);
            }, error)
        }
    });

    var PostsPersister = Class.create({
        init: function (url) {
            this.rootUrl = url + 'post';
        },
        post: function (post, success, error) {
            var url = this.rootUrl;
            httpRequester.postJSON({url: url, headers: {'X-SessionKey': sessionKey}, data: post}, success, error);
        },
        all: function (filter, success, error) {
            var url = this.rootUrl;
            setFilter(filter);
            httpRequester.getJSON({url: url, data: filter}, success, error);
        }
    });
    return {
        get: function (url) {
            return new MainPersister(url);
        }
    };
});