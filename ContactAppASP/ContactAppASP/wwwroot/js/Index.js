/**
 * Посылает AJAX - запрос на сервер по выбранному контакту
 * и выводит информацию на экран.
 */
function showInfo() {
    var select = document.querySelector('select');
    var index = select.selectedIndex;
    var id = select[select.selectedIndex].id;
    if (id < 0) {
        alert('Выберите пользователя');
        return;
    }
    $.ajax({
        method: "GET",
        url: "Contact/GetContact?id=" + id,
        success: function (data) {
            $(".container").html(data);
            select = document.querySelector('select');
            select.selectedIndex = index;
            phoneInput = document.getElementById("phone");
            mask = new IMask(phoneInput, {
                mask: '+{7} (000) 000-00-00',
                lazy: false,
            });
        },
        error: function (err) {
            console.log(err);
        }
    })
}

/**
 * Посылает AJAX - запрос для удаления выбранного контакта.
 */
function removeContact() {
    var select = document.querySelector('select');
    var id = select[select.selectedIndex].id;
    if (id < 0) {
        alert('Выберите пользователя');
         return;
    }
    $.ajax({
        method: "GET",
        url: "Contact/RemoveContact?id=" + id,
        success: function (data) {
            $(".container").html(data);
        },
        error: function (err) {
            console.log(err);
        }
    })
}

/**
 * Посылает AJAX - запрос для поиска контакта по имени.
 */
function searchContacts()
{
    var search = document.getElementById('find');
    var mask = search.value;
    $.ajax({
        method: "GET",
        url: "Contact/FindContacts?mask=" + mask,
        success: function (data) {
            $(".container").html(data);
            var search = document.getElementById('find');
            search.value = mask;
            search.focus();
        },
        error: function (err) {
            console.log(err);
        }
    })
}