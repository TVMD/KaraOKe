using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Web.UI;
using MODEL;
using Telerik.Web.UI;


public partial class testpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void Btnnekonclick(object sender, EventArgs e)
    {
    }

    protected void RadGrid1_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        RadGrid1.DataSource = new object[] { };
    }
}