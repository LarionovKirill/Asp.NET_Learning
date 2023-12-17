const saveButton = document.getElementById("saveBut");
const nameInput = document.getElementById("name");
const phoneInput = document.getElementById("phone");
const emailInput = document.getElementById("email");

var mask = new IMask(phoneInput, {
    mask: '+{7} (000) 000-00-00',
    lazy: false,  // make placeholder always visible
});

function nameValidation()
{
    if (nameInput.value.length > 100)
    {
        nameInput.style.backgroundColor = "#F08080";
        return;
    }
    nameInput.style.backgroundColor = "white";
}

nameInput.addEventListener("input", nameValidation);

function emailValidation() {
    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    if (emailInput.value.length > 100 || reg.test(emailInput.value) == false)
    {
        emailInput.style.backgroundColor = "#F08080";
        return;
    }
    emailInput.style.backgroundColor = "white";
}

emailInput.addEventListener("input", emailValidation);