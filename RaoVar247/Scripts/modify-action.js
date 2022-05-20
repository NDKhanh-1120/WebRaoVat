const deleteBTs = document.querySelectorAll(".delete-button");
//deletebuttons
for(var button of deleteBTs) {
    button.addEventListener("click", function(event) {
        this.nextElementSibling.style.display = "block";
    })
}

const disposeBTs = document.querySelectorAll(".dispose");
for(var bt of disposeBTs) {
    bt.addEventListener("click", function (event) {
        this.parentElement.parentElement.style.display = "none";
    })
}

const deleteConfirmCells = document.querySelectorAll(".delete-confirm-cell")
for(var dCCell of deleteConfirmCells) {
    dCCell.addEventListener("mouseleave", function(){
        this.style.display = "none";
    })
}


//click button sua

const editBTs = document.querySelectorAll(".edit-button");
for (var editBT of editBTs) {
    editBT.addEventListener("click", function (event) {
        formTitle.innerHTML = "Sửa danh mục"
        modalForm.elements["modal-submit-button"].value = "Cập nhật"
        modal.style.display = "flex";
        modalForm.action = "/admin/Main/EditCategory";

        var tr = editBT.closest("tr");
        modalForm.elements['CategoryId'].value = this.closest("tr").childNodes[1].innerHTML;
        modalForm.elements['CategoryId'].readOnly = "true"; 
        modalForm.elements['CategoryName'].value = this.closest("tr").childNodes[3].innerHTML;
        imgOfThis = this.closest("tr").childNodes[5].childNodes[1];
        imgOfThis.width = 120;
        imgOfThis.id = "img";
        modalForm.elements["imgfile"].parentNode.insertBefore(imgOfThis, modalForm.elements["imgfile"].nextElementSibling)

        modalForm.childNodes[10].childNodes[4].remove();


    })
}
// const deleteConfirms = document.querySelectorAll("form.delete-confirm")
// document.onclick = function(event) {
//     for( var )
// }