const container = document.querySelector(".small-nofi");
 window.onload = function(){
     if(container.style.display != "none")
     setTimeout(function(){
         container.style.display = "none";
     
     },3000);
 }