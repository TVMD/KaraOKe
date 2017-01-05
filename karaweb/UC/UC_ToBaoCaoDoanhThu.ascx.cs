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
using Telerik.Web.UI.Calendar;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class UC_ToBaoCaoDoanhThu : System.Web.UI.UserControl,IToBCDoanhThu
{
    #region Variable

    private string _message = "";
    private GridEditableItem editableItem;
    private Hashtable newValue;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        ((Default2)Page).SetTitle("BÁO CÁO DOANH THU");
        TextArea2.Visible = false;
    }

    protected void txtsearch_OnTextChanged(object sender, EventArgs e)
    {
        //var presenter = new PMPhong(this);
        //DataTable dt;
        //dt = presenter.List(txtsearch.Text);
        //RadGrid1.DataSource = dt;
        //RadGrid1.DataBind();
    }

    protected void RadGrid1_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {        
        //var presenter = new PToBaoCaoDoanhThu(this);
        //RadGrid1.DataSource = presenter.GetListBCPhieuChi();
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
        //var cboKhoa = e.Item.FindControl("cbboxloaiphong") as RadComboBox;
        ////texrtbox id
        //var txtidphong = e.Item.FindControl("txtidphong") as RadTextBox;
        //if (cboKhoa != null)
        //{
        //    var presenter = new PMPhong(this);
        //    var dsloaiphong = presenter.GetAllLoaiPhong();

        //    cboKhoa.DataTextField = "Ten";
        //    cboKhoa.DataValueField = "ID";
        //    cboKhoa.DataSource = dsloaiphong;
        //    cboKhoa.DataBind();
        //}
        //if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
        //{
        //    var item = (GridEditFormItem)e.Item;
        //    var combo = (RadComboBox)item.FindControl("cbboxloaiphong");
        //    if (!(e.Item is IGridInsertItem))
        //    {
        //        combo.SelectedValue = DataBinder.Eval(item.DataItem, "IdLoaiPhong").ToString();
        //    }
        //    txtidphong.Text = DataBinder.Eval(e.Item.DataItem, "ID").ToString();
        //}
    }

    protected void RadGrid1_OnInsertCommand(object sender, GridCommandEventArgs e)
    {
        //newValue = new Hashtable();
        //editableItem = e.Item as GridEditableItem;
        //e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);
        //var presenter = new PMPhong(this);

        //var cbb = e.Item.FindControl("cbboxloaiphong") as RadComboBox;
        //IdLoaiPhong = Convert.ToInt32(cbb.SelectedValue);
        //Message = presenter.Inseart() ? "Thêm thành công" : "Thêm thất bại";
        //if (Message == "Thêm thành công")
        //{
        //}
    }

    protected void RadGrid1_OnUpdateCommand(object o, GridCommandEventArgs e)
    {
        //newValue = new Hashtable();
        //editableItem = e.Item as GridEditableItem;
        //e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);
        //var presenter = new PMPhong(this);

        //var cbb = e.Item.FindControl("cbboxloaiphong") as RadComboBox;
        //var txtidphong = e.Item.FindControl("txtidphong") as RadTextBox;
        //IdLoaiPhong = Convert.ToInt32(cbb.SelectedValue);
        //ID = Convert.ToInt32(txtidphong.Text);
        //Message = presenter.Update() ? "Đã cập nhật" : "Cập nhật bị lỗi";
        //if (Message == "Đã cập nhật")
        //{
        //}
    }

    protected void RadGrid1_OnDeleteCommand(object sender, GridCommandEventArgs e)
    {
        //newValue = new Hashtable();
        //editableItem = e.Item as GridEditableItem;
        //e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);
        //var presenter = new PMPhong(this);

        //Message = presenter.Delete() ? "Xóa xong" : "Không xóa được nè";
        //if (Message == "Xóa xong")
        //{
        //}
    }
    protected void OnDateSelectedFrom(object sender, SelectedDateChangedEventArgs e)
    {
        
    }

    #region Implement View
    public string Message { get; set; }
    public DateTime dateFrom { get; set; }

    public DateTime dateTo { get; set; }
    #endregion

    protected void RadDatePickerFrom_SelectedDateChanged(object sender, SelectedDateChangedEventArgs e)
    {
    }
    protected void RadDatePickerTo_SelectedDateChanged(object sender, SelectedDateChangedEventArgs e)
    {
    }

    protected void OnClick_Baocao(object sender, EventArgs e)
    {
        dateFrom = (DateTime) RadDatePickerFrom.SelectedDate;
        dateTo = (DateTime) RadDatePickerTo.SelectedDate;
        if (dateFrom > dateTo)
        {
            TextArea2.Visible = true;
            TextArea2.Value = "Sai. Ngày bắt đầu không được sau ngày kết thúc!";
        }
        else
        {
            TextArea2.Visible = false;
            var presenter = new PToBaoCaoDoanhThu(this);
            RadGrid1.DataSource = presenter.GetListBCDoanhThu();
            RadGrid1.DataBind();
            TextBox1.Text = presenter.getTongTien();
            //chi
            RadGrid2.DataSource = presenter.GetListBCPhieuChi();
            RadGrid2.DataBind();
            TextBox2.Text = presenter.getTongChi();
        }
        
    }


    protected void RadGrid2_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        
    }

    protected void RadGrid2_OnItemDataBound(object sender, GridItemEventArgs e)
    {
        
    }
}