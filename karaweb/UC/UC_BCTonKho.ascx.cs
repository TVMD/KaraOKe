using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IVIEW;
using Telerik.Web.UI;
using System.Collections;
using PRESENTER;
using MODEL;
using System.Data;

public partial class UC_UC_BCTonKho : System.Web.UI.UserControl, IToBCTonKho
{
    #region Variable

    private string _message = "";
    private GridEditableItem editableItem;
    private Hashtable newValue;
    private Hashtable newValueCT;
    private int currentId = 2;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Default2)Page).SetTitle("BÁO CÁO DOANH THU");
    }

    protected void RadGrid1_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        //nó tự binjd trong hàm này
        var presenter = new PToBCTonKho(this);
        //DataTable dt;
        
        RadGrid1.DataSource = presenter.GetListBaoCao();
        //if (dt.Rows.Count != 0)
        //    Session["curID"] = dt.Rows[0][0].ToString();
        //else
        //    Session["curID"] = "-1";
        //RadGrid1.DataBind();
    }
    protected void RadGrid2_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        var presenter = new PToBCTonKho(this);
        
        //RadGrid2.DataSource = presenter.GetList();

    }

    protected void RadGrid1_OnItemCreated(object sender, GridItemEventArgs e)
    {
        //var item = e.Item as GridEditableItem;

        //if (item != null && (e.Item.IsInEditMode) && e.Item.ItemIndex != -1)
        //{
        //    (item.EditManager.GetColumnEditor("ID").ContainerControl.Controls[0] as TextBox).Enabled = false;
        //}
    }
    protected void RadGrid2_OnItemCreated(object sender, GridItemEventArgs e)
    {
        //var item = e.Item as GridEditableItem;
        //if (item != null && e.Item.IsInEditMode && e.Item.ItemIndex != -1)
        //{
        //    (item.EditManager.GetColumnEditor("ThanhTien").ContainerControl.Controls[0] as TextBox).Enabled = false;
        //}
    }


    protected void RadGrid1_OnItemDataBound(object sender, GridItemEventArgs e)
    {
        //if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
        //{
        //    GridEditFormItem dataItem = e.Item as GridEditFormItem;
        //    TableCell cell = dataItem["NgayNhap"];
        //    RadDatePicker rdp = cell.Controls[0] as RadDatePicker;
        //    rdp.SharedCalendar.UseColumnHeadersAsSelectors = false;
        //    rdp.SharedCalendar.UseRowHeadersAsSelectors = false;
        //    rdp.SharedCalendar.RangeMaxDate = DateTime.Now;
        //    rdp.SharedCalendar.RangeMinDate = System.DateTime.Now.AddDays(-30);
        //}
    }
    protected void RadGrid2_OnItemDataBound(object sender, GridItemEventArgs e)
    {
        //var cboHang = e.Item.FindControl("cbHang") as RadComboBox;
        //if (cboHang != null)
        //{
        //    var presenter = new PHDNhap(this);
        //    var DsHang = presenter.GetAllLoaiPhong();

        //    cboHang.DataTextField = "Ten";
        //    cboHang.DataValueField = "ID";
        //    cboHang.DataSource = DsHang;
        //    //cboHang.SelectedValue = Session["currentHang"].ToString();
        //    cboHang.DataBind();

        //}
        //if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
        //{
        //    //var item = (GridEditFormItem)e.Item;
        //    GridEditableItem item = e.Item as GridEditableItem;
        //    //var combo = (RadComboBox)item.FindControl("cbHang");
        //    //if (!(e.Item is IGridInsertItem))
        //    //{

        //    //    combo.SelectedValue = ((CT_HDNHAP)item.DataItem).IDHang.ToString();
        //    //    item.DataItem["IDHang"]
        //    //}

        //}
        //if (e.Item is GridDataItem)
        //{
        //    GridDataItem item = e.Item as GridDataItem;
        //    Session["currentHang"] = item["IDHang"].Text;

        //}
        //if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
        //{
        //    var item = (GridEditFormItem)e.Item;
        //    var combo = (RadComboBox)item.FindControl("cbHang");
        //    if (!(e.Item is IGridInsertItem))
        //    {
        //        combo.SelectedValue = DataBinder.Eval(item.DataItem, "IDHang").ToString();
        //    }
        //}

    }

    protected void RadGrid1_OnInsertCommand(object sender, GridCommandEventArgs e)
    {
        newValue = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);
        var presenter = new PToBCTonKho(this);
        date =DateTime.Parse(newValue["Thang"].ToString());

        //var cbb = e.Item.FindControl("k") as RadComboBox;
        //IdLoaiPhong = Convert.ToInt32(cbb.SelectedValue);
        presenter.Insert();

    }


    void loadHD()
    {
        //var presenter = new PHDNhap(this);
        //DataTable dt;
        //if (txtsearch.Text == "")
        //    dt = presenter.List(null);
        //else
        //{
        //    dt = presenter.List(txtsearch.Text);
        //}
        //RadGrid1.DataSource = dt;
        //RadGrid1.DataBind();
    }

    
    protected void RadGrid1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        GridDataItem item = (GridDataItem)RadGrid1.SelectedItems[0];//get selected row
        var presenter = new PToBCTonKho(this);
        DataTable ctbc = presenter.GetListCT_BaoCao(int.Parse(item["ID"].Text));
        RadGrid2.DataSource = ctbc;
        RadGrid2.DataBind();
        //currentId = int.Parse(item["ID"].Text);
        //Session["curID"] = int.Parse(item["ID"].Text);
    }
    protected void RadGrid2_PreRender(object sender, EventArgs e)
    {
        RadGrid2.Rebind();
    }
    protected void RadGrid2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int a = 0;
    }
    protected void Unnamed_Click(object sender, EventArgs e)
    {
        //((Default2)Page).ShowDialog("InputHang.aspx", "Thêm Hàng", 200, 200);
    }

    public DateTime date
    {
        get;
        set;
    }
}