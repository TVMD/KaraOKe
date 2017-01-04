using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class toan_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportDocument cryRpt = new ReportDocument();
        cryRpt.Load(Server.MapPath("Report\\Report_BCDoanhThu.rpt"));
        CrystalReportViewer1.ReportSource = cryRpt;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ReportDocument cryRpt = new ReportDocument();
        cryRpt.Load(Server.MapPath("Report\\Report_BCDoanhThu.rpt"));
        CrystalReportViewer1.ReportSource = cryRpt;

    }
    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {
        ReportDocument cryRpt = new ReportDocument();
        cryRpt.Load(Server.MapPath("Report\\Report_BCDoanhThu.rpt"));
        CrystalReportViewer1.ReportSource = cryRpt;
    }
}