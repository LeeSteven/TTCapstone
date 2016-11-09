/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
/* 
    Created on : 2016/4/10, 下午 03:11:55
    Author     : Lee Kun-Han
*/

function Map() {


    var address ="12-16715, Suite 192, Yonge Street, Newmarket, ON L3X 1X4";
    var geocoder = new google.maps.Geocoder();
    var myLoc;
    var info = new google.maps.InfoWindow({
        content: "You clicked me!!!",
        maxWidth: 180
    });
    var map = new google.maps.Map(document.getElementById('map'), {
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        zoom: 15
    });
    geocoder.geocode({'address': address}, function (results, status) {
        if (status === google.maps.GeocoderStatus.OK) {
            myLoc = new google.maps.Marker({map: map, animation: google.maps.Animation.DROP, position: results[0].geometry.location});
            map.setCenter(results[0].geometry.location);
            google.maps.event.addListener(myLoc, 'click', function () {
                if (status === google.maps.GeocoderStatus.OK) {
                    info.setContent(results[0].formatted_address);
                }
                info.open(map, myLoc);
            });
        }
    });
}


function SendEmail() {
     var nameHolder = document.getElementById("Name").value;
    var emailHolder = document.getElementById("Email").value;
    var subjectHolder = document.getElementById("Subject").value;
    var messageHolder = document.getElementById("Message").value;
  
    if (emailHolder === null || emailHolder === "") {
        alert("Email can not be empty");
           return;
    } else if (subjectHolder === null || subjectHolder === "") {
        alert("Subject can not be empty");
          return;
    } else if (messageHolder === null || messageHolder === "") {
        alert("Message can not be empty");
        return;
    }
         var x = "mailto:" + emailHolder + "?subject=" + subjectHolder + " &body="+ messageHolder+'%0D%0A' + nameHolder;
         document.location.href = x;
       
}


