/**
 * Посылает AJAX - запрос на сервер по выбранному контакту
 * и выводит информацию на экран.
 */
function showInfo() {
    var select = document.getElementById('contactList');
    var index = select.selectedIndex;
    var id = select[select.selectedIndex].id;
    var search = document.getElementById('find');
    var mask = search.value;
    var list = document.getElementById('list');
    var letter = list.value;
    if (id < 0) {
        alert('Выберите пользователя');
        return;
    }
    $.ajax({
        method: "GET",
        url: "Contact/GetContact?id=" + id,
        success: function (data) {
            $(".container").html(data);
            var search = document.getElementById('find');
            search.value = mask;
            select = document.getElementById('contactList');
            select.selectedIndex = index;
            phoneInput = document.getElementById("phone");
            var list = document.getElementById('list');
            list.value = letter;
            if (letter.length > 1) {
                var search = document.getElementById('find');
                search.disabled = false;
                return
            }
            var search = document.getElementById('find');
            search.disabled = true;
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
    var select = document.getElementById('contactList');
    var id = select[select.selectedIndex].id;
    var search = document.getElementById('find');
    var mask = search.value;
    if (id < 0) {
        alert('Выберите пользователя');
         return;
    }
    $.ajax({
        method: "GET",
        url: "Contact/RemoveContact?id=" + id,
        success: function (data) {
            $(".container").html(data);
            var search = document.getElementById('find');
            search.value = mask;
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

/**
 * Посылает AJAX - запрос для поиска контакта по первой букве.
 */
function findByFirstLetter()
{
    var list = document.getElementById('list');
    var letter = list.value;
    $.ajax({
        method: "GET",
        url: "Contact/FindByFirstLetter?letter=" + letter,
        success: function (data) {
            $(".container").html(data);
            var list = document.getElementById('list');
            list.value = letter;
            if (letter.length > 1) {
                var search = document.getElementById('find');
                search.disabled = false;
                return
            }
            var search = document.getElementById('find');
            search.disabled = true;
        },
        error: function (err) {
            console.log(err);
        }
    })
}