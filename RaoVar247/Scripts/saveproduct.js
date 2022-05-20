var userId = document.getElementById("userId").value;
var saveBTs = document.querySelectorAll(".saveBT");
for (var bt of saveBTs) {
    bt.addEventListener("click", function () {
        if (this.children[0].alt == "unlike") {
            this.children[0].src = "/Content/Images/save-ad-active.svg";
            this.children[0].alt = "like";
            console.log("like")
            var productId = this.nextElementSibling.value;
            save(userId, this.nextElementSibling.value);
        }
        else {
            this.children[0].src = "/Content/Images/save-ad.svg"
            this.children[0].alt = "unlike"
            unSave(userId, parseInt(this.nextElementSibling.value));
        }
    })

}


function save(userId, productId) {
    console.log("like")
    $.ajax({
        type: "GET",
        url: "/User/Save",
        data: { userId: userId, productId: productId },
        success: function (data) {
            console.log("like")

        }
    });
}
function unSave(userId, productId) {
    $.ajax({
        type: "GET",
        url: "/User/UnSave",
        data: { userId: userId, productId: productId },
        success: function (data) {
            console.log("like")

        }
    });
}