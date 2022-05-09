const modalForm = document.forms["modal-form"]
var createBT = document.getElementById("create-bt");
var modal = document.getElementById("modal");
//click button tao moi
const formTitle = document.querySelector(".form-title");
const modalSubmitBT = document.getElementById("model-submit-button");
createBT.addEventListener("click", function(e) {
    formTitle.innerHTML = "Tạo mới danh mục"
    //modalSubmitBT.value = "Tạo"
    modalForm.elements["modal-submit-button"].value = "Tạo"
    modal.style.display = "flex";
})
//click ra ngoai de tat form
modal.addEventListener("click", function(){
    modal.style.display = "none";
})

modalForm.addEventListener("click", function(e){
    e.stopPropagation();
})

