function querySelectorGetDivsInDiv() {
    return document.querySelectorAll('div > div');
}

function getDivsInDiv() {
    var allDivs = document.getElementsByTagName('div'),
        divsInDiv = [];
    for (var i = 0; i < allDivs.length; i++) {
        var obj = allDivs[i];
        if (obj.parentNode.localName == "div") {
            divsInDiv.push(obj);
        }
    }
    return divsInDiv;
}

(function init() {
    var queryDivs = querySelectorGetDivsInDiv(),
        getDivs = getDivsInDiv();

    document.write("Using querySelector: <br />");
    var textarea = document.createElement("textarea");
    for (var i = 0; i < queryDivs.length; i++) {
        textarea.value += queryDivs[i].outerHTML + "\n";
    }
    document.body.appendChild(textarea);
    document.write("<br />");

    document.write("Using getElementsByTagName: <br />");
    var textarea2 = document.createElement("textarea");
    for (var i = 0; i < getDivs.length; i++) {
        textarea2.value += getDivs[i].outerHTML + "\n";
    }

    document.body.appendChild(textarea2);
})();
