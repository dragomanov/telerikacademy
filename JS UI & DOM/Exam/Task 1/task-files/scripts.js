function createImagesPreviewer(selector, items) {
    var containerNode = document.querySelector(selector),
        mainImageNode = document.createElement('div'),
        mainImageTitleNode = document.createElement('p'),
        mainImageImgNode = document.createElement('img'),
        imageListNode = document.createElement('div'),
        imageListFilterNode = document.createElement('div'),
        imageListImgsNode = document.createElement('div'),
        imageListFilterInputNode = document.createElement('input');

    containerNode.style.width = '535px';
    containerNode.style.height = '350px';

    mainImageNode.style.width = '350px';
    mainImageNode.style.float = 'left';

    mainImageTitleNode.style.height = '80px';
    mainImageTitleNode.style.textAlign = 'center';
    mainImageTitleNode.style.fontWeight = 'bold';
    mainImageTitleNode.style.fontSize = '30px';
    mainImageTitleNode.style.margin = '0';
    mainImageTitleNode.style.width = '350px';
    mainImageTitleNode.style.display = 'table-cell';
    mainImageTitleNode.style.verticalAlign = 'middle';
    mainImageTitleNode.id = 'main-image-title';
    mainImageTitleNode.textContent = items[0].title;
    mainImageNode.appendChild(mainImageTitleNode);

    mainImageImgNode.style.width = '350px';
    mainImageImgNode.style.border = '1px solid #ccc';
    mainImageImgNode.style.borderRadius = '15px';
    mainImageImgNode.style.boxSizing = 'border-box';
    mainImageImgNode.id = 'main-image';
    mainImageImgNode.src = items[0].url;
    mainImageNode.appendChild(mainImageImgNode);

    imageListNode.style.width = '150px';
    imageListNode.style.height = '350px';
    imageListNode.style.float = 'right';
    imageListNode.style.textAlign = 'center';
    imageListNode.style.overflowY = 'auto';

    function filterImages(text) {
        var nodes = document.querySelectorAll('#image-list div');
        for (var i = 0; i < nodes.length; i++) {
            var title = items[i].title;
            if (title.indexOf(text) !== -1) {
                nodes[i].style.display = '';
            } else {
                nodes[i].style.display = 'none';
            }
        }
    }

    imageListFilterNode.textContent = 'Filter';

    imageListFilterInputNode.type = 'text';
    imageListFilterInputNode.id = 'filter';
    imageListFilterInputNode.style.width = '120px';
    imageListFilterInputNode.oninput = function () {
        filterImages(this.value);
    };

    imageListFilterNode.appendChild(imageListFilterInputNode);
    imageListNode.appendChild(imageListFilterNode);

    for (var i = 0; i < items.length; i++) {
        var divNode = document.createElement('div'),
            imgNode = document.createElement('img');

        divNode.onmouseover = function () {
            this.style.backgroundColor = '#ccc';
        };

        divNode.onmouseout = function () {
            this.style.backgroundColor = '';
        };

        divNode.onclick = function () {
            document.getElementById('main-image-title').textContent = this.firstChild.textContent;
            document.getElementById('main-image').src = this.lastElementChild.src;
        };

        divNode.style.fontWeight = 'bold';
        divNode.textContent = items[i].title;
        imgNode.src = items[i].url;
        imgNode.style.width = '120px';
        imgNode.style.borderRadius = '5px';
        divNode.appendChild(imgNode);
        imageListImgsNode.appendChild(divNode);
    }

    imageListImgsNode.id = 'image-list';
    imageListNode.appendChild(imageListImgsNode);

    containerNode.appendChild(mainImageNode);
    containerNode.appendChild(imageListNode);

    document.getElementById('filter').focus();
}