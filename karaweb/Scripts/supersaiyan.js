$(function () {

});

function ShowDialog(name,xtitle,width,height) {
    $('#dialog').load(name, function() {
        $(this).dialog({
            modal: true,
            height: height,
            width: width,
            title: xtitle,
            autoOpen: false,

            buttons: [
    {
        text: "Ok",
        icons: {
            primary: "ui-icon-heart"
        },
        click: function () {
            $(this).dialog("close");
        }

    }
            ]
        }).dialog("open");
    });
}

function OpenPopupCenter(pageURL, title, w, h) {
    var left = (screen.width - w) / 2;
    var top = (screen.height - h) / 4;  // for 25% - devide by 4  |  for 33% - devide by 3
    var targetWin = window.open(pageURL, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
}