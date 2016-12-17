using System;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL;

public partial class Default2 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (LatestLoadedMainContent != null)
        {
            LoadUserControl(LatestLoadedMainContent);
        }
        else
        {
            LoadUserControl("UC\\UC_MPhong.ascx");
        }
        if(IsPostBack)
            SupportLoad();
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "loadpage", "pageload();", true);
    }


    public void SupportLoad()
    {
        var control = Request.Form["sapname"];

        if (control.Equals("phong"))
        {
            LoadUserControl("UC\\UC_MPhong.ascx");
        }
        else if (control.Contains("ctphong"))
        {
            LoadUserControl("UC\\UC_MCT_Phong.ascx");
        }
    } 
    public void SetTitle(string newtitle)
    {
        UC_Title.InnerHtml = newtitle ?? "null";
    }

    public void ShowDialog(string name,string title,int width,int height)
    {
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "", "OpenPopupCenter('"+name+"','"+title+"',"+width+","+height+");", true);
    }

    public void Swap(string _idphong,string mode)
    {
        idphong = _idphong;
        LoadUserControl(mode);
        if (mode == "UC\\UC_MPhong.ascx")
            mode = "phong";
        else
        {
            mode = "ctphong";
        }
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "sethref", "sethref('"+mode+"');", true);
    }

    public static string idphong { get; set; }

    #region solid
    private string LatestLoadedMainContent
    {
        get { return (string)ViewState["LatestLoadedMainContent"]; }
        set { ViewState["LatestLoadedMainContent"] = value; }
    }

    public void LoadUserControl(string controlName)
    {
        if (LatestLoadedMainContent != null)
        {
            var previousControl = Panel1.FindControl(LatestLoadedMainContent.Split('\\')[1]);
            if (!Equals(previousControl, null))
            {
                Panel1.Controls.Remove(previousControl);
            }
        }

        var userControlID = controlName.Split('\\')[1];
        var targetControl = Panel1.FindControl(userControlID);

        if (Equals(targetControl, null))
        {
            var userControl = (UserControl)LoadControl(controlName);
            userControl.ID = userControlID.Replace("/", "").Replace("~", "");
            Panel1.Controls.Add(userControl);
            LatestLoadedMainContent = controlName;
        }
    }

    #endregion

}