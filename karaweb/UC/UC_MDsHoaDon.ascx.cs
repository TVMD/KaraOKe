using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IVIEW;
using PRESENTER;
using Telerik.Web.UI;

public partial class UC_UC_MDsHoaDon : System.Web.UI.UserControl , IMHoaDonDV 
{
    #region Variable

    private string _message = "";
    private GridEditableItem editableItem;
    private Hashtable newValue;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        ((Default2)Page).SetTitle("Quản lý danh sách các hóa đơn dịch vụ");
    }

    protected void txtsearch_OnTextChanged(object sender, EventArgs e)
    {
        var presenter = new PMHoaDonDV(this);
        DataTable dt;
        dt = presenter.List(txtsearch.Text);
        RadGrid1.DataSource = dt;
        RadGrid1.DataBind();
    }

    protected void RadGrid1_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        var presenter = new PMHoaDonDV(this);
        DataTable dt;
        if (txtsearch.Text == "")
            dt = presenter.List(null);
        else
        {
            dt = presenter.List(txtsearch.Text);
        }
        RadGrid1.DataSource = dt;
    }

    protected void RadGrid1_OnItemCreated(object sender, GridItemEventArgs e)
    {
        //var item = e.Item as GridEditableItem;
        //if (item != null && e.Item.IsInEditMode && e.Item.ItemIndex != -1)
        //{
        //    (item.EditManager.GetColumnEditor("MaSV").ContainerControl.Controls[0] as TextBox).Enabled = false;
        //}
    }

    protected void RadGrid1_OnItemDataBound(object sender, GridItemEventArgs e)
    {
        var cbbphong = e.Item.FindControl("cbboxphong") as RadComboBox;
        var txtidhoadon = e.Item.FindControl("txtidhoadon") as RadTextBox;

        if (cbbphong != null)
        {
            var presenter = new PMHoaDonDV(this);
            var dshang = presenter.GetAllPhong();

            cbbphong.DataTextField = "Ten";
            cbbphong.DataValueField = "ID";
            cbbphong.DataSource = dshang;
            cbbphong.DataBind();
        }

        if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
        {
            var item = (GridEditFormItem)e.Item;
            if (!(e.Item is IGridInsertItem))
            {
                cbbphong.SelectedValue = DataBinder.Eval(e.Item.DataItem, "ID_Phong").ToString();
            }
            txtidhoadon.Text = DataBinder.Eval(e.Item.DataItem, "ID").ToString();
        }
    }

    protected void RadGrid1_OnInsertCommand(object sender, GridCommandEventArgs e)
    {
      //
    }

    protected void RadGrid1_OnUpdateCommand(object o, GridCommandEventArgs e)
    {
        newValue = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);
        var presenter = new PMHoaDonDV(this);

        var cbbphong = e.Item.FindControl("cbboxphong") as RadComboBox;
        var txtidhoadon = e.Item.FindControl("txtidhoadon") as RadTextBox;
        ID_HoaDon = Convert.ToInt32(txtidhoadon.Text);
        ID_Phong = Convert.ToInt32(cbbphong.SelectedValue);

        Message = presenter.Update() ? "Đã cập nhật" : "Cập nhật bị lỗi";
        if (Message == "Đã cập nhật")
        {
        }
    }

    protected void RadGrid1_OnDeleteCommand(object sender, GridCommandEventArgs e)
    {
        newValue = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);
        
        var presenter = new PMHoaDonDV(this);
        var txtidhoadon = e.Item.FindControl("txtidhoadon") as RadTextBox;
        //ID_HoaDon = Convert.ToInt32(txtidhoadon.Text);
        ID_HoaDon = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ID"));
        
        Message = presenter.Delete() ? "Xóa xong" : "Không xóa được nè";
        if (Message == "Xóa xong")
        {
        }
    }

    // grid 2
    protected void RadGrid2_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        var idhoadondv = 33;

        var presenter = new PMCT_HDDV(this);
        DataTable dt;
        if (txtsearch.Text == "")
            dt = presenter.List_HD(idhoadondv);
        else
        {
            dt = presenter.List_HD(idhoadondv,txtsearch.Text);
        }
        RadGrid2.DataSource = dt;

    }

    protected void RadGrid2_OnItemCreated(object sender, GridItemEventArgs e)
    {
        //var item = e.Item as GridEditableItem;
        //if (item != null && e.Item.IsInEditMode && e.Item.ItemIndex != -1)
        //{
        //    (item.EditManager.GetColumnEditor("MaSV").ContainerControl.Controls[0] as TextBox).Enabled = false;
        //}
    }

    protected void RadGrid2_OnItemDataBound(object sender, GridItemEventArgs e)
    {
        var cbohang = e.Item.FindControl("cbboxHang") as RadComboBox;
        if (cbohang != null)
        {
            var presenter = new PMHang();
            var dshang = presenter.List(null);

            cbohang.DataTextField = "Ten";
            cbohang.DataValueField = "ID";
            cbohang.DataSource = dshang;
            cbohang.DataBind();
        }
        if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
        {
            var item = (GridEditFormItem)e.Item;
            var combo = (RadComboBox)item.FindControl("cbboxHang");
            if (!(e.Item is IGridInsertItem))
            {
                combo.SelectedValue = DataBinder.Eval(item.DataItem, "ID_Hang").ToString();
            }
        }
    }

    protected void RadGrid2_OnInsertCommand(object sender, GridCommandEventArgs e)
    {
        
    }

    protected void RadGrid2_OnUpdateCommand(object sender, GridCommandEventArgs e)
    {
        newValue = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);

        var presenter = new PMCT_HDDV(this);

        var cbb = e.Item.FindControl("cbboxHang") as RadComboBox;
        var tbsoluong = e.Item.FindControl("txtsoluong") as RadNumericTextBox;
        ID_Hang = Int32.Parse(cbb.SelectedValue);
        SoLuong = int.Parse(tbsoluong.Text);

        Message = presenter.Update() ? "Đã cập nhật" : "Cập nhật bị lỗi";
        if (Message == "Đã cập nhật")
        {
        }
    }

    protected void RadGrid2_OnDeleteCommand(object sender, GridCommandEventArgs e)
    {
        newValue = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);

        var presenter = new PMCT_HDDV(this);

        ID_Hang = int.Parse(DataBinder.Eval(e.Item.DataItem, "ID_Hang").ToString());
        Message = presenter.Delete() ? "Xóa xong" : "Không xóa được nè";
        if (Message == "Xóa xong")
        {
            RadGrid1.DataBind();
        }
    }

    #region implement
    public string Message { get; set; }
    public int ID_HoaDon { get; set; }
    public int ID_Phong { get; set; }
    public DateTime NgayGioLap { get; set; }
    public string TenKH
    {
        get
        {
            try
            {
                return newValue["TenKH"].ToString();
            }
            catch (Exception)
            {
                return ID.ToString();
            }
        }
        set { }
    }
    public decimal TongTien { get; set; }

    //chitet
    public int ID_HoaDonDV { get; set; }
    public int ID_Hang { get; set; }
    public int SoLuong { get; set; }
    public decimal DonGia { get; set; }
    public decimal ThanhTien { get; set; }

    #endregion

}