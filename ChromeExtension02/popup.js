/*
    This program is a Chrome extension that copies the addresses in each tab into clipboard.
    The extension is activated by clicking the extension icon in the browser.

    Handle on button click:

    - button with id "allTabs" that copies the addresses in each tab into clipboard.
    - button with id "currentTab" that copies the addresses in the current tab into clipboard.

    Create function that 
    - creates an array of the addresses in each tab.
    - copies the array into clipboard.
*/
function copyAddressCurrentTab() {
    chrome.tabs.query({active: true, currentWindow: true}, function(tabs) {
        let addresses = tabs.map(tab => tab.url);
        navigator.clipboard.writeText(addresses.join('\n'));
    });
}

function copyAddressesInTabs(tabs) {
  let addresses = tabs.map(tab => tab.url);
    navigator.clipboard.writeText(addresses.join('\n')).then(() => {
        console.log('Addresses copied');
    });
}

function handleCurrentTabButtonClick() {
  chrome.tabs.query({active: true, currentWindow: true}, copyAddressCurrentTab);
}

function handleAllTabsButtonClick() {
    chrome.tabs.query({}, copyAddressesInTabs);
}

document.getElementById('currentTab').addEventListener("click", function() {
    chrome.tabs.query({active: true, currentWindow: true}, copyAddressCurrentTab);
});

document.getElementById('allCurrentTabs').addEventListener("click", function() {
    chrome.tabs.query({currentWindow: true}, copyAddressesInTabs);    
});

document.getElementById('allTabs').addEventListener("click", function() {   
    chrome.tabs.query({}, copyAddressesInTabs);
});

document.getElementById('copyBtn').addEventListener('click', function() {
    chrome.tabs.query({active: true, currentWindow: true}, function(tabs) {
      var activeTab = tabs[0];
      var url = activeTab.url;
      var title = activeTab.title;
      var copyText = 'URL: ' + url + '\nTitle: ' + title;
      navigator.clipboard.writeText(copyText).then(function() {
        alert('Copied to clipboard');
      });
    });
  });