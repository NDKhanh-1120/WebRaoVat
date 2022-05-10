const deleteBTs = document.querySelectorAll(".delete-button");
const deleteBT = document.querySelector(".delete-button");
for (var button of deleteBTs) {
    button.addEventListener("click", function(event) {
        // event.target.closest("ul li .delete-confirm-cell").style.backgroundColor = "red";
        button.nextElementSibling.style.display = "block";
    })
}

const disposeBTs = document.querySelectorAll(".dispose");
for(var bt of disposeBTs) {
    bt.addEventListener("click", function(event){
        bt.parentElement.parentElement.style.display ="none";
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
for(var editBT of editBTs){
    editBT.addEventListener("click", function(event) {
        formTitle.innerHTML = "Sửa danh mục"
        modalForm.elements["modal-submit-button"].value = "Cập nhật"
        modal.style.display = "flex";

        modalForm.action = "/admin/Home/EditCategory";

        var tr = editBT.closest("tr");
        modalForm.elements["CatgoryID"].value = editBT.closest("tr")[0];
    })
}
// const deleteConfirms = document.querySelectorAll("form.delete-confirm")
// document.onclick = function(event) {
//     for( var )
// }