﻿using System;
using System.Web.UI;

public partial class Default2 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Controls.Clear();
        var userControl = (UserControl) LoadControl("UC\\UC_MPhong.ascx");
        Panel1.Controls.Add(userControl);
    }
}