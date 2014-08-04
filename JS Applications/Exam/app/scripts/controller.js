/// <reference path="class.js" />
/// <reference path="persister.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="ui.js" />

define(['persister', 'ui', 'class'], function(persisters, ui, Class) {
    var controllers = (function () {
        var updateTimer = null;
        var rootUrl = "http://localhost:3000/";
        var sorter = 'time-asc';
        var Controller = Class.create({
            init: function () {
                this.persister = persisters.get(rootUrl);
            },
            loadUI: function (selector) {
                if (this.persister.isUserLoggedIn()) {
                    this.loadPostUI(selector);
                }
                else {
                    this.loadLoginFormUI(selector);
                }
                this.attachUIEventHandlers(selector);
            },
            loadLoginFormUI: function (selector) {
                var loginFormHtml = ui.loginForm();
                $(selector).html(loginFormHtml);
            },
            loadPostUI: function (selector) {
                var self = this;
                var postUIHtml = ui.postUI(this.persister.nickname());
                $(selector).html(postUIHtml);

                this.updateUI(selector);

                updateTimer = setInterval(function () {
                    self.updateUI(selector);
                }, 500);
            },
            attachUIEventHandlers: function (selector) {
                var wrapper = $(selector);
                var self = this;

                wrapper.on("click", "#btn-show-login", function () {
                    wrapper.find(".button.selected").removeClass("selected");
                    $(this).addClass("selected");
                    wrapper.find("#login-form").show();
                    wrapper.find("#register-form").hide();
                });
                wrapper.on("click", "#btn-show-register", function () {
                    wrapper.find(".button.selected").removeClass("selected");
                    $(this).addClass("selected");
                    wrapper.find("#register-form").show();
                    wrapper.find("#login-form").hide();
                });

                wrapper.on("click", "#btn-login", function () {
                    var user = {
                        username: $(selector + " #tb-login-username").val(),
                        password: $(selector + " #tb-login-password").val()
                    };

                    self.persister.user.login(user, function () {
                        self.loadPostUI(selector);
                    }, function (err) {
                        wrapper.find("#error-messages").text(err.responseJSON.message);
                    });
                    return false;
                });
                wrapper.on("click", "#btn-register", function () {
                    var user = {
                        username: $(selector).find("#tb-register-username").val(),
                        password: $(selector + " #tb-register-password").val()
                    };
                    self.persister.user.register(user, function () {
                        self.persister.user.login(user, function () {
                            self.loadPostUI(selector);
                        }, function (err) {
                            wrapper.find("#error-messages").text(err.responseJSON.message);
                        });
                    }, function (err) {
                        wrapper.find("#error-messages").text(err.responseJSON.message);
                    });
                    return false;
                });
                wrapper.on("click", "#btn-logout", function () {
                    self.persister.user.logout(function () {
                        self.loadLoginFormUI(selector);
                        clearInterval(updateTimer);
                    }, function (err) {
                    });
                });
                wrapper.on("click", "#btn-create-message", function () {
                    var post = {
                        title: $(selector).find('#tb-create-title').val(),
                        body: $(selector).find('#tb-create-body').val()
                    };
                    self.persister.posts.post(post, function () {
                        self.loadPostUI(selector);
                        clearInterval(updateTimer);
                    }, function (err) {
                        wrapper.find("#error-messages").text(err.responseJSON.message);
                    });
                });
                wrapper.on("click", "#btn-filter", function () {
                    var filter = {
                        user: $(selector).find('#tb-filter-username').val(),
                        pattern: $(selector).find('#tb-filter-content').val()
                    };
                    self.persister.posts.all(filter, function () {
                        self.loadPostUI(selector);
                        clearInterval(updateTimer);
                    }, function (err) {
                        wrapper.find("#error-messages").text(err.responseJSON.message);
                    });
                });
                wrapper.on("click", "#btn-sort-alpha-asc", function () {
                    sorter = 'alpha-asc';
                    self.loadPostUI(selector);
                    clearInterval(updateTimer);
                });
                wrapper.on("click", "#btn-sort-alpha-desc", function () {
                    sorter = 'alpha-desc';
                    self.loadPostUI(selector);
                    clearInterval(updateTimer);
                });
                wrapper.on("click", "#btn-sort-time-asc", function () {
                    sorter = 'time-asc';
                    self.loadPostUI(selector);
                    clearInterval(updateTimer);
                });
                wrapper.on("click", "#btn-sort-time-desc", function () {
                    sorter = 'time-desc';
                    self.loadPostUI(selector);
                    clearInterval(updateTimer);
                });
            },
            updateUI: function (selector) {
                var filter = {
                    user: $(selector).find('#tb-filter-username').val(),
                    pattern: $(selector).find('#tb-filter-content').val()
                };
                console.log(filter);
                this.persister.posts.all(filter, function (msg) {
                    switch(sorter) {
                        case 'alpha-asc':
                            msg = _.sortBy(msg, 'title.toLowerCase()').reverse(); break;
                        case 'alpha-desc':
                            msg = _.sortBy(msg, 'title.toLowerCase()'); break;
                        case 'time-asc':
                            msg = _.sortBy(msg, 'postDate'); break;
                        case 'time-desc':
                            msg = _.sortBy(msg, 'postDate').reverse(); break;
                        default:
                            msg = _.sortBy(msg, 'postDate'); break;
                    }
                    var msgList = ui.messagesList(msg);
                    $(selector).find("#messages-holder").html(msgList);
                });
            }
        });
        return {
            get: function () {
                return new Controller();
            }
        }
    }());

    $(function () {
        var controller = controllers.get();
        controller.loadUI("#content");
    });
});