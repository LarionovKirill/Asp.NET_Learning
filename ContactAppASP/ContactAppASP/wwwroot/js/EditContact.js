/**
 * Отрисовывает добавленную картинку на странице.
 */
function DrawPicture() {
    document.querySelector('[type="file"]').addEventListener('change', (e) => {
        const elFileImg = document.querySelector('.avatar');
        const files = e.target.files;
        const countFiles = files.length;
        if (!countFiles) {
            alert('Не выбран файл!');
            return;
        }
        const selectedFile = files[0];
        if (!/^image/.test(selectedFile.type)) {
            alert('Выбранный файл не является изображением!');
            return;
        }
        const reader = new FileReader();
        reader.readAsDataURL(selectedFile);
        reader.addEventListener('load', (e) => {
            elFileImg.src = e.target.result;
            elFileImg.alt = selectedFile.name;
        });
    });
}

const dropArea = document.getElementById("drop-area");
const inputFile = document.getElementById("input-file");
const imageView = document.getElementById("img-view");

inputFile.addEventListener("change", uploadImage);

function uploadImage() {
    let imgLink = URL.createObjectURL(inputFile.files[0]);
    imageView.style.backgroundImage = `url(${imgLink})`;
    imageView.textContent = "";
    imageView.style.border = 0;
}

dropArea.addEventListener("dragover", function (e) {
    e.preventDefault();
});

dropArea.addEventListener("drop", function (e) {
    e.preventDefault();
    inputFile.files = e.dataTransfer.files;
    uploadImage();
});
