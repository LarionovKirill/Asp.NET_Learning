search = document.getElementById('find');

function findContacts() {
    $.ajax({
        method: "GET",
        url: "Contact/FindContacts?mask=" + search.value,
        success: function (data) {
            $(".container").html(data);
        },
        error: function (err) {
            console.log(err);
        }
    })
}

search.addEventListener('input', findContacts);

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