/// <reference path="C:\Users\Andrey\Documents\GitHub\SuperMario-JS\SuperMario\bower_components/raphael/raphael-min.js" />
/// <reference path="C:\Users\Andrey\Documents\GitHub\SuperMario-JS\SuperMario\bower_components/kineticjs/kinetic.min.js" />
(function () {
    window.onload = function () {
        var layer, stage, mario, width, height, e, direction;
        stage = new Kinetic.Stage({
            container: 'container',
            width: 1000,
            height: 600
        });
        layer = new Kinetic.Layer();
        var paper = Raphael(0, 0, 1000, 600);

        var ground = paper.rect(10, 460, 1000, 150);
        ground.attr({
            fill: 'brown',
            stroke: 'black',
            'stroke-width': 3
        });

        width = 200;
        height = 400;

        var img = new Image();
        img.src = 'images/mario.gif';

        img.onload = function () {
            mario = new Kinetic.Image({
                x: width,
                y: height,
                image: img,
                width: 50,
                height: 60,
                crop: {
                    x: 20,
                    y: 505,
                    width: 20,
                    height: 20
                }
            });
            layer.add(mario);
            layer.draw();

            var anim = new Kinetic.Animation(function (frame) {
                mario.y(height);
                mario.x(width);
                
                document.onkeydown = function () {
                    e = window.event.keyCode;
                };

                if (height < 400) {
                    height += 2;
                }

                if (e == '37') {
                    direction = 'l';
                }
                if (e == '39') {
                    direction = 'r';
                }
                if (e == '38') {
                    direction = 'u';
                }

                move(direction);

            }, layer);

            anim.start();
        };

        function stand() {
            
                return 60;
            
        };

        var up = true;

        function move(input) {

            if (input == 'l') {
                width -= 20;
            }
            else if (input == 'u') {
                if (height <= 300) {
                    up = false;
                }

                if (up) {
                    height -= 20;
                }
                else {
                    if (height < 400) {
                        height += 20;
                    }
                    else {
                        up = true;
                    }
                }
            }
            else if (input == 'r') {
                width += 20;
            }
            direction = '';
            e = '';

            if (width <= 0) {
                width = 0;
            }
            if (width >= 950) {
                width = 950;
            }
        }
        return stage.add(layer);
    };

}).call(this);