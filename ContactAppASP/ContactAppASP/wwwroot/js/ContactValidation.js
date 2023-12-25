/**
 * Цвет фона ошибочного поля.
 */
const ErrorColor = "#F08080";

/**
 * Цвет фона верного поля.
 */
const CorrectColor = "#FFFFFF";

/**
 * Маска проверки Email.
 */
const EmailMask = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,5})$/;

/**
 * Хранит кнопку сохранения.
 */
var saveButton = document.getElementById("saveBut");

/**
 * Хранит поле ввода имени.
 */
const NameInput = document.getElementById("name");

/**
 * Поле валидности имени.
 */
var isNameValid;

if (NameInput.value.length != 0)
{
    NameInput.style.backgroundColor = CorrectColor;
    isNameValid = true;
}
else
{
    NameInput.style.backgroundColor = ErrorColor;
    isNameValid = false;
}


/**
 * Хранит поле ввода номера телефона.
 */
const PhoneInput = document.getElementById("phone");

/**
 * Поле валидности номера.
 */
var isPhoneValid;

if (PhoneInput.value.length != 0)
{
    PhoneInput.style.backgroundColor = CorrectColor;
    isPhoneValid = true;
}
else
{
    PhoneInput.style.backgroundColor = ErrorColor;
    isPhoneValid = false;
}

/**
 * Хранит поле ввода Email.
 */
const EmailInput = document.getElementById("email");

/**
 * Поле валидности email.
 */
var isEmailValid;

if (EmailInput.value.length != 0)
{
    EmailInput.style.backgroundColor = CorrectColor;
    isEmailValid = true;
}
else
{
    EmailInput.style.backgroundColor = ErrorColor;
    isEmailValid = false;
}

/**
* Создает маску для номера телефона.
*/
var mask = new IMask(PhoneInput, {
    mask: '+{7} (000) 000-00-00',
    lazy: false,
});

/**
 * Валидация номера телефона.
 */
function phoneValidation()
{
    if (PhoneInput.value.includes('_') == true)
    {
        PhoneInput.style.backgroundColor = ErrorColor;
        saveButton.disabled = true;
        isPhoneValid = false;
        return;
    }
    PhoneInput.style.backgroundColor = CorrectColor;
    isPhoneValid = true;
    CheckCorrectFields();
}

/**
 * Обработчик изменения номера телефона.
 */
PhoneInput.addEventListener('input', phoneValidation);

/**
 * Валидация имени.
 */
function nameValidation()
{
    if (NameInput.value.length > 100 || NameInput.value.length<1)
    {
        NameInput.style.backgroundColor = ErrorColor;
        saveButton.disabled = true;
        isNameValid = false;
        return;
    }
    NameInput.style.backgroundColor = CorrectColor;
    isNameValid = true;
    CheckCorrectFields();
}

/**
 * Обработчик изменения имени.
 */
NameInput.addEventListener("input", nameValidation);

/**
 * Валидация Email.
 */
function emailValidation() {
    if (EmailInput.value.length > 100 || EmailMask.test(EmailInput.value) == false)
    {
        EmailInput.style.backgroundColor = ErrorColor;
        saveButton.disabled = true;
        isEmailValid = false;
        return;
    }
    if (EmailInput.value.length == 0)
    {
        EmailInput.style.backgroundColor = ErrorColor;
        isEmailValid = false;
    }
    EmailInput.style.backgroundColor = CorrectColor;
    isEmailValid = true;
    CheckCorrectFields();
}

/**
 * Обработчик изменения Email.
 */
EmailInput.addEventListener("input", emailValidation);

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