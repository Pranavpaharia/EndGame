mergeInto(LibraryManager.library, {
  
  GetSessionData: function (score) {
      var sessionId = document.getElementById("sessionId").innerHTML;
      var sessionData = "/session/" + sessionId + "/score/" + Pointer_stringify(score);
      var bufferSize = lengthBytesUTF8(sessionData) + 1;
      var buffer = _malloc(bufferSize);
      stringToUTF8(sessionData, buffer, bufferSize);
      console.log("1:" + sessionData);
      return buffer;
  },
  
  printToConsole: function(log) {
      console.log(Pointer_stringify(log))
  },
  
  fetchUrl: function(url) {
    var xmlhttp = new XMLHttpRequest();
    
    xmlhttp.onreadystatechange = function() {
      if (this.readyState == 4 && this.status == 200) {
        var myArr = JSON.parse(this.responseText);
        var score_id = myArr.score_id;
        console.log("myFunction: " + score_id);
        var bufferSize = lengthBytesUTF8(score_id) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(score_id, buffer, bufferSize);
        
      }
    };

    xmlhttp.open("GET", Pointer_stringify(url), true);
    xmlhttp.send();
    return buffer;
  },

//   fetchUrl: function(url){
//       var fetchData = fetchOHLC(url);
//       fetchData.then(function(data){
//         console.log("2:" + data.score_id);
//         var scoreId = data.score_id;
//         var bufferSize = lengthBytesUTF8(scoreId) + 1;
//         var buffer = _malloc(bufferSize);
//         stringToUTF8(scoreId, buffer, bufferSize);
//         console.log("3:" + buffer);
//         return buffer;
//       });
//   },
  
//   fetchOHLC: function(url) {
//     // const response = await fetch(Pointer_stringify(url));
//     // const data = await response.json();
//     // console.log(data.score_id);
//     // var bufferSize = lengthBytesUTF8(scoreId) + 1;
//     // var buffer = _malloc(bufferSize);
//     // stringToUTF8(scoreId, buffer, bufferSize);
//     // console.log("3:" + scoreId);
//     // return buffer;
    
//     fetch(Pointer_stringify(url))
//     .then(
//         function(response) {
//         if (response.status !== 200) {
//             console.log('Looks like there was a problem. Status Code: ' +
//             response.status);
//             return;
//         }

//         // Examine the text in the response
//         response.json().then(function(data) {
//             return data;
//             // console.log("2:" + data.score_id);
//             // var scoreId = data.score_id;
//             // var bufferSize = lengthBytesUTF8(scoreId) + 1;
//             // var buffer = _malloc(bufferSize);
//             // stringToUTF8(scoreId, buffer, bufferSize);
//             // console.log("3:" + buffer);
//             // return buffer;
            
//         });
//         console.log("4: success");
//         }
//     )
//     .catch(function(err) {
//         console.log('Fetch Error :-S', err);
//     });
//   },

});