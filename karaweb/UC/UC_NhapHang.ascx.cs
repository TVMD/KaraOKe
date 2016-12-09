using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using IVIEW;
using PRESENTER;
using Telerik.Web.UI;
using System.Web.UI.WebControls;
using MODEL;

public partial class UC_UC_NhapHang : System.Web.UI.UserControl,IHDNhap
{
    #region Variable

    private string _message = "";
    private GridEditableItem editableItem;
    private Hashtable newValue;
    private Hashtable newValueCT;
    private int currentId=2;
    
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["curID"] ==null)
            Session["curID"] = 2;
    }
    protected void txtsearch_OnTextChanged(object sender, EventArgs e)
    {
        var presenter = new PHDNhap(this);
        RadGrid1.DataSource = presenter.List(txtsearch.Text);
        RadGrid1.DataBind();
    }

    protected void RadGrid1_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
       //nó tự binjd trong hàm này
        var presenter = new PHDNhap(this);
        DataTable dt;
        if (txtsearch.Text == "")
            dt = presenter.List(null);
        else
        {
            dt = presenter.List(txtsearch.Text);
        }
        RadGrid1.DataSource = dt;
        //RadGrid1.DataBind();
    }
    protected void RadGrid2_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        var presenter = new PHDNhap(this);
        DataTable dt;
        if (txtsearch.Text == "")
            //dt = presenter.ListCT(null,currentId);
            dt = presenter.ListCT(null, int.Parse(Session["curID"].ToString()));
        else
        {
            //dt = presenter.ListCT(txtsearch.Text,currentId);
            dt = presenter.ListCT(txtsearch.Text, int.Parse(Session["curID"].ToString()));
        }
        RadGrid2.DataSource = dt;
        //RadGrid1.DataBind(); nó tự binjd trong hàm này
    }

    protected void RadGrid1_OnItemCreated(object sender, GridItemEventArgs e)
    {
        var item = e.Item as GridEditableItem;
        if (item!=null && e.Item.IsInEditMode && e.Item.ItemIndex != -1)
        {
            (item.EditManager.GetColumnEditor("ID").ContainerControl.Controls[0] as TextBox).Enabled = false;
        }
    }
    protected void RadGrid2_OnItemCreated(object sender, GridItemEventArgs e)
    {
        var item = e.Item as GridEditableItem;
        if (item != null && e.Item.IsInEditMode && e.Item.ItemIndex != -1)
        {
            (item.EditManager.GetColumnEditor("ThanhTien").ContainerControl.Controls[0] as TextBox).Enabled = false;
        }
    }
   

    protected void RadGrid1_OnItemDataBound(object sender, GridItemEventArgs e)
    {
        //var cboKhoa = e.Item.FindControl("k") as RadComboBox;
        //if (cboKhoa != null)
        //{
        //    var presenter = new PHDNhap(this);
        //    var DsKhoa = presenter.GetAllLoaiPhong();

        //    cboKhoa.DataTextField = "Ten";
        //    cboKhoa.DataValueField = "ID";
        //    cboKhoa.DataSource = DsKhoa;
        //    cboKhoa.DataBind();
        //}
    }
    protected void RadGrid2_OnItemDataBound(object sender, GridItemEventArgs e)
    {
        var cboHang = e.Item.FindControl("cbHang") as RadComboBox;
        if (cboHang != null)
        {
            var presenter = new PHDNhap(this);
            var DsHang = presenter.GetAllLoaiPhong();

            cboHang.DataTextField = "Ten";
            cboHang.DataValueField = "ID";
            cboHang.DataSource = DsHang;
            cboHang.SelectedValue = Session["currentHang"].ToString();
            cboHang.DataBind();
           
        }
        if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
        {
            //var item = (GridEditFormItem)e.Item;
            GridEditableItem item = e.Item as GridEditableItem;
            //var combo = (RadComboBox)item.FindControl("cbHang");
            //if (!(e.Item is IGridInsertItem))
            //{

            //    combo.SelectedValue = ((CT_HDNHAP)item.DataItem).IDHang.ToString();
            //    item.DataItem["IDHang"]
            //}

        }
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            Session["currentHang"] = item["IDHang"].Text;

        }
       
    }

    protected void RadGrid1_OnInsertCommand(object sender, GridCommandEventArgs e)
    {
        newValue = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);
        var presenter = new PHDNhap(this);

        //var cbb = e.Item.FindControl("k") as RadComboBox;
        //IdLoaiPhong = Convert.ToInt32(cbb.SelectedValue);
        Message = presenter.Inseart() ? "Thêm thành công" : "Thêm thất bại";
        if (Message == "Thêm thành công")
        {
        }
    }
    protected void RadGrid2_OnInsertCommand(object sender, GridCommandEventArgs e)
    {
        newValueCT = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValueCT, editableItem);
        var presenter = new PHDNhap(this);
        var cbb = e.Item.FindControl("cbHang") as RadComboBox;
        IDHang = Convert.ToInt32(cbb.SelectedValue);
        //var cbb = e.Item.FindControl("k") as RadComboBox;
        //IdLoaiPhong = Convert.ToInt32(cbb.SelectedValue);
       // Message = presenter.InseartCT(currentId) ? "Thêm thành công" : "Thêm thất bại";
        Message = presenter.InseartCT(int.Parse(Session["curID"].ToString())) ? "Thêm thành công" : "Thêm thất bại";
        if (Message == "Thêm thành công")
        {
            loadHD();
        }
    }

    void loadHD()
    {
        var presenter = new PHDNhap(this);
        DataTable dt;
        if (txtsearch.Text == "")
            dt = presenter.List(null);
        else
        {
            dt = presenter.List(txtsearch.Text);
        }
        RadGrid1.DataSource = dt;
        RadGrid1.DataBind(); 
    }
    protected void RadGrid1_OnUpdateCommand(object o, GridCommandEventArgs e)
    {
        newValue = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);
        var presenter = new PHDNhap(this);

        
        Message = presenter.Update() ? "Đã cập nhật" : "Cập nhật bị lỗi";
        if (Message == "Đã cập nhật")
        {
        }
    }
    protected void RadGrid2_OnUpdateCommand(object o, GridCommandEventArgs e)
    {
        newValueCT = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValueCT, editableItem);
        var presenter = new PHDNhap(this);

        var cbb = e.Item.FindControl("cbHang") as RadComboBox;
        IDHang = Convert.ToInt32(cbb.SelectedValue);
        Message = presenter.UpdateCT(int.Parse(Session["curID"].ToString())) ? "Đã cập nhật" : "Cập nhật bị lỗi";
        if (Message == "Đã cập nhật")
        {
            loadHD();
        }
    }

    protected void RadGrid1_OnDeleteCommand(object sender, GridCommandEventArgs e)
    {
        newValue = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);
        var presenter = new PHDNhap(this);

        Message = presenter.Delete() ? "Xóa xong" : "Không xóa được nè";
        if (Message == "Xóa xong")
        {
        }
    }
    protected void RadGrid2_OnDeleteCommand(object sender, GridCommandEventArgs e)
    {
        newValueCT = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValueCT, editableItem);
        var presenter = new PHDNhap(this);

        Message = presenter.DeleteCT(currentId) ? "Xóa xong" : "Không xóa được nè";
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

    public decimal TongTien
    {
        get
        {
            try
            {
                return Convert.ToDecimal(newValue["TongTien"].ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        set { }
    }

    public DateTime NgayNhap
    {
        get
        {
            try
            {
                return Convert.ToDateTime(newValue["NgayNhap"].ToString());  
            }
            catch (Exception)
            {
                return Convert.ToDateTime("00/00/0000");  
            }
        }
        set { }
    }
    public int IDHang
    {
        get
        {
            try
            {
                return Convert.ToInt32(newValueCT["IDHang"].ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        set { }
    }
    public int IDHoaDon { get; set; }

    public int SoLuong
    {
        get
        {
            try
            {
                return Convert.ToInt32(newValueCT["SoLuong"].ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        set { }
    }
    public decimal DonGiaNhap
    {
        get
        {
            try
            {
                return Convert.ToDecimal(newValueCT["DonGiaNhap"].ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        set { }
    }
    public decimal ThanhTien
    {
        get
        {
            try
            {
                return Convert.ToInt32(newValueCT["ThanhTien"].ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        set { }
    }
    public string Message { get; set; }
    public string TenHang { get; set; }
    #endregion
    protected void RadGrid1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        GridDataItem item = (GridDataItem)RadGrid1.SelectedItems[0];//get selected row
        var presenter = new PHDNhap(this);
        DataTable dt;
        dt = presenter.ListCT(null, int.Parse(item["ID"].Text));
        currentId = int.Parse(item["ID"].Text);
        RadGrid2.DataSource = dt;
        RadGrid2.DataBind();
        Session["curID"] = int.Parse(item["ID"].Text);
    }
    protected void RadGrid2_PreRender(object sender, EventArgs e)
    {
        //RadGrid2.MasterTableView.GetColumn("IDHang").Visible = false;
        RadGrid2.Rebind(); 
    }
    protected void RadGrid2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int a = 0;
    }
}