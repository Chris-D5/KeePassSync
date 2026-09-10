using System;
using System.Collections.Generic;
using System.Windows.Forms;

using KeePass.Forms;
using KeePass.Plugins;
using KeePassLib;
using KeePassLib.Collections;

namespace KeePassSync
{
  public sealed class KeePassSyncExt : Plugin
  {
    private IPluginHost m_host;

    private List<DataBaseReader.EntryInfo> hostEntries;

    public override bool Initialize(IPluginHost host)
    {
      if (host == null) return false;
      m_host = host;
      return true;
    }

    public override void Terminate()
    {
      Console.WriteLine("KeePassSync Terminated");
    }

    public override ToolStripMenuItem GetMenuItem(PluginMenuType t)
    {
      if (t != PluginMenuType.Main) return null;
      ToolStripMenuItem tsmi = new ToolStripMenuItem("KeePassSync");

      //add menu item 'Synchronize'
      ToolStripMenuItem tsmiSynchronize = new ToolStripMenuItem("Synchronize");
      tsmiSynchronize.Click += this.OnDataSynchronize;
      tsmi.DropDownItems.Add(tsmiSynchronize);
      return tsmi;
    }
    private void OnDataSynchronize(object sender, EventArgs e)
    {
      Console.WriteLine("Synchronize Database");
      PwDatabase database = m_host.Database;
      hostEntries = DataBaseReader.ReadDatabase(database);

      Form form = new Form();
      Label label = new Label();
      label.Text = "Test";
      form.Controls.Add(label);
      form.Show();
    }
    private void OnOptionsClicked(object sender, EventArgs e)
    {
      // Called when the menu item is clicked
      Console.WriteLine("Clicked");
    }


  }
}
