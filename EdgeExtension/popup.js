/*
    This program is a browser extension that copies the addresses in each tab into clipboard.
    The extension is activated by clicking the extension icon in the browser.

    Handle on button click:

    - button with id "allTabs" that copies the addresses in each tab into clipboard.
    - button with id "currentTab" that copies the addresses in the current tab into clipboard.

    Create function that 
    - creates an array of the addresses in each tab.
    - copies the array into clipboard.
*/
function copyAddressCurrentTab() {
  browser.tabs.query({active: true, currentWindow: true}, function(tabs) {
      let addresses = tabs.map(tab => tab.url);
      navigator.clipboard.writeText(addresses.join('\n'));
  });
}

function copyAddressesInTabs(tabs) {
  // let addresses = tabs.map(tab => tab.url);
  // navigator.clipboard.writeText(addresses.join('\n')).then(() => {
      // console.log('Addresses copied');
  // });

  browser.tabs.query({}, function(tabs) {
    let allTabsInfo = tabs.map(tab => `${tab.title}\n${tab.url}`).join('\n\n');
    navigator.clipboard.writeText(allTabsInfo).then(function() {
        alert('All tab information copied to clipboard');
    });
  });
}

function handleCurrentTabButtonClick() {
  browser.tabs.query({active: true, currentWindow: true}, copyAddressCurrentTab);
}

function handleAllTabsButtonClick() {
  browser.tabs.query({}, copyAddressesInTabs);
}

var browser = browser || chrome;

document.getElementById('currentTab').addEventListener("click", function() {
  browser.tabs.query({active: true, currentWindow: true}, copyAddressCurrentTab);
});

document.getElementById('allCurrentTabs').addEventListener("click", function() {
  browser.tabs.query({currentWindow: true}, copyAddressesInTabs);    
});

document.getElementById('allTabs').addEventListener("click", function() {   
  browser.tabs.query({}, copyAddressesInTabs);
});

document.getElementById('copyBtn').addEventListener('click', function() {
  browser.tabs.query({active: true, currentWindow: true}, function(tabs) {
    let activeTab = tabs[0];
    let url = activeTab.url;
    let title = activeTab.title;
    let copyText = title + '\n' + url;
    navigator.clipboard.writeText(copyText).then(function() {
      alert(copyText + '\n\nCopied to clipboard');
    });
  });
});