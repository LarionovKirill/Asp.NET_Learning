﻿/**
 * Посылает AJAX - запрос на сервер по выбранному контакту
 * и выводит информацию на экран.
 */
function showInfo() {
    var select = document.querySelector('select');
    var index = select.selectedIndex;
    if (index < 0) {
        alert('Выберите пользователя');
        return;
    }
    $.ajax({
        method: "GET",
        url: "Home/GetContact?index=" + index,
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
 * Посылает AJAX - запрос по переходу на страницу редактирования контакта.
 */
function editContact() {
    var select = document.querySelector('select');
    var index = select.selectedIndex;
    if (index < 0) {
        alert('Выберите пользователя');
        return;
    }
    $.ajax({
        method: "GET",
        url: "Home/EditContact?index=" + index,
        success: function (data) {
            $(".container").html(data);
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
    var index = select.selectedIndex;
    if (index < 0) {
        alert('Выберите пользователя');
        return;
    }
    $.ajax({
        method: "GET",
        url: "Home/RemoveContact?index=" + index,
        success: function (data) {
            $(".container").html(data);
        },
        error: function (err) {
            console.log(err);
        }
    })
}