/**
 * Цвет фона ошибочного поля.
 */
const errorColor = "#F08080";

/**
 * Цвет фона верного поля.
 */
const correctColor = "#FFFFFF";

/**
 * Хранит кнопку сохранения.
 */
var saveButton = document.getElementById("saveBut");

/**
 * Хранит поле ввода имени.
 */
const nameInput = document.getElementById("name");

/**
 * Поле валидности имени.
 */
var isNameValid;

if (nameInput.value.length != 0)
{
    nameInput.style.backgroundColor = correctColor;
    isNameValid = true;
}
else
{
    nameInput.style.backgroundColor = errorColor;
    isNameValid = false;
}


/**
 * Хранит поле ввода номера телефона.
 */
const phoneInput = document.getElementById("phone");

/**
 * Поле валидности номера.
 */
var isPhoneValid;

if (phoneInput.value.length != 0)
{
    phoneInput.style.backgroundColor = correctColor;
    isPhoneValid = true;
}
else
{
    phoneInput.style.backgroundColor = errorColor;
    isPhoneValid = false;
}
/**
 * Хранит поле ввода Email.
 */
const emailInput = document.getElementById("email");

/**
 * Поле валидности email.
 */
var isEmailValid;

if (emailInput.value.length != 0)
{
    emailInput.style.backgroundColor = correctColor;
    isEmailValid = true;
}
else
{
    emailInput.style.backgroundColor = errorColor;
    isEmailValid = false;
}

/**
* Создает маску для номера телефона.
*/
var mask = new IMask(phoneInput, {
    mask: '+{7} (000) 000-00-00',
    lazy: false,
});

/**
 * Валидация номера телефона.
 */
function phoneValidation()
{
    if (phoneInput.value.includes('_') == true)
    {
        phoneInput.style.backgroundColor = errorColor;
        saveButton.disabled = true;
        isPhoneValid = false;
        return;
    }
    phoneInput.style.backgroundColor = correctColor;
    isPhoneValid = true;
    CheckCorrectFields();
}

/**
 * Обработчик изменения номера телефона.
 */
phoneInput.addEventListener('input', phoneValidation);

/**
 * Валидация имени.
 */
function nameValidation()
{
    if (nameInput.value.length > 100 || nameInput.value.length<1)
    {
        nameInput.style.backgroundColor = errorColor;
        saveButton.disabled = true;
        isNameValid = false;
        return;
    }
    nameInput.style.backgroundColor = correctColor;
    isNameValid = true;
    CheckCorrectFields();
}

/**
 * Обработчик изменения имени.
 */
nameInput.addEventListener("input", nameValidation);

/**
 * Валидация Email.
 */
function emailValidation() {
    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,5})$/;
    if (emailInput.value.length > 100 || reg.test(emailInput.value) == false)
    {
        emailInput.style.backgroundColor = errorColor;
        saveButton.disabled = true;
        isEmailValid = false;
        return;
    }
    if (emailInput.value.length == 0)
    {
        emailInput.style.backgroundColor = errorColor;
        isEmailValid = false;
    }
    emailInput.style.backgroundColor = correctColor;
    isEmailValid = true;
    CheckCorrectFields();
}

/**
 * Обработчик изменения Email.
 */
emailInput.addEventListener("input", emailValidation);

/**
 * Метод проверяет все поля на валидность.
 */
function CheckCorrectFields()
{
    if (isEmailValid && isNameValid && isPhoneValid) {
        saveButton.disabled = false;
    }
    else
    {
        saveButton.disabled = true;
    }
}