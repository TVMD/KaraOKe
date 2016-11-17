using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using IVIEW;
using PRESENTER;
using Telerik.Web.UI;

public partial class UC_UC_SinhVien : UserControl, ISinhVien
{
    #region Variable

    private string _message = "";
    private GridEditableItem editableItem;
    private Hashtable newValue;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void txtsearch_OnTextChanged(object sender, EventArgs e)
    {
        var presenter = new PSinhVien(this);
        RadGrid1.DataSource = presenter.List(txtsearch.Text);
        RadGrid1.DataBind();
    }

    protected void RadGrid1_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        var presenter = new PSinhVien(this);
        DataTable dt;
        if (txtsearch.Text == "")
            dt = presenter.List(null);
        else
        {
            dt = presenter.List(txtsearch.Text);
        }
        RadGrid1.DataSource = dt;
        //RadGrid1.DataBind(); nó tự binjd trong hàm này
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
        var cboKhoa = e.Item.FindControl("k") as RadComboBox;
        if (cboKhoa != null)
        {
            var presenter = new PSinhVien(this);
            var DsKhoa = presenter.GetAllKhoa();

            cboKhoa.DataTextField = "TenKhoa";
            cboKhoa.DataValueField = "ID";
            cboKhoa.DataSource = DsKhoa;
            cboKhoa.DataBind();
        }
    }

    protected void RadGrid1_OnInsertCommand(object sender, GridCommandEventArgs e)
    {
        newValue = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);
        var presenter = new PSinhVien(this);

        var cbb = e.Item.FindControl("k") as RadComboBox;
        IDKhoa = Convert.ToInt32(cbb.SelectedValue);
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
        var presenter = new PSinhVien(this);

        var cbb = e.Item.FindControl("k") as RadComboBox;
        IDKhoa = Convert.ToInt32(cbb.SelectedValue);
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
        var presenter = new PSinhVien(this);

        Message = presenter.Delete() ? "Xóa xong" : "Không xóa được nè";
        if (Message == "Xóa xong")
        {
        }
    }

    #region Implement View

    public int ID
    {
        get
        {
            try
            {
                return Convert.ToInt32(newValue["ID"].ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        set { }
    }

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
                return "";
            }
        }
        set { }
    }

    public int IDKhoa { get; set; }

    public string Message { get; set; }

    #endregion
}