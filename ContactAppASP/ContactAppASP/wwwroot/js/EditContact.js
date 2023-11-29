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
 * Этот метод отменяет поведение браузера по умолчанию,
 *  которое происходит при обработке события.
 * @param {any} e Объект события.
 */
function DragImage(e) {
    e.preventDefault();
}

/**
 * Обработчик переноса фото.
 */
dropArea.addEventListener("dragover", DragImage);

/**
 * Метод добавляет фото в область фото.
 * @param {any} e Объект события.
 */
function DropImage(e) {
    e.preventDefault();
    inputFile.files = e.dataTransfer.files;
    uploadImage();
}

/**
 * Обработчик отпускания фото.
 */
dropArea.addEventListener("drop", DropImage);
