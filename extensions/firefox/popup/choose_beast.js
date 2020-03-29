document.addEventListener("DOMContentLoaded", listTabs);

function getCurrentWindowTabs() {
    return browser.tabs.query({ currentWindow: true });
}

function listTabs() {
    getCurrentWindowTabs().then((tabs) => {
        let tabsList = document.getElementById('tabs-list');
        let currentTabs = document.createDocumentFragment();
        let limit = 5;
        let counter = 0;

        tabsList.textContent = '';
        for (let tab of tabs) {
            if (!tab.active && counter <= limit) {
               let tabLink = document.createElement('a');
        
               tabLink.textContent = tab.title || tab.id;
        
              tabLink.setAttribute('href', tab.id);
               tabLink.classList.add('switch-tabs');
               currentTabs.appendChild(tabLink);
            }
        
            counter += 1;
        
           }
           tabsList.appendChild(currentTabs);
  });
}