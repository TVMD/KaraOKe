using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using IVIEW;
using MODEL;
using PRESENTER;
using Telerik.Web.UI;

public partial class UC_UC_MCT_Phong : System.Web.UI.UserControl , IMPhong, IMHoaDonDV
{
    private static PHONG phong;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        phong = (new PMPhong(this)).GetOne(ID);
        tenphong.Value = Ten;
        loaiphong.Value = IdLoaiPhong.ToString();
        status.Value = StatusId.ToString();
       
        if (StatusId == 3)
        {
            tgbatdau.Text = TGStart.ToString("dd/MM/yyyy HH:mm:ss");
            tenkh.Value = TenKH;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "chi", "btnbatdauclick();", true);
        }
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "loadjs", "ctphong_ready();", true);
    }

    #region implement iphong & variable

    private GridEditableItem editableItem;
    private Hashtable newValue;

    public string Message { get; set; }

    public int ID
    {
        get
        {
            return Int32.Parse(Default2.idphong ?? "0");
        }
        set { }
    }

    public string Ten
    {
        get { return phong!=null?phong.Ten:""; }
        set { }
    }

    public int StatusId
    {
        get { return phong != null ? phong.StatusID.GetValueOrDefault() : 0; }
        set { }
    }
    public DateTime TGStart
    {
        get
        {
            return phong.TGStart != null
                ? phong.TGStart.GetValueOrDefault()
                : (tgbatdau.Text != "" ? DateTime.ParseExact(tgbatdau.Text,"dd/MM/yyyy HH:mm:ss",null) : DateTime.Now);
        }
        set { }
    }
    public int IdLoaiPhong
    {
        get { return phong != null ? phong.IdLoaiPhong : -1; }
        set { }
    }
    public string TenLoaiPhong { get; set; }
    public float GiaNgay { get; set; }
    public float GiaDem { get; set; }
    #endregion

    #region implement ihoadon

    public int ID_HoaDon
    {
        get
        {
            try
            {
                return (new PMHoaDonDV(this)).GetLastByRom(ID).ID;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        set { }
    }

    public int ID_Phong {   
        get
        {
            try
            {
                return ID;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        set { }
    }
    public DateTime NgayGioLap {  
        get
        {
            try
            {
                return TGStart;
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }
        set { }
    }
    public string TenKH
    {
        get
        {
            try
            {
                return tenkh.Value;
            }
            catch (Exception)
            {
                return "";
            }
        }
        set { }
    }
    public decimal TongTien { get; set; }
    public int ID_HoaDonDV { get; set; }
    public int ID_Hang { get; set; }
    public int SoLuong { get; set; }
    public decimal DonGia { get; set; }
    public decimal ThanhTien { get; set; }

    #endregion

    protected void btnBatDauClick(object sender, EventArgs e)
    {
        tgbatdau.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        status.Value = "3"; //3 la busy 1 la free
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "batdau", "btnbatdauclick();", true);
        (new PMPhong(this)).Begin(tenkh.Value);

        RadGrid1.DataSource = new DataTable();

    }
    protected void btnTinhTienClick(object sender, EventArgs e)
    {
        status.Value = "1"; //3 la busy 1 la free
        (new PMPhong(this)).End();

        var presenter = new PMHoaDonDV(this);
        tongtienhang.Value = presenter.GetTongTienHang().ToString();
        tongtienthanhtoan.Value = presenter.GetOne(presenter.GetLastByRomChaged(ID).ID).TongTien.ToString();
        tienphong.Value = (Decimal.Parse(tongtienthanhtoan.Value) - Decimal.Parse(tongtienhang.Value)).ToString();

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tinhtien", "btntinhtienclick();", true);
    }

    protected void RadGrid1_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        try
        {
            RadGrid1.DataSource = (new PMCT_HDDV(this)).List_HD((new PMHoaDonDV(this)).GetLastByRom(ID).ID);
        }
        catch (NullReferenceException)
        {
            RadGrid1.DataSource = new List<object>();
        }
        if (StatusId == 3)
        {
            tgbatdau.Text = TGStart.ToString("dd/MM/yyyy HH:mm:ss");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onded", "btnbatdauclick();", true);
        }

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

    protected void RadGrid1_OnInsertCommand(object sender, GridCommandEventArgs e)
    {
        if (status.Value != "3")
            return;
        newValue = new Hashtable();
        editableItem = e.Item as GridEditableItem;
        e.Item.OwnerTableView.ExtractValuesFromItem(newValue, editableItem);
        
        var presenter = new PMCT_HDDV(this);

        var cbb = e.Item.FindControl("cbboxHang") as RadComboBox;
        var tbsoluong = e.Item.FindControl("txtsoluong") as RadNumericTextBox;
        ID_Hang = Int32.Parse(cbb.SelectedValue);
        SoLuong = int.Parse(tbsoluong.Text);

        Message = presenter.Inseart() ? "Thêm thành công" : "Thêm thất bại";
        if (Message == "Thêm thành công")
        {
            RadGrid1.DataBind();
        }
    }

    protected void RadGrid1_OnUpdateCommand(object sender, GridCommandEventArgs e)
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

    protected void RadGrid1_OnDeleteCommand(object sender, GridCommandEventArgs e)
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
}