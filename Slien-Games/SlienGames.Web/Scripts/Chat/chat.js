$(document).ready(function () {


    var chat = $.connection.chatHub;

    chat.client.acceptMessage = function (message, senderName, senderPictureUrl) {
        console.log("tuka")
        $('<div class="message new"><figure class="avatar"><img src="' + senderPictureUrl + '" /></figure>' + message + '</div>').appendTo($('.mCSB_container')).addClass('new');

        setName(senderName);
        updateScrollbar();
    }

    $.connection.hub.start().done(function () {

        chat.server.joinGroup($('#groupName').attr('value'));

        $('.message-submit').click(function () {
            insertMessage();
        });

        $(window).on('keydown', function (e) {
            if (e.which == 13) {
                insertMessage();
                return false;
            }
        })

        function insertMessage() {
            msg = $('.message-input').val();
            if ($.trim(msg) == '') {
                return false;
            }
            $('<div class="message message-personal">' + escapeHtml(msg) + '</div>').appendTo($('.mCSB_container')).addClass('new');

            $('.message-input').val(null);
            updateScrollbar();
            chat.server.sendMessage(msg,
                $('#groupName').attr('value'),
                $('#username').attr('value'),
                $('#userPictureUrl').attr('value'))
        }


    })

    var $messages = $('.messages-content'),
        d, h, m,
        i = 0;

    function updateScrollbar() {
        $messages.mCustomScrollbar("update").mCustomScrollbar('scrollTo', 'bottom', {
            scrollInertia: 10,
            timeout: 0
        });
    }

    function getQueryStringValue(key) {
        return decodeURIComponent(window.location.search.replace(new RegExp("^(?:.*[&\\?]" + encodeURIComponent(key).replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));
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

    function escapeHtml(unsafe) {
        return unsafe
             .replace(/&/g, "&amp;")
             .replace(/</g, "&lt;")
             .replace(/>/g, "&gt;")
             .replace(/"/g, "&quot;")
             .replace(/'/g, "&#039;");
    }

})
