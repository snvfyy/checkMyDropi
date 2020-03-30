'use strict';
  chrome.tabs.onUpdated.addListener(
    function(tabId, changeInfo, tab) {
      if (changeInfo.url) {
          if(changeInfo.url.indexOf("http") == -1 ){
              return;
          }
        var url = changeInfo.url.split("/")[2];
         url = encodeURI(url);
        $.ajax({
            url: 'http://check.mydropi.es/api/v1/url/'+url+'/check',
            type: 'GET',
            crossDomain : true,
            error: function (data) {
                console.log(data);
                //alert(data);
            },
            success: function (data) {
                console.log(data)
                if(data.malicius){
                    alert("This site has been flagged by DROPi as suspicious,\nplease proceed with caution as this could be a phishing link or fake news!");
                    
                }
            }
        });
      }
    }
  );