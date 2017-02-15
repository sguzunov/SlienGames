$(document).ready(function () {

    $.connection.hub.start();

    var chat = $.connection.chatHub;

    var $messages = $('.messages-content'),
        d, h, m,
        i = 0;

    function updateScrollbar() {
        $messages.mCustomScrollbar("update").mCustomScrollbar('scrollTo', 'bottom', {
            scrollInertia: 10,
            timeout: 0
        });
    }

    function setDate() {
        d = new Date()
        if (m != d.getMinutes()) {
            m = d.getMinutes();
            $('<div class="timestamp">' + d.getHours() + ':' + m + '</div>').appendTo($('.message:last'));
        }
    }
    function setName(name) {
        $('<div class="timestamp">' + ' ' + name + '</div>').appendTo($('.message:last'));
    }
    function insertMessage() {
        msg = $('.message-input').val();
        if ($.trim(msg) == '') {
            return false;
        }
        $('<div class="message message-personal">' + msg + '</div>').appendTo($('.mCSB_container')).addClass('new');
        setDate();
        $('.message-input').val(null);
        updateScrollbar();
        chat.server.sendMessage(msg,
            $('#username').attr('value'),
            $('#groupName').attr('value'),
            $('#userPictureUrl').attr('value'))
    }

    $('.message-submit').click(function () {
        insertMessage();
    });

    $(window).on('keydown', function (e) {
        if (e.which == 13) {
            insertMessage();
            return false;
        }
    })

    function accesptMessage(message, senderName, senderPictureUrl) {

        $('<div class="message new"><figure class="avatar"><img src="' + senderPictureUrl + '" /></figure>' + message + '</div>').appendTo($('.mCSB_container')).addClass('new');
        setDate();
        setName(senderName);
        updateScrollbar();
    }
})