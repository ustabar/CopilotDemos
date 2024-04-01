// Convert date and time into human-readable format
function convertDate(date) {
    let options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute: '2-digit' };
    return date.toLocaleDateString("en-US", options);
}

// Add successfully cleared cache into paragraph with id "lastCleared"
function addCleared() {
    let p = document.getElementById("lastCleared");
    let date = new Date();
    p.innerHTML = "Successfully cleared cache " + convertDate(date);
}

// Clear all cache history
document.getElementById("allHistory").addEventListener("click", function() {
    chrome.browsingData.removeCache({ "since": 0 }, function() {
        addCleared();
    });
});

// Clear cache history from the past month
document.getElementById("pastMonth").addEventListener("click", function() {
    let date = new Date();
    date.setMonth(date.getMonth() - 1);
    chrome.browsingData.removeCache({ "since": date.getTime() }, function() {
        addCleared();
    });
});

// Clear cache history from the past week
document.getElementById("pastWeek").addEventListener("click", function() {
    let date = new Date();
    date.setDate(date.getDate() - 7);
    chrome.browsingData.removeCache({ "since": date.getTime() }, function() {
        addCleared();
    });
});

// Clear cache history from the past day
document.getElementById("pastDay").addEventListener("click", function() {
    let date = new Date();
    date.setDate(date.getDate() - 1);
    chrome.browsingData.removeCache({ "since": date.getTime() }, function() {
        addCleared();
    });
});

// Clear cache history from the past hour
document.getElementById("pastHour").addEventListener("click", function() {
    let date = new Date();
    date.setHours(date.getHours() - 1);
    chrome.browsingData.removeCache({ "since": date.getTime() }, function() {
        addCleared();
    });
});

// Clear cache history from the past minute
document.getElementById("pastMinute").addEventListener("click", function() {
    let date = new Date();
    date.setMinutes(date.getMinutes() - 1);
    chrome.browsingData.removeCache({ "since": date.getTime() }, function() {
        addCleared();
    });
});

