using Weland;
using Gtk;
using System;
using System.Text;
using System.Collections.Generic;

public class Plugin {
  public static bool Compatible() { 
    return true;
  }

  public static string Name() {
    return "List Annotations";
  }

  public static void GtkRun(Editor editor) {
    Window[] all_top = Window.ListToplevels();
    Window frontmost = all_top[1];
    if (frontmost == null) {
      frontmost = all_top[0];
    }

    try {
      List<Annotation> annos = editor.Level.Annotations;
      string msg = String.Format("This level has {0} annotations.", annos.Count);
      StringBuilder dmsg = new StringBuilder();
      for (int i = 0; i < annos.Count; ++i) {
        dmsg.Append(annos[i].Text);
        dmsg.AppendLine();
      }

      MessageDialog m = new MessageDialog(frontmost,
                              DialogFlags.DestroyWithParent,
                              MessageType.Info,
                              ButtonsType.Close,
                              msg);
      m.Title = "Map Annotations";
      m.SecondaryText = dmsg.ToString();
      m.Run();
      m.Destroy();
    } catch (Exception e) {
      MessageDialog m = new MessageDialog(frontmost,
                              DialogFlags.DestroyWithParent,
                              MessageType.Error,
                              ButtonsType.Close,
                              "An error occured while running this plugin.");
      m.Title = "Plugin error";
      m.SecondaryText = string.Concat(e.Message, e.StackTrace);
      m.Run();
      m.Destroy();
    }
  }
}
