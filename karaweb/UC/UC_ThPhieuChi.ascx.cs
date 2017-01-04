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

public partial class UC_UC_ThPhieuChi : System.Web.UI.UserControl, IThPhieuChi
{
    #region Variable

    private string _message = "";
    private GridEditableItem editableItem;
    private Hashtable newValue;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Default2)Page).SetTitle("Quản lý phiếu chi");
        
    }
    protected void txtsearch_OnTextChanged(object sender, EventArgs e)
    {
        var presenter = new PThPhieuChi(this);
        DataTable dt;
        dt = presenter.List(txtsearch.Text);
        RadGrid1.DataSource = dt;
        RadGrid1.DataBind();
    }

    protected void RadGrid1_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        var presenter = new PThPhieuChi(this);
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
        //    (item.EditManager.GetColumnEditor("NgayLap").ContainerControl.Controls[0] as RadDateTimePicker).SelectedDate = DateTime.Today;
        //}
        if (e.Item.IsInEditMode && e.Item is GridDataItem)
        {
            RadDateTimePicker rpk = (RadDateTimePicker)e.Item.FindControl("txtngaylap");
            rpk.SelectedDate = DateTime.Now;
        }
    }

    protected void RadGrid1_OnItemDataBound(object sender, GridItemEventArgs e)
    {

        var txttongtien = e.Item.FindControl("txttongtien") as RadNumericTextBox;
        var txtidphieuchi = e.Item.FindControl("txtidphieuchi") as RadTextBox;


        if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
        {
            var item = (GridEditFormItem)e.Item;
            if (!(e.Item is IGridInsertItem))
            {
                txttongtien.Text = DataBinder.Eval(e.Item.DataItem, "TongTien").ToString();

            }
            txtidphieuchi.Text = DataBinder.Eval(e.Item.DataItem, "ID").ToString();
        }

        //var item = e.Item as GridEditableItem;
        //if (item != null && e.Item.IsInEditMode && e.Item.ItemIndex != -1)
        //{
        //    (item.EditManager.GetColumnEditor("NgayLap").ContainerControl.Controls[0] as RadDateTimePicker).SelectedDate = DateTime.Now.Date;
        //}
        if (e.Item.IsInEditMode && e.Item is GridDataItem)
        {
            RadDateTimePicker rpk = (RadDateTimePicker)e.Item.FindControl("txtngaylap");
            rpk.SelectedDate = DateTime.Now;
        }
    }

    protected void RadGrid1_OnInsertCommand(object sender, GridCommandEventArgs e)
    {
        newValue = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);
        var presenter = new PThPhieuChi(this);
        var txttongtien = e.Item.FindControl("txttongtien") as RadNumericTextBox;

        if (txttongtien != null)
            TongTien = Convert.ToDecimal(txttongtien.Text);
       
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
        var presenter = new PThPhieuChi(this);

        var txttongtien = e.Item.FindControl("txttongtien") as RadNumericTextBox;
       
        var txtidphieuchi = e.Item.FindControl("txtidphieuchi") as RadTextBox;
        
        TongTien = Convert.ToDecimal(txttongtien.Text);
        ID = Convert.ToInt32(txtidphieuchi.Text);

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
        var presenter = new PThPhieuChi(this);

        Message = presenter.Delete() ? "Xóa xong" : "Không xóa được nè";
        if (Message == "Xóa xong")
        {
        }
    }

    #region implement
    public int ID { get; set; }

    public DateTime NgayLap
    {
        get
        {
            try
            {
               return  DateTime.Parse(newValue["NgayLap"].ToString());
                
            }
            catch (Exception)
            {
                return new DateTime();
            }
        }
        set { }
    }
    public string NoiDung
    {
        get
        {
            try
            {
                return newValue["NoiDung"].ToString();
            }
            catch (Exception)
            {
                return ID.ToString();
            }
        }
        set { }
    }

    public decimal TongTien { get; set; }
    public string GhiChu
    {
        get
        {
            try
            {
                return newValue["GhiChu"].ToString();
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