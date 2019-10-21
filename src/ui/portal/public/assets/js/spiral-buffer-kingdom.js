$(function() {

    var config = {
        bgcolor: "#0e1d2f",
        color1: "#140c8e",
        color2: "#eb49bb",
        color3: "#1a2cb3",
        fade: 0.88,
        fill: true,
        groupSize: 10,
        lineWidth: 1,
        num: 117,
        opacity: 0.02,
        rotation: -1,
        shape: "circle",
        size: 2.4,
        spacing: 1.1,
        speed: 0.12,
        stroke: false,
        wavelength: 1.37,
        zoom: 1
    };

    // create a target config for easing
    var targetConfig = _.clone(config);

    // ease into these
    targetConfig.rotation = -.5;
    targetConfig.size = 1.5;
    targetConfig.num = 55;

    // export targetConfig for console accesibility
    window.targetConfig = targetConfig;

    // our canvas and drawing context
    var canvas = document.getElementById('spiral-buffer-kingdom');
    if (typeof isModeratHome !== 'undefined') {
        canvas.width = 1000;
        canvas.height = 1000;
    } else {
        canvas.width = window.innerWidth;
        canvas.height = window.innerHeight;

        window.onresize = function () {
            canvas.width = window.innerWidth;
            canvas.height = window.innerHeight;
            bufferCanvas.width = canvas.width;
            bufferCanvas.height = canvas.height;
        };
    }
    var mainCtx = canvas.getContext('2d');
    var bufferCanvas = document.createElement('canvas');
    var bufferCtx = bufferCanvas.getContext('2d');
    bufferCanvas.width = canvas.width;
    bufferCanvas.height = canvas.height;

    // our height and width constants
    var W = canvas.width;
    var H = canvas.height;
    var CX = W / 2;
    var CY = H / 2;
    var PI2 = 2 * Math.PI;

    var shapes = {
        circle: drawCircle,
        triangle: drawTriangle,
        square: drawSquare
    };

    // init background color
    updateBackground();

    render(0);

    function draw(ctx, t, n) {

        var color_index = ( 1 + Math.floor(n/config.groupSize) % 3);
        var color = config['color'+color_index];
        var rotation = t/2000;

        ctx.save();
        ctx.translate(CX, CY);
        ctx.rotate(rotation);
        ctx.strokeStyle = color;
        ctx.fillStyle = color;
        ctx.lineWidth = config.lineWidth;

        // Some Magic Numbers
        var ss = config.wavelength;
        var size = config.size * (
            Math.sin(t/911*ss) * CX * .3 +
            Math.cos(t/701*ss) * CX * .2 +
            Math.sin(t/503*ss) * CX * .1)
        var x = Math.sin(t/787*ss) * CX * .37;
        var y = Math.sin(t/997*ss) * CY * .13;

        // Draw the shape
        shapes[config.shape](ctx, x, y, size);

        if(config.fill)
            ctx.fill();

        if(config.stroke)
            ctx.stroke();

        ctx.restore();
    }


    function drawCircle(ctx, x, y, r) {
        r = Math.abs(r);
        ctx.save();
        ctx.beginPath();
        ctx.arc(x, y, r, 0, PI2);
        ctx.restore();
    }

    function drawTriangle(ctx, x, y, size) {
        ctx.save();
        ctx.translate(x,y);
        ctx.beginPath();
        ctx.moveTo(0, size);
        ctx.lineTo(size / 2, 0);
        ctx.lineTo(-size / 2, 0);
        ctx.lineTo(0, size);
        ctx.restore();
    }

    function drawSquare(ctx, x, y, size) {
        ctx.save();
        ctx.translate(x,y);
        ctx.beginPath();
        ctx.moveTo(0, size);
        ctx.lineTo(size, size);
        ctx.lineTo(size, 0);
        ctx.lineTo(0, 0);
        ctx.lineTo(0, size);
        ctx.restore();
    }


    function render(t) {

        // clear the buffer
        bufferCtx.clearRect(0, 0, bufferCanvas.width, bufferCanvas.height);

        // draw the last frame back at semi-opacity (for trails)
        bufferCtx.globalAlpha = config.fade;

        // capture last frame to buffer
        bufferCtx.drawImage(canvas, 0, 0);

        // draw to the buffer at desired opacity level
        bufferCtx.globalAlpha = config.opacity;

        // Do some drawing of things
        for(var n=0; n<config.num; n++) {
            draw(bufferCtx, (t+n*config.spacing*1000) * config.speed, n);
        }

        mainCtx.save();

        // Fill the canvas so we have a background color in image exports
        mainCtx.fillStyle = config.bgcolor;
        mainCtx.fillRect(0, 0, canvas.width, canvas.height);

        // zoom and rotate the buffer around the center as we draw it back
        mainCtx.translate(CX, CY);
        mainCtx.scale(1 + config.zoom/100, 1 + config.zoom/100);
        mainCtx.rotate(config.rotation/100);
        mainCtx.translate(-CX, -CY);

        // draw the buffer to the canvas with transformations applied
        mainCtx.drawImage(bufferCanvas, 0, 0);

        mainCtx.restore();

        requestAnimationFrame(render);

        // ease our config values to their targets
        easeObject(config, targetConfig);
    }

    function updateBackground(val) {
        $('canvas').css('backgroundColor', val || config.bgcolor);
    }

    // Ease a single value towards another value by some gain percentage
    function ease(val, to, gain) {
        return val + (to-val) * gain;
    }

    // Ease all the numeric properties of an object to the
    // value of the same property on a target object
    function easeObject( obj, targetObj, gain ) {
        gain = gain || .045;
        _.each(obj, function(val, prop) {
            if(_.isNumber(val)) {
                obj[prop] = ease( val, targetObj[prop], gain);
            } else {
                obj[prop] = targetObj[prop];
            }
        });
    }

});