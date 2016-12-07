using System;
using System.Collections;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using IVIEW;
using PRESENTER;
using Telerik.Web.UI;
using UserControl = System.Web.UI.UserControl;

public partial class UC_UC_MPhong : UserControl, IMPhong
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var presenter = new PMPhong(this);
        var dsPhong = presenter.List(null);
        var superDiv = FindControl("superDiv");
        var col = 0;
        string idstring = null;
        foreach (DataRow item in dsPhong.Rows)
        {
            if (col%4 == 0) //1 dong 4 cot
            {
                var rowdiv =
                    new HtmlGenericControl("DIV");
                rowdiv.ID = "divrow_" + col/4;
                rowdiv.Attributes.Add("class", "RomRow");
                superDiv.Controls.Add(rowdiv);
            }
            var currentrow = FindControl("divrow_" + col/4);
            idstring = item["ID"].ToString();
            //item tung cot
            var createDiv =
                new HtmlGenericControl("DIV");
            createDiv.ID = "divrom_" + idstring;
            createDiv.Attributes.Add("class", "Rom");
            createDiv.InnerHtml = idstring;
            string status = item["StatusId"].ToString();
            if (status == "-1") // chua dat
            {
                createDiv.Attributes.Add("class", "Rom RomAvailble");
            }
            else if (status == "0") // da dat truoc
            {
                createDiv.Attributes.Add("class", "Rom RomBooked");
            }
            else if (status == "1") //dang xai
            {
                createDiv.Attributes.Add("class", "Rom RomBusy");
            }
            currentrow.Controls.Add(createDiv);
            col++;
        }
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
}