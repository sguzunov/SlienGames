$(document).ready(function () {
    var chat = $.connection.chatHub;

    $.connection.hub.start().done(function () {
        chat.server.joinGroup()
    })
})