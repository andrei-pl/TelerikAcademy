var movingShapes = (function () {

    function add(shape) {
        var divWrapper = document.getElementById("wrapper");
        var element = document.createElement("div");

        element.style.width = '50px';       //znam che s css shte e po-dobre ;)
        element.style.height = '50px';
        element.style.position = 'absolute';
        element.style.textAlign = "center";
        element.style.fontWeight = "bold";
        element.innerHTML = "DIV";
        element.style.backgroundColor = randomColor();
        element.style.border = "2px solid " + randomColor();
        element.style.color = randomColor();

        divWrapper.appendChild(element);

        if (shape === "rect") {
            moveRect(0, 0, element);
        }
        else if (shape === "ellipse") {
            element.style.borderRadius = "50px";
            moveEllipse(0, element);
        }
        else {
            alert("Hacked by me! :)"); //sreshtu nekorektno podpuhvane na kod v konzolata ;)
        }
    }

    function randomColor() {
        return "rgb(" + parseInt(Math.random() * 256, 10) + "," + parseInt(Math.random() * 256, 10) + "," + parseInt(Math.random() * 256, 10) + ")";
    }

    function moveEllipse(angle, element) {
        var r1 = 80,         //radius visochina
            r2 = 120,        //radius shirina
            xCenter = 200,   
            yCenter = 400,   
            x = Math.floor(xCenter + (r1 * Math.cos(angle))),
            y = Math.floor(yCenter + (r2 * Math.sin(angle)));

        angle = angle + 0.01;
        element.style.top = x + "px"; 
        element.style.left = y + "px";

        setTimeout(function () { 
            moveEllipse(angle, element);
        }, 20);
    }

    function moveRect(dir, offset, element) {
        var xStart = 100,       
            yStart = 800,       
            rectSideA = 400,   
            rectSideB = 200,
            x,
            y;

        offset += 1;            
        if ((offset === rectSideA && dir % 2 === 0) || (offset === rectSideB && dir % 2 === 1)) {
            dir++;
            dir %= 4;
            offset = 0;
        }

        switch (dir) {
            case 0:
                y = yStart + offset;
                x = xStart;
                break;
            case 1:
                x = xStart + offset;
                y = yStart + rectSideA;
                break;
            case 2:
                y = yStart + rectSideA - offset;
                x = xStart + rectSideB;
                break;
            case 3:
                x = xStart + rectSideB - offset;
                y = yStart;
                break;
        }
        element.style.top = x + "px";
        element.style.left = y + "px";

        setTimeout(function () { 
            moveRect(dir, offset, element);
        }, 20);
    }

    return {
        add: add
    };
})();