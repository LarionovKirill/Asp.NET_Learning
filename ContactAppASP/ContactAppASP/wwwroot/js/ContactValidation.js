/**
 * Хранит кнопку сохранения.
 */
var saveButton = document.getElementById("saveBut");

/**
 * Хранит поле ввода имени.
 */
const nameInput = document.getElementById("name");

/**
 * Хранит поле ввода номера телефона.
 */
const phoneInput = document.getElementById("phone");

/**
 * Хранит поле ввода Email.
 */
const emailInput = document.getElementById("email");

/**
* Создает маску для номера телефона.
*/
var mask = new IMask(phoneInput, {
    mask: '+{7} (000) 000-00-00',
    lazy: false,
});

/**
 * Валидация имени.
 */
function nameValidation()
{
    if (nameInput.value.length > 100)
    {
        nameInput.style.backgroundColor = "#F08080";
        saveButton.disabled = true;
        return;
    }
    nameInput.style.backgroundColor = "white";
    saveButton.disabled = false;
}

/**
 * Обработчик изменения имени.
 */
nameInput.addEventListener("input", nameValidation);

/**
 * Валидация Email.
 */
function emailValidation() {
    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    if (emailInput.value.length > 100 || reg.test(emailInput.value) == false)
    {
        emailInput.style.backgroundColor = "#F08080";
        saveButton.disabled = true;
        return;
    }
    emailInput.style.backgroundColor = "white";
    saveButton.disabled = false;
}

/**
 * Обработчик изменения Email.
 */
emailInput.addEventListener("input", emailValidation);