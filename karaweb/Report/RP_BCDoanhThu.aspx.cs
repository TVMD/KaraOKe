using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Reporting.WebForms;

public partial class Report_RP_BCDoanhThu : System.Web.UI.Page
{
    public static string id;
    DateTime dateFrom, dateTo;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request.QueryString["id"];
        dateFrom = DateTime.Parse(Request.QueryString["from"]);
        dateTo = DateTime.Parse(Request.QueryString["to"]);


        ////Instantiate variables
        //ReportDocument reportDocument = new ReportDocument();
        //ParameterField paramField_from = new ParameterField();
        //ParameterField paramField_to = new ParameterField();
        //ParameterFields paramFields = new ParameterFields();

        //ParameterDiscreteValue paramDiscreteValue_from = new ParameterDiscreteValue();
        //ParameterDiscreteValue paramDiscreteValue_to = new ParameterDiscreteValue();

        ////Set instances for input parameter 1 -  @CustomerID
        //paramField_from.Name = "@dateFrom";
        //paramField_to.Name = "@dateTo";

        //paramDiscreteValue_from.Value = dateFrom;
        //paramDiscreteValue_to.Value = dateTo;

        //paramField_from.CurrentValues.Add(paramDiscreteValue_from);
        //paramField_to.CurrentValues.Add(paramDiscreteValue_to);

        ////Add the paramField to paramFields
        //paramFields.Add(paramField_from);
        //paramFields.Add(paramField_to);

        //CrystalReportViewer1.ParameterFieldInfo = paramFields;

        //string reportPath = Server.MapPath("~/Report/CrystalReport_BCDoanhThu.rpt");

        //reportDocument.Load(reportPath);
        //reportDocument.SetDatabaseLogon("sa", "912606toanvy",
        //         "DESKTOP-0ATA2T6", "QLPhongKaraoke_1");

        ////Load the report by setting the report source
        //CrystalReportViewer1.ReportSource = reportDocument;


        //var dao = new SalesOrderBusiness();

        //ReportDocument rd = new ReportDocument();
        //rd.Load(Path.Combine(Server.MapPath("~/Report/CrystalReport.rpt")));
        //rd.SetDataSource(dao.ListOrderViewToday2(employeeID));
        //Response.Buffer = false;
        //Response.ClearContent();
        //Response.ClearHeaders();
        //Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //stream.Seek(0, SeekOrigin.Begin);
   
        //File(stream, "application/pdf", "InventoryReport.pdf");


        //ReportParameter[] param = new ReportParameter[3];
        //param[0] = new ReportParameter("txtMaDH", MaDDH);
        //param[1] = new ReportParameter("txtTongTien", TongTien);
        //param[2] = new ReportParameter("txtTenNV", TenNV);

        DataSet dt = new DataSet();
        string str = @"DATA SOURCE=DESKTOP-0ATA2T6;initial catalog=QLPhongKaraoke_1;user id=sa;password=912606toanvy";
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from HOADONDV", con);
        da.Fill(dt, dt.Tables[0].TableName);
        ReportDataSource rdt = new ReportDataSource("DataSet1", dt.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rdt);
        //ReportViewer1.SetParameters(param);
        ReportViewer1.LocalReport.Refresh();
        //ReportViewer1.ReportRefresh();

    }
    
}