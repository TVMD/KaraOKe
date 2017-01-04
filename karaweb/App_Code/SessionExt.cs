using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using MODEL;

/// <summary>
/// Summary description for SessionExt
/// </summary>
public static class SessionExt
{
	
    public static void setCurrentUser(this HttpSessionState session, NGUOIDUNG user){
        session["currentUser"] = user;
    }
    public static NGUOIDUNG getCurrentUser(this HttpSessionState session)
    {
        return session["currentUser"] as NGUOIDUNG;
    }
    public static void setRole(this HttpSessionState session, NHOMQUYEN role)
    {
        session["role"] = role;
    }
    public static NHOMQUYEN getRole(this HttpSessionState session)
    {
        return session["role"] as NHOMQUYEN;
    }
}