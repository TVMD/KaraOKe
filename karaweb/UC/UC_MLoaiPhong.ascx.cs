﻿using System;
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

public partial class UC_UC_MLoaiPhong : System.Web.UI.UserControl , IMLoaiPhong
{
    #region Variable

    private string _message = "";
    private GridEditableItem editableItem;
    private Hashtable newValue;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        ((Default2)Page).SetTitle("Quản lý danh sách các loại phòng");
    }

    protected void txtsearch_OnTextChanged(object sender, EventArgs e)
    {
        var presenter = new PMLoaiPhong(this);
        DataTable dt;
        dt = presenter.List(txtsearch.Text);
        RadGrid1.DataSource = dt;
        RadGrid1.DataBind();
    }

    protected void RadGrid1_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        var presenter = new PMLoaiPhong(this);
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
        var txtgiangay = e.Item.FindControl("txtgiangay") as RadNumericTextBox;
        var txtgiadem = e.Item.FindControl("txtgiadem") as RadNumericTextBox;
        var txtidphong = e.Item.FindControl("txtidphong") as RadTextBox;

        if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
        {
            var item = (GridEditFormItem)e.Item;
            if (!(e.Item is IGridInsertItem))
            {
                txtgiangay.Text = DataBinder.Eval(e.Item.DataItem, "GiaNgay").ToString();
                txtgiadem.Text = DataBinder.Eval(e.Item.DataItem, "GiaDem").ToString();
            }
            txtidphong.Text = DataBinder.Eval(e.Item.DataItem, "ID").ToString();
        }
    }

    protected void RadGrid1_OnInsertCommand(object sender, GridCommandEventArgs e)
    {
        newValue = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);
        var presenter = new PMLoaiPhong(this);

        var txtgiangay = e.Item.FindControl("txtgiangay") as RadNumericTextBox;
        var txtgiadem = e.Item.FindControl("txtgiadem") as RadNumericTextBox;

        if (txtgiangay != null) 
            GiaNgay = Convert.ToDecimal(txtgiangay.Text);
        if (txtgiadem != null) 
            GiaDem = Convert.ToDecimal(txtgiadem.Text);
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
        var presenter = new PMLoaiPhong(this);

        var txtgiangay = e.Item.FindControl("txtgiangay") as RadNumericTextBox;
        var txtgiadem = e.Item.FindControl("txtgiadem") as RadNumericTextBox;
        var txtidphong = e.Item.FindControl("txtidphong") as RadTextBox;
        GiaNgay = Convert.ToDecimal(txtgiangay.Text);
        GiaDem = Convert.ToDecimal(txtgiadem.Text);
        ID = Convert.ToInt32(txtidphong.Text);

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
        var presenter = new PMLoaiPhong(this);

        Message = presenter.Delete() ? "Xóa xong" : "Không xóa được nè";
        if (Message == "Xóa xong")
        {
        }
    }

    #region implement
    public int ID { get; set; }

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

    public decimal GiaNgay { get; set; }
    public decimal GiaDem { get; set; }
    public int SoLuong { get; set; }
    public string Message { get; set; }
   
    #endregion

   
}