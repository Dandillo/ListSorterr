let fileUploader = document.querySelector(".file-uploader");
fileUploader.addEventListener("change", function () {
    displayText(fileUploader.files[0]);
});

function displayText(sentFile) {
    let fr = new FileReader();
    let tmpString = "";
    fr.readAsText(sentFile);
    fr.onload =  e => {
        var unsortedList = document.querySelector(".unsorted");
        var tmpStorage = document.getElementsByName("tmpTxt")[0];
        let content = fr.result.split("\n");
        content.forEach((item) => {
            let li = document.createElement("li");
            li.innerText = item;
            unsortedList.appendChild(li);
        })
        tmpStorage.value = content.join(";");


    }
    
    
}