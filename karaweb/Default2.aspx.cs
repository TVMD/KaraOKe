using System;
using System.Web.UI;

public partial class Default2 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Controls.Clear();
        var userControl = (UserControl) LoadControl("UC\\UC_NhapHang.ascx");
        Panel1.Controls.Add(userControl);
    }

    public void SetTitle(string newtitle)
    {
        UC_Title.InnerHtml = newtitle ?? "null";
    }

    public void ShowDialog(string name,string title,int width,int height)
    {
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "", "OpenPopupCenter('"+name+"','"+title+"',"+width+","+height+");", true);
    }
}