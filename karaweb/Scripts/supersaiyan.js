
//General: 

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

function pageload() {
    $(".uc").on("click", function() {
            loaduc($(this).attr("id"));
        })
        .find($(".dangxuat")).on("click", function() {
            //chua nghi ra.
        });
    $("#fullscreen").on("click", toggleFullScreen);

    //$("#menuwarning").children().on("click", loaduc("phong"));

}

function loaduc(name) {
    window.location.href = "#/" + name;
    document.getElementById("sapname").value = name;
    document.getElementById("sapbutton").click();
};

function sethref(name) {
    window.location.href = "#/" + name;
    document.getElementById("sapname").value = name;
}

function toggleFullScreen() {
    if ((document.fullScreenElement && document.fullScreenElement !== null) ||
     (!document.mozFullScreen && !document.webkitIsFullScreen)) {
        if (document.documentElement.requestFullScreen) {
            document.documentElement.requestFullScreen();
        } else if (document.documentElement.mozRequestFullScreen) {
            document.documentElement.mozRequestFullScreen();
        } else if (document.documentElement.webkitRequestFullScreen) {
            document.documentElement.webkitRequestFullScreen(Element.ALLOW_KEYBOARD_INPUT);
        }
    } else {
        if (document.cancelFullScreen) {
            document.cancelFullScreen();
        } else if (document.mozCancelFullScreen) {
            document.mozCancelFullScreen();
        } else if (document.webkitCancelFullScreen) {
            document.webkitCancelFullScreen();
        }
    }
}

function addWarning(warning) {
    var x = $("<span></span>").text(warning);
    var count = $("#countwarning");
    var i = 0;
    if (count.text() === "")
        i = 1;
    else
        i = 1+ parseInt(count.text(), 10);
    count.text(i);

    $("#menuwarning")
        .append($("<li onclick=loaduc('phong')></li>")
        .append($("<a></a>")
        .append("<span class='fa fa-play'></span>")
        .append(x)));
}

function cleanWarning() {
    $("#menuwarning").empty();
    $("#countwarning").text("");
}

//Phong
function phong_ready() {
    $(".hihi").on("click", function () {
        var _this = $(this);
        $("#idphong").val(_this.attr("id").replace("rom_boss", ""));
        $("#m_btn").click();
    });
};


//Chi tiet phong
function ctphong_ready() {
    $(":input").inputmask().filter("#tenphong, #tgbatdau ,#sogio,#tienphong,#tongtienthanhtoan,#tongtienhang").each(function () {
        var _this = $(this);
        _this.prop("disabled", true);
        if (_this.val() == "") {
            _this.val("0");
        }
    });

    $("#btnback").on("click", function () {
        loaduc('phong');
    });

    if ($("#loaiphong").val() != "2") //normalrom
    {
        $("#star").remove();
    }

    var status = $("#status").val();
    if (status === "1") {
        $("#btntinhtien").prop("disabled", true);
    }
    if (status === "3") {
        $("#btnbatdau").prop("disabled", true);
    }
};

var interval = null; // functionhandle of time counting

function btnbatdauclick() {
    var tg = $("#tgbatdau").val();
    $("#tgbatdau").val(moment(tg,"DD/MM/YYYY HH:mm:ss").format("DD/MM/YYYY HH:mm:ss"));
    $("#btnbatdau").prop("disabled", true);
    $("#btntinhtien").prop("disabled", false);
    clearInterval(interval); //xoa cai cu di
    interval = setInterval(function() {
        var now = moment().format('DD/MM/YYYY HH:mm:ss');
        var then = $("#tgbatdau").val();
        $("#sogio").val(moment.utc(moment(now, "DD/MM/YYYY HH:mm:ss").diff(moment(then, "DD/MM/YYYY HH:mm:ss"))).format("HH:mm:ss"));
    }, 1000);
}

function btntinhtienclick() {
    var tg = $("#tgbatdau").val();
    $("#tgbatdau").val(moment(tg, "DD/MM/YYYY HH:mm:ss").format("DD/MM/YYYY HH:mm:ss"));
    $("#btnbatdau").prop("disabled", false);
    $("#btntinhtien").prop("disabled", true);
    clearInterval(interval);
}