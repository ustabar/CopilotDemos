/*
Service Worker for Google Chrome Extension
Handles when extension is installed
Handles when message is received
*/
chrome.runtime.onInstalled.addListener(function() {
  console.log("Extension Installed");
});

chrome.runtime.onMessage.addListener(function(request, sender, sendResponse) {
  console.log("Message Received");
  console.log(request);
  console.log(sender);
  sendResponse({message: "Message Received"});
});

