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

public partial class UC_UC_ThHang : System.Web.UI.UserControl, IThHang
{
    #region Variable

    private string _message = "";
    private GridEditableItem editableItem;
    private Hashtable newValue;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Default2)Page).SetTitle("Quản lý hàng ");
    }
    protected void txtsearch_OnTextChanged(object sender, EventArgs e)
    {
        var presenter = new PThHang(this);
        DataTable dt;
        dt = presenter.List(txtsearch.Text);
        RadGrid1.DataSource = dt;
        RadGrid1.DataBind();
    }

    protected void RadGrid1_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        var presenter = new PThHang(this);
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
        var txtdongianhap = e.Item.FindControl("txtdongianhap") as RadNumericTextBox;
        var txtdongiaban = e.Item.FindControl("txtdongiaban") as RadNumericTextBox;
        var txtidhang = e.Item.FindControl("txtidhang") as RadTextBox;

        if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
        {
            var item = (GridEditFormItem)e.Item;
            if (!(e.Item is IGridInsertItem))
            {
                txtdongianhap.Text = DataBinder.Eval(e.Item.DataItem, "DonGiaNhap").ToString();
                txtdongiaban.Text = DataBinder.Eval(e.Item.DataItem, "DonGiaBan").ToString();

            }
            txtidhang.Text = DataBinder.Eval(e.Item.DataItem, "ID").ToString();
        }
    }

    protected void RadGrid1_OnInsertCommand(object sender, GridCommandEventArgs e)
    {
        newValue = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);
        var presenter = new PThHang(this);
        var txtdongianhap = e.Item.FindControl("txtdongianhap") as RadNumericTextBox;
        var txtdongiaban = e.Item.FindControl("txtdongiaban") as RadNumericTextBox;

        if (txtdongianhap != null)
            DonGiaNhap = Convert.ToDecimal(txtdongianhap.Text);
        if (txtdongiaban != null)
            DonGiaBan = Convert.ToDecimal(txtdongiaban.Text);
        SLTon = 0;

        Message = presenter.Inseart() ? "Thêm thành công" : "Thêm thất bại";
        if (Message == "Thêm thành công")
        {
        }
    }

    protected void RadGrid1_OnUpdateCommand(object o, GridCommandEventArgs e)
    {
        newValue = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);
        var presenter = new PThHang(this);

        var txtdongianhap = e.Item.FindControl("txtdongianhap") as RadNumericTextBox;
        var txtdongiaban = e.Item.FindControl("txtdongiaban") as RadNumericTextBox;
        var txtidhang = e.Item.FindControl("txtidhang") as RadTextBox;

        DonGiaNhap = Convert.ToDecimal(txtdongianhap.Text);
        DonGiaBan = Convert.ToDecimal(txtdongiaban.Text);
        ID = Convert.ToInt32(txtidhang.Text);

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
        var txtidphieuchi = e.Item.FindControl("LayoutTypeIDLabel") as Label;
        ID = Convert.ToInt32(txtidphieuchi.Text);
        var presenter = new PThHang(this);

        Message = presenter.Delete() ? "Xóa xong" : "Không xóa được nè";
        if (Message == "Xóa xong")
        {
        }
    }

    #region implement
    public int ID { get; set; }
    public int SLTon { get; set; }
    public decimal DonGiaNhap { get; set; }
    public decimal DonGiaBan { get; set; }
    
    public string Ten
    {
        get
        {
            try
            {
                return newValue["Ten"].ToString();
            }
            catch (Exception)
            {
                return ID.ToString();
            }
        }
        set { }
    }
    public string DonVi
    {
        get
        {
            try
            {
                return newValue["DonVi"].ToString();
            }
            catch (Exception)
            {
                return ID.ToString();
            }
        }
        set { }
    }
  

    public string Message { get; set; }

    #endregion

}