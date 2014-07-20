(function ($) {
    $.fn.messageBox = function (){
        var $this = $(this),
            msgBox = {};
        msgBox.Success = function (msg){
            console.log(msg);
            $this.className = 'success-msg';
            $this.innerHTML = msg;
            $this.fadeIn(1000);
            setTimeout($this.fadeOut(1000), 3000);
        };
        msgBox.Error = function (msg) {
            console.log(msg);
            $this.className = 'error-msg';
            $this.innerHTML = msg;
            $this.fadeIn(1000);
            setTimeout($this.fadeOut(1000), 3000);
        };
        console.log(msgBox);
        return $(msgBox);
    }
})(jQuery);

var msgBox = $('#message-box').messageBox();
$('#btn-success').click(function () {
    msgBox.Success('Success message')
});
$('#btn-error').click(function (){
    msgBox.Error('Error message');
});
