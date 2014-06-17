$.fn.gallery = function (ev) {
    $this = $(this);
    $this.addClass('gallery');
    var numberOfColumns = 4;
    var $selected = $this.find('.selected');
    var $board = $this.find('.gallery-list');
    var $currentPic = $board;
    var $pic = $board;

    if (ev) {
        var numberOfColumns = ev;
    }

    $('.gallery-list').css('width', numberOfColumns * 260 + 'px');

    $selected.hide();

    $board.on('click', 'img', function () {
        $pic = $(this);
        $board.addClass('blurred')
              .addClass('disabled-background');

        $selected.find('#current-image').attr('src', $pic.attr('src'));
        $selected.find('#next-image').attr('src', $pic.parent().next().find('img').attr('src'));
        $selected.find('#previous-image').attr('src', $pic.parent().prev().find('img').attr('src'));
        $currentPic = $pic.parent();

        $selected.show();
    });

    $this.find('.selected').on('click', 'img', function(){
        var $enlargedImage = $(this);
        var $currImage = $currentPic;
        var $nextImage = $currentPic.next();
        var $prevImage = $currentPic.prev();

      
        if ($enlargedImage.attr('id') == 'next-image') {
            if ($currImage.length == 0) {
                $currImage = $currentPic.parent().find("div:first-child");
            }

            $enlargedImage.attr('src', $nextImage.find('img').attr('src'));
            $enlargedImage.parent().prev().find('img').attr('src', $currImage.find('img').attr('src'));
            $enlargedImage.parent().prev().prev().find('img').attr('src', $prevImage.find('img').attr('src'));
            $currentPic = $currentPic.next();
            if ($currentPic.length == 0) {
                $currentPic = $this.find('.gallery-list').find("div:first-child");
            }
        }

        if ($enlargedImage.attr('id') == 'previous-image') {

            if ($prevImage.length == 0) {
                $prevImage = $currentPic.parent().find("div:last-child");
            }

            $currentPic = $currentPic.prev();
            $enlargedImage.attr('src', $prevImage.find('img').attr('src'));
            $enlargedImage.parent().next().find('img').attr('src', $currImage.find('img').attr('src'));
            $enlargedImage.parent().next().next().find('img').attr('src', $nextImage.find('img').attr('src'));
            if ($currentPic.length == 0) {
                $currentPic = $this.find('.gallery-list').find("div:last-child");
            }
        }


        if ($enlargedImage.attr('id') == 'current-image') {
            $selected.hide();
            $board.removeClass('blurred')
                  .removeClass('disabled-background');
        }

        
    })


};