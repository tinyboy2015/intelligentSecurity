using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// IAutoComplete 的摘要说明
/// </summary>
public interface IAutoComplete
{
    string SelectedText
    {
        get;
        set;
    }
    string SelectedValue
    {
        get;
        set;
    }
    bool Enabled
    {
        get;
        set;
    }
    bool Visible
    {
        get;
        set;
    }
}
