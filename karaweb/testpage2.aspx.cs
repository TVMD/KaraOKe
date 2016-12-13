using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class testpage2 : System.Web.UI.Page
{
    private int x = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        x ++;
    }
    protected void btn_OnClick(object sender, EventArgs e)
    {
        //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        string a = text.Value;
    }
}