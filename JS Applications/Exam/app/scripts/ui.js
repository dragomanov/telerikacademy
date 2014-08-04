define([], function() {

	function buildLoginForm() {
		var html =
            '<div id="login-form-holder">' +
				'<form>' +
					'<div id="login-form">' +
						'<label for="tb-login-username">Username: </label>' +
						'<input type="text" id="tb-login-username"><br />' +
						'<label for="tb-login-password">Password: </label>' +
						'<input type="text" id="tb-login-password"><br />' +
						'<button id="btn-login" class="button">Login</button>' +
					'</div>' +
					'<div id="register-form" style="display: none">' +
						'<label for="tb-register-username">Username: </label>' +
						'<input type="text" id="tb-register-username"><br />' +
						'<label for="tb-register-nickname">Nickname: </label>' +
						'<input type="text" id="tb-register-nickname"><br />' +
						'<label for="tb-register-password">Password: </label>' +
						'<input type="text" id="tb-register-password"><br />' +
						'<button id="btn-register" class="button">Register</button>' +
					'</div>' +
					'<a href="#" id="btn-show-login" class="button selected">Login</a>' +
					'<a href="#" id="btn-show-register" class="button">Register</a>' +
				'</form>' +
				'<div id="error-messages"></div>' +
            '</div>';
		return html;
	}

	function buildPostUI(nickname) {
		var html =
            '<span id="user-nickname">' +
                    nickname +
            '</span>' +
            '<button id="btn-logout">Logout</button><br/>' +
            '<div id="error-messages"></div>' +
            '<div id="create-post">' +
                'Message title: <input type="text" id="tb-create-title" /><br/>' +
                'Message body: <input type="text" id="tb-create-body" /><br/>' +
                '<button id="btn-create-message">Create</button>' +
            '</div>' +
            '<div>' +
                'Filter by username: <input type="text" id="tb-filter-username" /><br/>' +
                'Filter by content: <input type="text" id="tb-filter-content" /><br/>' +
                '<button id="btn-filter">Filter</button>' +
            '</div>' +
            '<div id="sort-buttons">' +
                '<button id="btn-sort-alpha-asc">Sort alphabeticaly ascending</button>' +
                '<button id="btn-sort-alpha-desc">Sort alphabeticaly descending</button>' +
                '<button id="btn-sort-time-asc">Sort by date ascending</button>' +
                '<button id="btn-sort-time-desc">Sort by date descending</button>' +
            '</div>' +
            '<div id="messages-holder">' +
            '</div>';
		return html;
    }

	function buildMessagesList(messages) {
		var list = '<ul class="messages-list">';
		var msg;
		for (var i = 0; i < messages.length; i += 1) {
			msg = messages[i];
			var item =
				'<li class="well">' +
                    msg.title + ': ' +
                    msg.body + ' by ' +
                    msg.user.username +
				'</li>';
			list += item;
		}
		list += '</ul>';
		return list;
	}

	return {
		postUI: buildPostUI,
		loginForm: buildLoginForm,
		messagesList: buildMessagesList
	}
});