window.onload = function () {
    var stage,
        stageWidth = 800,
        stageHeight = 600,
        padding = {x: 20, y: 10},
        borderColor = 'yellowgreen',
        familyLayer,
        familyMembers = [
            {
                mother: 'Maria Petrova',
                father: 'Georgi Petrov',
                children: ['Teodora Petrova',
                    'Peter Petrov']
            },
            {
                mother: 'Petra Stamatova',
                father: 'Todor Stamatov',
                children: ['Maria Petrova']
            }
        ];

    function FamilyMember(x, y, name) {
        this.parents = [],
        this.children = [],
        this.x = x,
        this.y = y,
        this.name = name,
        this.gender = this.name.substr(this.name.length - 1) === 'a' ? "female" : "male",
        this.renderedName = new Kinetic.Text({
                x: x + padding.x,
                y: y + padding.y,
                text: this.name,
                fontSize: 30,
                fontFamily: 'Calibri',
                fill: 'black'
        }),
        this.width = this.renderedName.width(),
        this.height = this.renderedName.height(),
        this.draw = function () {
            rect = new Kinetic.Rect({
                x: x,
                y: y,
                stroke: borderColor,
                strokeWidth: 2,
                fill: 'white',
                width: this.renderedName.width() + padding.x * 2,
                height: this.renderedName.height() + padding.y * 2,
                cornerRadius: this.gender === "female" ? this.height / 2 + padding.y : 10
            });

            familyLayer.add(rect);
            familyLayer.add(this.renderedName);
        }
    }

    function drawConnection(stX, stY, eX, eY) {
        var beizerCPdY = Math.abs(eY - stY) * 0.75;
        var currLine = new Kinetic.Shape({
            drawFunc: function (context) {
                context.beginPath();
                context.moveTo(stX, stY);
                context.bezierCurveTo(stX, stY + beizerCPdY,
                        eX, eY - beizerCPdY,
                    eX, eY);
                context.strokeShape(this);
                context.beginPath();
                context.lineTo(eX + 5, eY - 5);
                context.lineTo(eX - 5, eY - 5);
                context.lineTo(eX, eY);
                context.fillShape(this);
            },
            strokeWidth: 1,
            fill: '#77B300',
            stroke: '#77B300'
        });

        familyLayer.add(currLine);
    }

    function maxPath(member) {
        if (!member.children || member.children.length === 0) {
            return 0;
        }
        var longestPath = 0;
        for (var i = 0; i < member.children.length; i++) {
            longestPath = Math.max(longestPath, maxPath(member.children[i]));
        }
        return longestPath + 1;
    }

    var root = {
        mother: 'Petra Stamatova',
        father: 'Todor Stamatov',
        children: [{
            mother: 'Maria Petrova',
            father: 'Georgi Petrov',
            children: ['Teodora Petrova', 'Peter Petrov']
        }]
    };

    console.log(maxPath(root));

    stage = new Kinetic.Stage({
        container: 'container',
        width: stageWidth,
        height: stageHeight
    });

    familyLayer = new Kinetic.Layer();

    var father = new FamilyMember(200, 50, 'Todor Stamatov');
    var mother = new FamilyMember(500, 50, 'Petra Stamatova');
    var child = new FamilyMember(350, 200, 'Maria Petrova');
    father.draw();
    mother.draw();
    child.draw();
    console.log(child);
    drawConnection(father.x + father.width / 2 + padding.x,
                   father.y + father.height + padding.y * 2,
                   child.x + child.width / 2 + padding.x,
                   child.y);
    drawConnection(mother.x + mother.width / 2 + padding.x,
                   mother.y + mother.height + padding.y * 2,
                   child.x + child.width / 2 + padding.x,
                   child.y);

    stage.add(familyLayer);
};