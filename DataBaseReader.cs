using System;
using System.Collections.Generic;

using KeePass.Forms;
using KeePass.Plugins;
using KeePassLib;
using KeePassLib.Collections;

public sealed class DataBaseReader
{
  internal class EntryInfo
  {
    private string Title { get; set; }
    private string Username { get; set; }
    private string Url { get; set; }
    public EntryInfo(string Title, string Username, string Url)
    {
      this.Title = Title;
      this.Username = Username;
      this.Url = Url;
    }
  }

  internal static List<EntryInfo> ReadDatabase(PwDatabase database)
  {
    var entries = new List<EntryInfo>();

    foreach (PwEntry entry in database.RootGroup.GetEntries(true))
    {
      entries.Add(new EntryInfo(
            entry.Strings.ReadSafe("Title"),
            entry.Strings.ReadSafe("UserName"),
            entry.Strings.ReadSafe("URL")));
    }
    return entries;
  }

}
