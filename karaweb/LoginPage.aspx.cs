using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL;

public partial class LoginPage : System.Web.UI.Page
{
    MTo_DangNhap model;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void onClickLogin(object sender, EventArgs e)
    {
        model = new MTo_DangNhap();
        if (String.IsNullOrEmpty(txtUser.Text.Trim()) || String.IsNullOrEmpty(txtPassword.Text.Trim()))
        {
            LabelError.Text = "Vui lòng kiểm tra lại Tên đăng nhập hoặc Mật khẩu.";
            return;
        }
        NGUOIDUNG user = new NGUOIDUNG();
        user = model.KiemTraTaiKhoan(txtUser.Text.Trim(), txtPassword.Text.Trim());
        if(user == null)
        {
            LabelError.Text = "Sai Tên đăng nhập hoặc Mật khẩu. Vui lòng kiểm tra lại!";
            return;
        }
        else
        {
            Session.setCurrentUser(user);
            NHOMQUYEN role = new NHOMQUYEN();
            role = model.LayNhomQuyen(user);
            Session.setRole(role);
            Response.Redirect("Default2.aspx");
        }
    }
}