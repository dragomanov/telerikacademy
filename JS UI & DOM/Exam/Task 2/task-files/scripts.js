$.fn.gallery = function (cols) {
    var $this = $(this),
        currentImg = 0,
        imageCount = $this.find('[data-info]').length;
    cols = cols || 4;

    $this.addClass('gallery');
    $this.css('width', cols * 260 + 'px');
    $this.find('.selected div').css('margin-top', ($(window).height() - $this.find('#current-image').outerHeight())/2 + 'px');
    $this.find('.selected').hide();

    function setCurrentImage(dataInfo) {
        var $current = $this.find('[data-info=' + dataInfo + ']'),
            $prev = dataInfo != 1 ? $this.find('[data-info=' + (dataInfo-1) + ']') : $this.find('[data-info=' + imageCount + ']'),
            $next = dataInfo != imageCount ? $this.find('[data-info=' + (++dataInfo) + ']') : $this.find('[data-info=1]');

        $this.find('#current-image').attr('src', $current.attr('src'));
        $this.find('#previous-image').attr('src', $prev.attr('src'));
        $this.find('#next-image').attr('src', $next.attr('src'));
    }

    $this.find('.image-container').click(function () {
        var $that = $(this);
        currentImg = $that.find('img').attr('data-info');
        setCurrentImage(currentImg);
        $this.find('.gallery-list').addClass('blurred');
        $this.find('.selected').addClass('disabled-background');
        $this.find('.selected').show();
    });

    $this.find('.current-image').click(function () {
        $this.find('.gallery-list').removeClass('blurred');
        $this.find('.selected').removeClass('disabled-background');
        $this.find('.selected').hide();
    });

    $this.find('.previous-image').click(function () {
        currentImg = currentImg != 1 ? currentImg - 1 : imageCount;
        setCurrentImage(currentImg);
    });

    $this.find('.next-image').click(function () {
        currentImg = currentImg != imageCount ? ++currentImg : 1;
        setCurrentImage(currentImg);
    });

    return $this;
};