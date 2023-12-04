/**
 * Хранит объект для передачи фото.
 */
const dropArea = document.getElementById("drop-area");

/**
 * Хранит объект, хранящий переданный файл.
 */ 
const inputFile = document.getElementById("input-file");

/**
 *Хранит объект для отображения файла на странице.
 */
const imageView = document.getElementById("img-view");


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
 * Обработчик изменения изображения. 
 */
inputFile.addEventListener("change", uploadImage);

/**
 * Этот метод отменяет поведение браузера по умолчанию,
 *  которое происходит при обработке события.
 * @param {any} e Объект события.
 */
function dragImage(e) {
    e.preventDefault();
}

/**
 * Обработчик переноса фото.
 */
dropArea.addEventListener("dragover", dragImage);

/**
 * Метод добавляет фото в область фото.
 * @param {any} e Объект события.
 */
function dropImage(e) {
    e.preventDefault();
    inputFile.files = e.dataTransfer.files;
    uploadImage();
}

/**
 * Обработчик отпускания фото.
 */
dropArea.addEventListener("drop", dropImage);