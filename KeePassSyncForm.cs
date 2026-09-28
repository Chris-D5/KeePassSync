
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using KeePass.Forms;
using KeePass.Plugins;
using KeePassLib;
using KeePassLib.Collections;
using KeePassLib.Utility;

namespace KeePassSync
{
  public sealed class KeePassSyncForm : Form
  {
    private FlowLayoutPanel database1Panel;
    private Label database1Label;
    private Button database1Button;

    private FlowLayoutPanel database2Panel;
    private Label database2Label;
    private Button database2Button;

    private FlowLayoutPanel comparisonPanel;
    private Label comparisonLabel;

    public KeePassSyncForm(PwDatabase database)
    {
      Text = "KeePassSync";
      Width = 500;
      Height = 800;

      // Database 1
      database1Panel = new FlowLayoutPanel();
      database1Panel.AutoSize = true;
      database1Panel.Location = new Point(20, 20);

      database1Label = new Label();
      database1Label.Text = database.Name +
                            " (" + UrlUtil.GetFileName(database.IOConnectionInfo.Path) + ")";
      database1Label.AutoSize = true;

      database1Button = new Button();
      database1Button.Text = "Browse";
      database1Button.AutoSize = true;
      database1Button.Click += selectDatabase1;

      database1Panel.Controls.Add(database1Label);
      database1Panel.Controls.Add(database1Button);

      // Database 2
      database2Panel = new FlowLayoutPanel();
      database2Panel.AutoSize = true;
      database2Panel.Location = new Point(20, 60);

      database2Label = new Label();
      database2Label.Text = "Select a Database";
      database2Label.AutoSize = true;

      database2Button = new Button();
      database2Button.Text = "Browse";
      database2Button.AutoSize = true;

      database2Panel.Controls.Add(database2Label);
      database2Panel.Controls.Add(database2Button);

      Controls.Add(database2Panel);


      // Comparison
      comparisonPanel = new FlowLayoutPanel();
      comparisonPanel.AutoSize = true;
      comparisonPanel.Location = new Point(20, 100);

      comparisonLabel = new Label();
      comparisonLabel.AutoSize = true;

      comparisonPanel.Controls.Add(comparisonLabel);

      Controls.Add(comparisonPanel);

      Controls.Add(database1Panel);

      Button button = new Button();

      button.Text = "OK";

      button.Click += (sender, e) =>
      {
        Close();
      };

      Controls.Add(button);
    }

    private String getFilePath()
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "KeePass database file | *.kdbx";
      openFileDialog.Multiselect = false;
      //checked if a file was even opened
      bool? success = openFileDialog.ShowDialog() == DialogResult.OK;


      if (success != true)
      {
        return null;
      }

      String filePath = openFileDialog.FileName;

      return filePath;
    }

    private void selectDatabase(Label label)
    {
      PwDatabase database = null;

      String filePath = getFilePath();

      String databaseName = "";

      if (filePath == null)
      {
        databaseName = "Select a Database";

      }
      else
      {
        databaseName = filePath;
      }
      database1Label.Text = databaseName;

      if (false)
      {
        database1Label.Text = database.Name +
                           " (" + UrlUtil.GetFileName(database.IOConnectionInfo.Path) + ")";
      }

    }

    public void selectDatabase1(Object sender, EventArgs e)
    {
      selectDatabase(database1Label);
    }


    public void selectDatabase2(Object sender, EventArgs e)
    {
      selectDatabase(database2Label);
    }
  }
}
