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
};

function OpenPopupCenter(pageURL, title, w, h) {
    var left = (screen.width - w) / 2;
    var top = (screen.height - h) / 4;  // for 25% - devide by 4  |  for 33% - devide by 3
    var targetWin = window.open(pageURL, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
};

function phong_ready() {
    $(".hihi").on("click", function () {
        var _this = $(this);
        $("#idphong").val(_this.attr("id").replace("rom_boss", ""));
        $("#m_btn").click();
    });
};

function ctphong_ready() {
    $(":input").inputmask().filter("#tenphong, #tgbatdau ,#sogio,#tienphong,#tongtienthanhtoan,#tongtienhang").each(function() {
        var _this = $(this);
        _this.prop("disabled", true);
        if (_this.val() == "") {
            _this.val("0");
        }
    });

    $("#tgbatdau").val(moment().format("DD-MM-YYYY HH:mm"));

    $("#btnback").on("click", function () {
        loaduc('phong');
    });

    if ($("#loaiphong").val() != "2") //normalrom
    {
        $("#star").remove();
    }
};

function loaduc(name) {
    window.location.href = "#/" + name;
    document.getElementById("sapname").value = name;
    document.getElementById("sapbutton").click();
};

function sethref(name) {
    window.location.href = "#/" + name;
    document.getElementById("sapname").value = name;
}