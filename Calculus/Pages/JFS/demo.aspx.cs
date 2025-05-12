using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_JFS_demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
     {
            //lblheading.Text="It Just Deom Page!!!";
            Session.Remove("clicks");

    }
    }
    protected void btndeom_Click(object sender, EventArgs e)
    {
    //    int rowCount = Convert.ToInt32(textbox1.Text);
       
    //    int columnCount = Convert.ToInt32(textbox2.Text);
        
    //    Table table = new Table();

    //    table.ID = "table1";


    //    for (int i = 0; i < rowCount; i++)
    //    {

    //        TableRow row = new TableRow();

    //        for (int j = 0; j < columnCount; j++)
    //        {

    //            TableCell cell = new TableCell();

    //            TextBox TxtBoxU = new TextBox();


    //            TxtBoxU.ID = "TextBoxU" + i.ToString();

    //            cell.ID = "cell" + i.ToString();

    //            cell.Controls.Add(TxtBoxU);

    //            row.Cells.Add(cell);


    //        }


    //        table.Rows.Add(row);

    //    }

    //    pnldemo.Controls.Add(table);
    //    //Panel1.Controls.Add(table);

    //}

    }
    protected void btndeom_Click1(object sender, EventArgs e)
    {
        int rowCount = Convert.ToInt32(textbox1.Text);

            int columnCount = Convert.ToInt32(textbox2.Text);

            Table table = new Table();

            table.ID = "table1";


            for (int i = 0; i < rowCount; i++)
            {

                TableRow row = new TableRow();

                for (int j = 0; j < columnCount; j++)
                {

                    TableCell cell = new TableCell();

                    TextBox TxtBoxU = new TextBox();


                    TxtBoxU.ID = "TextBoxU" + i.ToString();

                    cell.ID = "cell" + i.ToString();

                    cell.Controls.Add(TxtBoxU);

                    row.Cells.Add(cell);


                }


                table.Rows.Add(row);

            }

            pnldemo.Controls.Add(table);
            //Panel1.Controls.Add(table);

        }

    protected void btnclickadd_Click(object sender, EventArgs e)
    {
      int rowCount = 0;

    //    //initialize a session.
        rowCount = Convert.ToInt32(Session["clicks"]);

        rowCount++;

    //    //In each button clic save the numbers into the session.
        Session["clicks"] = rowCount;


    //    //Create the textboxes and labels each time the button is clicked.
        for (int i = 0; i < rowCount; i++)
        {

            TextBox TxtBoxU = new TextBox();

           TextBox TxtBoxE = new TextBox();

            Label lblU = new Label();
            Label lblE = new Label();

            TxtBoxU.ID = "TextBoxU" + i.ToString();
            TxtBoxE.ID = "TextBoxE" + i.ToString();

            lblU.ID = "LabelU" + i.ToString();
            lblE.ID = "LabelE" + i.ToString();


            lblU.Text = "User " + (i + 1).ToString() + " : ";
            lblE.Text = "E-Mail : ";

            //Add the labels and textboxes to the Panel.
            pnldemo.Controls.Add(lblU);
            pnldemo.Controls.Add(TxtBoxU);

           pnldemo.Controls.Add(lblE);
           pnldemo.Controls.Add(TxtBoxE);



       }
   }
}
