using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IVIEW;
using MODEL;
using PRESENTER;
using System.Collections;
using Telerik.Web.UI;

public partial class UC_UC_ToNguoiDung : System.Web.UI.UserControl, IToNguoiDung
{
    #region Variable

    private string _message = "";
    private GridEditableItem editableItem;
    private Hashtable newValue;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        ((Default2)Page).SetTitle("Quản lý người dùng");
    }

    protected void txtsearch_OnTextChanged(object sender, EventArgs e)
    {
        var presenter = new PToNguoiDung(this);
        List<GetListNguoiDung_Result> dt = presenter.List(txtsearch.Text);
        RadGrid1.DataSource = dt;
        RadGrid1.DataBind();
    }

    protected void RadGrid1_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        var presenter = new PToNguoiDung(this);
        List<GetListNguoiDung_Result> dt;
        if (txtsearch.Text == "")
            dt = presenter.List(null);
        else
        {
            dt = presenter.List(txtsearch.Text);
        }
        RadGrid1.DataSource = dt;
    }
    protected void RadGrid1_PreRender(object sender, EventArgs e)
    {
        RadGrid1.MasterTableView.GetColumn("ID").Visible = false;
        RadGrid1.MasterTableView.GetColumn("MatKhau").Visible = false;
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
        var cboNhomQuyen = e.Item.FindControl("cbboxnhomquyen") as RadComboBox;
        if (cboNhomQuyen != null)
        {
            var presenter = new PToNguoiDung(this);
            var dsNhomquyen = presenter.ListNhomQuyen();

            cboNhomQuyen.DataTextField = "TenNhomQuyen";
            cboNhomQuyen.DataValueField = "MaNhomQuyen";
            cboNhomQuyen.DataSource = dsNhomquyen;
            cboNhomQuyen.DataBind();
        }
        if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
        {
            var item = (GridEditFormItem)e.Item;
            var combo = (RadComboBox)item.FindControl("cbboxnhomquyen");
            var text_id = (RadTextBox)item.FindControl("id_nguoidung");
            var matkhau = (RadTextBox)item.FindControl("txtmatkhau");
            if (!(e.Item is IGridInsertItem))
            {
                combo.SelectedValue = DataBinder.Eval(item.DataItem, "MaNhomQuyen").ToString();
                text_id.Text = DataBinder.Eval(item.DataItem, "ID").ToString();
                matkhau.Text = DataBinder.Eval(item.DataItem, "MatKhau").ToString();
            }
            

        }
    }

    protected void RadGrid1_OnInsertCommand(object sender, GridCommandEventArgs e)
    {
        newValue = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);
        var presenter = new PToNguoiDung(this);

        var cbb = e.Item.FindControl("cbboxnhomquyen") as RadComboBox;
        MaNhomQuyen = Convert.ToInt32(cbb.SelectedValue);
        var matkhau = e.Item.FindControl("txtmatkhau") as RadTextBox;
        MatKhau = matkhau.Text;
        Message = presenter.Insert() ? "Thêm thành công" : "Thêm thất bại";
        if (Message == "Thêm thành công")
        {
        }
    }

    protected void RadGrid1_OnUpdateCommand(object o, GridCommandEventArgs e)
    {
        newValue = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);
        var presenter = new PToNguoiDung(this);

        var cbb = e.Item.FindControl("cbboxnhomquyen") as RadComboBox;
        MaNhomQuyen = Convert.ToInt32(cbb.SelectedValue);
        var id = e.Item.FindControl("id_nguoidung") as RadTextBox;
        ID = int.Parse(id.Text);
        var matkhau = e.Item.FindControl("txtmatkhau") as RadTextBox;
        MatKhau = matkhau.Text;
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
        var presenter = new PToNguoiDung(this);

        var id = e.Item.FindControl("id_nguoidung_item") as Label;
        ID = int.Parse(id.Text);

        Message = presenter.Delete() ? "Xóa xong" : "Không xóa được nè";
        if (Message == "Xóa xong")
        {
        }
    }
    #region Implement View
    public int ID
    {
        get;
        set;
    }

    public string MaDangNhap { 
        get
        {
            try
            {
                return newValue["MaDangNhap"].ToString();
            }
            catch { return null; }
            
        }
        set { }
    }

    public string MatKhau
    {
        get;
        set;
    }

    public string HoTen
    {
        get
        {
            try
            {
                return newValue["HoTen"].ToString();
            }
            catch { return null; }
            
        }
        set { }
    }

    public string Email
    {
        get
        {
            try
            {
                return newValue["Email"].ToString();
            }
            catch { return null; }
            
        }
        set { }
    }

    public string SoDT
    {
        get
        {
            try
            {
                return newValue["SoDT"].ToString();
            }
            catch { return null; }
            
        }
        set { }
    }

    public int MaNhomQuyen { get; set; }
    public string Message { get; set; }
    #endregion



    
}