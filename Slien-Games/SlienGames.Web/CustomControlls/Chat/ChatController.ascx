<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChatController.ascx.cs" Inherits="SlienGames.Web.CustomControlls.Chat.ChatController" %>


<div class="chat">
  <div class="chat-title">
    <h1>Chatroom</h1>
  </div>
  <div class="messages">
    <div class="messages-content"></div>
  </div>
  <div class="message-box">
    <textarea type="text" class="message-input" placeholder="Type message..."></textarea>
    <button type="submit" class="message-submit">Send</button>
  </div>

</div>
<div class="bg"></div>
<script src="../../Scripts/Chat/chat.js"></script>
