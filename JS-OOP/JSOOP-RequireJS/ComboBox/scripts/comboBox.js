'use stricrt'

define(['jquery', 'handlebars'], function () {
    function ComboBox(people){

        function render(template) {
            var collapsedClass = 'collapsed';
            var selectedClass = 'selected';
            var visibleClass = 'visible';

            var container = $('<div class="combobox-control" />');
            var compiledTemplate = Handlebars.compile(template);

            for (var person in  people) {
                $(compiledTemplate(people[person])).appendTo(container);
            }

            container.children().first().addClass(selectedClass);
            container.addClass(collapsedClass);

            container.on('click', '.person-item', function () {
                $this = $(this);

                if (container.hasClass(collapsedClass)) {
                    container.removeClass(collapsedClass);
                    container.children().addClass(visibleClass);
                } else {
                    container.children().removeClass(visibleClass);
                    container.addClass(collapsedClass);
                    container.find('.' + selectedClass).removeClass(selectedClass);
                    $this.addClass(selectedClass);
                }
            });

            return container;
        }

        return {
            render: render
        }
    };

    return {
        ComboBox: ComboBox
    }
})