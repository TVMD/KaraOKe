using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page
{
    private void LoadUC(Panel panel, string uc)
    {
        panel.Controls.Clear();
        var userControl = (UserControl)LoadControl(uc);
        panel.Controls.Add(userControl);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadUC(Panel1, "UC\\UC_MPhong.ascx");
    }

    public void SetTitle(string newtitle)
    {
        UC_Title.InnerHtml = newtitle ?? "null";
    }

    public void ShowDialog(string name, string title, int width, int height)
    {
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "", "OpenPopupCenter('" + name + "','" + title + "'," + width + "," + height + ");", true);
    }
    public void Swap(string _idphong, string mode)
    {
        idphong = _idphong;
        //LoadUC(Panel1, "UC\\UC_MPhong.ascx");
        //LoadUC(Panel2, "UC\\UC_MCT_Phong.ascx");
        //Panel1.Visible = !Panel1.Visible;
        //Panel2.Visible = !Panel2.Visible;
        LoadUC(Panel1, mode);
    }
    public static string idphong { get; set; }
}