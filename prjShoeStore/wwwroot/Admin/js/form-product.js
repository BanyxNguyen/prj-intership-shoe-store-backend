const inputImg = document.getElementById('input-image');
const inputImgPost = document.getElementById('imagePost');
const containers = document.querySelector('.container-images');

const inputOriginal = document.getElementById('imageOriginal');

const fileOriginals = inputOriginal.value ? JSON.parse(inputOriginal.value) : [];

const createImg = (file, isLocal = true) => {
    const div = document.createElement("div");
    div.classList.add("img-item");

    const img = document.createElement("img");
    div.append(img);
    if (isLocal) {
        const src = URL.createObjectURL(file);
        img.src = src;
    } else {
        img.src = file;
    }
    return div;
}
fileOriginals.forEach(item => {
    const img = createImg(item, false);
    containers.append(img);
});

const imageDimensions = file =>
    new Promise((resolve, reject) => {
        const img = new Image()

        // the following handler will fire after the successful loading of the image
        img.onload = () => {
            const { naturalWidth: width, naturalHeight: height } = img
            resolve({ width, height })
        }

        // and this handler will fire if there was an error with the image (like if it's not really an image or a corrupted one)
        img.onerror = () => {
            reject('There was some problem with the image.')
        }

        img.src = URL.createObjectURL(file)
    })

const ImageProcessInfo = {
    isLock: false,
    ContantSize: {
        width: 600,
        height: 450
    }
}
inputImg.addEventListener("change", async (event) => {
    if (!inputImg.files || ImageProcessInfo.isLock) return;
    ImageProcessInfo.isLock = true;
    const ImageInValid = [];
    const ImageValid = new DataTransfer();

    const files = inputImgPost.files;

    if (files && files.length > 0) {
        for (var i = 0; i < files.length; i++) {
            ImageValid.items.add(files[i])
        }
    }


    try {
        for (var i = 0; i < inputImg.files.length; i++) {
            const file = inputImg.files[i];
            const { width, height } = await imageDimensions(file);

            if (width != ImageProcessInfo.ContantSize.width || height != ImageProcessInfo.ContantSize.height) {
                ImageInValid.push(file);
            } else {
                ImageValid.items.add(file)
                const image = createImg(file);
                containers.append(image);
            }
        }

        inputImg.files = null;
        inputImgPost.files = ImageValid.files;

        if (ImageInValid.length > 0) {
            alert(ImageInValid.map(x => "- " + x.name).join("\n") + "\nSize is invalid! (valid size 600 - 450)");
        }

    } finally {

        ImageProcessInfo.isLock = false;
    }

});