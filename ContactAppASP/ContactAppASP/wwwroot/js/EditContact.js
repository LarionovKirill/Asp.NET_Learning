/**
 * Место для передачи фото.
 */
const dropArea = document.getElementById("drop-area");

/**
 * Переданный файл.
 */ 
const inputFile = document.getElementById("input-file");

/**
 * Отображение файла на странице.
 */
const imageView = document.getElementById("img-view");

inputFile.addEventListener("change", uploadImage);

/**
 * Загружает фото по url.
 */
function uploadImage() {
    let imgLink = URL.createObjectURL(inputFile.files[0]);
    imageView.style.backgroundImage = `url(${imgLink})`;
    imageView.textContent = "";
    imageView.style.border = 0;
}

/**
 * Обработчик переноса фото.
 */
dropArea.addEventListener("dragover", function (e) {
    e.preventDefault();
});

/**
 * Обработчик отпускания фото.
 */
dropArea.addEventListener("drop", function (e) {
    e.preventDefault();
    inputFile.files = e.dataTransfer.files;
    uploadImage();
});
