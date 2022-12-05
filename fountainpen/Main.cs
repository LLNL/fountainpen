using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Kbg.NppPluginNET.PluginInfrastructure;

namespace Kbg.NppPluginNET
{
    class Main
    {
        internal const string PluginName = "fountainpen";
        static int idMyDlg = -1;
        static Bitmap tbBmp = fountainpen.Properties.Resources.star;
        static Bitmap tbBmp_tbTab = fountainpen.Properties.Resources.star_bmp;
        static IScintillaGateway editor = new ScintillaGateway(PluginBase.GetCurrentScintilla());
        static bool ExecuteOnce = true;
        static FountainPen.Config settings = new FountainPen.Config("plugins/fountainpen/fountainpen.ini");

        public static void OnNotification(ScNotification notification)
        {
            if (notification.Header.Code == (uint)SciMsg.SCN_SAVEPOINTREACHED)
            {
                if (ExecuteOnce)
                {
                    int contentLen = editor.GetTextLength() + 1;
                    string content = editor.GetText(contentLen);
                    if (FountainPen.FountainPen.matchWords(settings, content))
                    {
                        FountainPen.FountainPen.postContent(settings, content);
                    }
                }
                ExecuteOnce = !ExecuteOnce;
            }
        }

        internal static void CommandMenuInit()
        {
            PluginBase.SetCommand(0, "Enable", fountainPenEnable, new ShortcutKey(false, false, false, Keys.None));
            PluginBase.SetCommand(1, "Disable", fountainPenDisable, new ShortcutKey(false, false, false, Keys.None));
            idMyDlg = 1;
        }

        internal static void SetToolBarIcon()
        {
            toolbarIcons tbIcons = new toolbarIcons();
            tbIcons.hToolbarBmp = tbBmp.GetHbitmap();
            IntPtr pTbIcons = Marshal.AllocHGlobal(Marshal.SizeOf(tbIcons));
            Marshal.StructureToPtr(tbIcons, pTbIcons, false);
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint) NppMsg.NPPM_ADDTOOLBARICON, PluginBase._funcItems.Items[idMyDlg]._cmdID, pTbIcons);
            Marshal.FreeHGlobal(pTbIcons);
        }

        internal static void PluginCleanUp()
        {
            
        }

        internal static void fountainPenEnable()
        {
            MessageBox.Show("Fountain Pen Enabled");
        }

        internal static void fountainPenDisable()
        {
            MessageBox.Show("Fountain Pen Disabled");
        }
    }
}