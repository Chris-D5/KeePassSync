using System;
using System.Collections.Generic;

using KeePass.Plugins;

namespace KeePassSync
{
  public sealed class KeePassSyncExt : Plugin
  {
    private IPluginHost m_host = null;

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
  }
}
