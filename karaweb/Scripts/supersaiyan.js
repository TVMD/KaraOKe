$(function () {

});

function ShowDialog(name,xtitle,width,height) {
    $('#dialog').load(name, function () {
        $(this).dialog({
            modal: true,
            height: height,
            width : width,
            title : xtitle
        });
    });
}