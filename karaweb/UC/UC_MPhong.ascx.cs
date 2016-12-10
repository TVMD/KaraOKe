using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using IVIEW;
using PRESENTER;
using Telerik.Web.UI;

public partial class UC_UC_MPhong : UserControl, IMPhong
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var presenter = new PMPhong(this);
        var dsPhong = presenter.List(null);
        string[] romicon = {"fa fa-play", "fa fa-bookmark", "fa fa-pause"};
        string[] romstate = {"Phòng trống", "Đã đặt trước", "Đang có khách"};

        var col = 0;
        string idstring = null;
        foreach (DataRow item in dsPhong.Rows)
        {
            if (col%4 == 0) //1 dong 4 cot
            {
                CreateDiv(("divrow_" + col/4), "superDiv", "row top_tiles", "");
            }

            var currentrow = FindControl("divrow_" + col/4);
            idstring = item["ID"].ToString();

            //item tung cot
            CreateDiv("rom_boss" + idstring, ("divrow_" + col/4),
                "animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12", "");
            CreateDiv("rom" + idstring, "rom_boss" + idstring, "tile-stats", "");
            CreateDiv("rom_icon" + idstring, "rom" + idstring, "icon", "");
            CreateDiv("rom_count" + idstring, "rom" + idstring, "count", item["Ten"].ToString());

            var status = Convert.ToInt32(item["StatusID"].ToString());
            FindControl("rom" + idstring).Controls.Add(new LiteralControl("<h3>" + romstate[status] + "</h3>"));
            FindControl("rom_icon" + idstring)
                .Controls.Add(new LiteralControl("<i class='" + romicon[status] + "'></i>"));
            col++;
        }
        ((Default2) Page).SetTitle("Quản lý phòng");
        
    }

    private void CreateDiv(string id, string idparent, string cssclass, string innerhtlml)
    {
        var parent = FindControl(idparent);
        var newDiv =
            new HtmlGenericControl("DIV") {ID = id};
        newDiv.Attributes.Add("class", cssclass);
        newDiv.InnerHtml = innerhtlml;

        parent.Controls.Add(newDiv);
    }

    #region Variable

    private string _message = "";
    private GridEditableItem editableItem;
    private Hashtable newValue;

    #endregion

    #region Implement

    public string Message { get; set; }
    public int ID { get; set; }
    public string Ten { get; set; }
    public int StatusId { get; set; }
    public DateTime TGStart { get; set; }
    public int IdLoaiPhong { get; set; }
    public string TenLoaiPhong { get; set; }
    public float GiaNgay { get; set; }
    public float GiaDem { get; set; }

    #endregion

    protected void btn_OnClick(object sender, EventArgs e)
    {
        ((Default2)Page).ShowDialog("testpage.aspx", "hihi", 200, 200);
    }
}