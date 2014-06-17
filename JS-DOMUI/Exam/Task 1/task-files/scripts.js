function createImagesPreviewer(selector, items) {
    var animalsContainer = document.querySelector(selector);
    var animalsArray = items;

    var bigAnimal = document.createElement('div');
    var smallAnimals = document.createElement('div');
    var bigAnimalTitle = document.createElement('strong');
    var bigAnimalPicture = document.createElement('img');
    var smallAnimalBox = document.createElement('div')
    var smallAnimalTitle = document.createElement('strong');
    var smallAnimalPicture = document.createElement('img');
    var selected = null;

    animalsContainer.style.height = '750px';

    bigAnimal.style.width = '600px';
    bigAnimal.style.textAlign = 'center';
    bigAnimal.style.display = 'inline-block';
    bigAnimal.style.float = 'left';

    smallAnimals.style.width = '200px';
    smallAnimals.style.height = '480px';
    smallAnimals.style.textAlign = 'center';
    smallAnimals.style.display = 'inline-block';
    smallAnimals.style.overflow = 'auto';

    bigAnimalTitle.style.display = 'block';
    bigAnimalTitle.style.weight = 'bold';
    bigAnimalTitle.style.fontSize = '36px';
    bigAnimalTitle.style.marginBottom = '30px';

    bigAnimalPicture.style.display = 'block';
    bigAnimalPicture.style.width = '500px';
    bigAnimalPicture.style.height = '400px';
    bigAnimalPicture.style.margin = '0 auto';
    bigAnimalPicture.style.borderRadius = '20px';

    bigAnimalTitle.innerHTML = animalsArray[0].title;
    bigAnimalPicture.src = animalsArray[0].url;
    bigAnimal.appendChild(bigAnimalTitle);
    bigAnimal.appendChild(bigAnimalPicture);


    smallAnimalTitle.style.display = 'block';

    smallAnimalPicture.style.display = 'block';
    smallAnimalPicture.style.width = '150px';
    smallAnimalPicture.style.height = '120px';
    smallAnimalPicture.style.borderRadius = '5px';
    smallAnimalPicture.style.margin = '0 auto';


    function fullInSmallAnimalsDiv() {
        var boxes = [];

        var filterText = document.createElement('div');
        filterText.style.fontSize = '25px';

        var filterBox = document.createElement('input');

        filterText.innerHTML = 'Filter';
        boxes.push(filterText);
        boxes.push(filterBox);

        for (var i = 0; i < animalsArray.length; i++) {
            smallAnimalTitle.innerHTML = animalsArray[i].title;
            smallAnimalPicture.src = animalsArray[i].url;
            smallAnimalBox.appendChild(smallAnimalTitle);
            smallAnimalBox.appendChild(smallAnimalPicture);
            smallAnimalBox.style.paddingBottom = '5px';

            boxes.push(smallAnimalBox.cloneNode(true));
        }
        return boxes;
    }

    function onMouseClick(ev) {
        if (selected) {
            selected.style.background = '';
        }
        if (selected === this) {
            selected = null;
        }
        else {
            selected = this;
            bigAnimalPicture.src = this.querySelector('img').src;
            this.style.background = 'grey';
        }
    }

    function onMouseover(ev) {
        if (selected != this) {
            this.style.background = 'grey';
        }
    }

    function onMouseout(ev) {
        if (selected != this) {
            this.style.background = '';
        }
    }

    function onTextChange(ev) {
        text = this.value;
        for (var i = 0; i < animalsArray.length; i++) {
            if (text != '') {
                if (animalsArray[i].title.toLowerCase().indexOf(text.toLowerCase()) === -1) {
                    boxes[i + 2].style.display = 'none';
                }
                else {
                    boxes[i + 2].style.display = 'block';
                }
            }
            else {
                boxes[i + 2].style.display = 'block'
            }
        }
    }

    var boxes = fullInSmallAnimalsDiv();
    var docFragment = document.createDocumentFragment();

    for (var i = 0; i < boxes.length; i++) {
        if (i === 1) {
            boxes[i].addEventListener('keyup', onTextChange, false);
        }
        if (i >= 2) {
            boxes[i].addEventListener('click', onMouseClick, false);
            boxes[i].addEventListener('mouseover', onMouseover, false);
            boxes[i].addEventListener('mouseout', onMouseout, false);
        }

        docFragment.appendChild(boxes[i]);
    }
    smallAnimals.appendChild(docFragment);

    animalsContainer.appendChild(bigAnimal);
    animalsContainer.appendChild(smallAnimals);
}