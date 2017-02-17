<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChatController.ascx.cs" Inherits="SlienGames.Web.CustomControlls.Chat.ChatController" %>


<div class="chat">
    <div class="chat-title">
        <h1>Chatroom</h1>
    </div>
    <div class="messages">
        <div class="messages-content mCustomScrollbar _mCS_1">
            <div id="mCSB_1" class="mCustomScrollBox mCS-light mCSB_vertical mCSB_inside" tabindex="0" style="max-height: none;">
                <div id="mCSB_1_container" class="mCSB_container" style="position: relative; top: -152px; left: 0px;" dir="ltr">

                </div>
            </div>
        </div>
    </div>
    <div class="message-box">
        <textarea type="text" class="message-input" placeholder="Type message..."></textarea>
        <button type="submit" class="message-submit">Send</button>
    </div>

</div>
<div class="bg"></div>
<script src="../../Scripts/Chat/chat.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/malihu-custom-scrollbar-plugin/3.1.3/jquery.mCustomScrollbar.concat.min.js"></script>


