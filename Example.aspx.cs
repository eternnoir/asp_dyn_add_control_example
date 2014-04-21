using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Example : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session.Remove("textList");
            Session.Remove("DrpList"); ;
        }
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        recreateText();
        recreateDropDownList(); ;
    }

    private void recreateDropDownList()
    {
        var drpList = (List<DropDownList>)Session["DrpList"] ?? new List<DropDownList>();
        foreach (DropDownList dropDownList in drpList)
        {
            dropDownList.SelectedValue = findControlValue(dropDownList.ID);
            dropListPanel.Controls.Add(dropDownList);
            dropListPanel.Controls.Add(new LiteralControl("<br>"));
        }
    }

    private void recreateText()
    {
        var textList = (List<TextBox>)Session["textList"] ?? new List<TextBox>();
        foreach (TextBox textBox in textList)
        {
            textBox.Text = findControlValue(textBox.ID);
            textPanel.Controls.Add(textBox);
            textPanel.Controls.Add(new LiteralControl("<br>"));
        }
    }

    private string findControlValue(string id)
    {
        var ctrls = Request.Form.ToString().Split('&');
        foreach (string ctrl in ctrls)
        {
            if (ctrl.Contains(id))
            {
                return ctrl.Split('=')[1];
            }
        }
        return null;
    }

    protected void btnAddText_Click(object sender, EventArgs e)
    {
        var textList = (List<TextBox>)Session["textList"] ?? new List<TextBox>();
        var newTextBox = new TextBox();
        newTextBox.ID = "txt_" + textList.Count + 1;
        textList.Add(newTextBox);
        Session["textList"] = textList;
    }
    protected void bntAddDropList_Click(object sender, EventArgs e)
    {
        var drpList = (List<DropDownList>) Session["DrpList"] ?? new List<DropDownList>();
        var newDrpList = new DropDownList();
        newDrpList.ID = "drp_" + drpList.Count + 1;
        for (int i = 1; i < 5; i++)
        {
            newDrpList.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        drpList.Add(newDrpList);
        Session["DrpList"] = drpList;
    }

}