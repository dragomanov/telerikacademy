var CanvasModule = (function () {
    var currentCtx;

    function Canvas(selector, width, height) {
        var canvas = document.createElement('canvas');
        console.log(this);
        this._width = width || '800px';
        this._height = height || '600px';
        this._ctx = canvas.getContext('2d');
        canvas.setAttribute('width', this._width);
        canvas.setAttribute('height', this._height);
        document.querySelector(selector).appendChild(canvas);
    }

    Canvas.prototype.draw = function (shape) {
        currentCtx = this._ctx;
        if (shape && shape.draw) {
            shape.draw();
        } else {
            throw new Error('Invalid shape');
        }
    }

    function Rectangle(x, y, w, h, options) {
        this.x = x;
        this.y = y;
        this.w = w;
        this.h = h;
        this.stroke = options.stroke || 'darkred';
        this.strokeSize = options.strokeSize || 3;
        this.fill = options.fill || 'blue';
    }

    Rectangle.prototype.draw = function () {
        currentCtx.rect(this.x, this.y, this.w, this.h);
        currentCtx.strokeStyle = this.stroke;
        currentCtx.lineWidth = this.strokeSize;
        currentCtx.fillStyle = this.fill;
        currentCtx.stroke();
        currentCtx.fill();
    }

    function Circle(x, y, r, options) {
        this.x = x;
        this.y = y;
        this.r = r;
        this.stroke = options.stroke || 'magenta';
        this.strokeSize = options.strokeSize || 3;
        this.fill = options.fill || 'orange';
    }

    Circle.prototype.draw = function () {
        currentCtx.beginPath();
        currentCtx.arc(this.x, this.y, this.r, 0, 2 * Math.PI);
        currentCtx.strokeStyle = this.stroke;
        currentCtx.lineWidth = this.strokeSize;
        currentCtx.fillStyle = this.fill;
        currentCtx.stroke();
        currentCtx.fill();
        currentCtx.closePath();
    }

    function Line(x1, y1, x2, y2, options) {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
        this.stroke = options.stroke || 'yellowgreen';
        this.strokeSize = options.strokeSize || 2;
    }

    Line.prototype.draw = function () {
        currentCtx.beginPath();
        currentCtx.moveTo(this.x1, this.y1);
        currentCtx.lineTo(this.x2, this.y2);
        currentCtx.strokeStyle = this.stroke;
        currentCtx.lineWidth = this.strokeSize;
        currentCtx.stroke();
        currentCtx.closePath();
    }

    return {
        Canvas: Canvas,
        Rectangle: Rectangle,
        Circle: Circle,
        Line: Line
    }

})();