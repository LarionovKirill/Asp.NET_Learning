/**
 * Список цветов окраски фона.
 */
const colors = { Error: "#F08080", Correct: "rgb(255, 255, 255)", White: "#FFFFFF" };

/**
 * Хранит кнопку сохранения.
 */
var saveButton = document.getElementById("saveBut");

/**
 * Хранит поле ввода имени.
 */
const nameInput = document.getElementById("name");
if (nameInput.value.length != 0)
{
    nameInput.style.backgroundColor = colors.White;
}
else
{
    nameInput.style.backgroundColor = colors.Error;
}
/**
 * Хранит поле ввода номера телефона.
 */
const phoneInput = document.getElementById("phone");
if (phoneInput.value.length != 0) {
    phoneInput.style.backgroundColor = colors.White;
}
else {
    phoneInput.style.backgroundColor = colors.Error;
}
/**
 * Хранит поле ввода Email.
 */
const emailInput = document.getElementById("email");
if (emailInput.value.length != 0)
{
    emailInput.style.backgroundColor = colors.White;
}
else
{
    emailInput.style.backgroundColor = colors.Error;
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
        phoneInput.style.backgroundColor = colors.Error;
        saveButton.disabled = true;
        return;
    }
    phoneInput.style.backgroundColor = colors.White;
    fullValidation();
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
        nameInput.style.backgroundColor = colors.Error;
        saveButton.disabled = true;
        return;
    }
    nameInput.style.backgroundColor = colors.White;
    fullValidation();
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
        emailInput.style.backgroundColor = colors.Error;
        saveButton.disabled = true;
        return;
    }
    if (emailInput.value.length == 0)
    {
        emailInput.style.backgroundColor = colors.Error;
    }
    emailInput.style.backgroundColor = colors.White;
    fullValidation();
}

/**
 * Обработчик изменения Email.
 */
emailInput.addEventListener("input", emailValidation);

/**
 * Проверка правильности всех полей. 
 */
function fullValidation()
{
    if (emailInput.style.backgroundColor == colors.Correct &&
        nameInput.style.backgroundColor == colors.Correct &&
        phoneInput.style.backgroundColor == colors.Correct)
    {
        saveButton.disabled = false;
    }
}