using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace Msticky
{
    class Config
    {
        public static class Key
        {
            public const string OpenFile = "Open File";
            public const string BeforeHistory = "Before History";
            public const string AfterHistory = "After History";
            public const string OpenContainingFolder = "Open Containing Folder";
            public const string Close = "Close";

            public const string ZoomIn = "Zoom In";
            public const string ZoomOut = "Zoom Out";
            public const string Fit = "Fit";
            public const string IncreaseOpacity = "Increase Opacity";
            public const string DecreaseOpacity = "Decrease Opacity";
            public const string OpacityMax = "Opacity Max";
            public const string OpacityMin = "Opacity Min";
            public const string CW = "CW";
            public const string CCW = "CCW";
            public const string ResetRotation = "Reset Rotation";
            public const string FlipHorizontal = "Flip Horizontal";

            public const string PasteFromClipboard = "PasteFromClipboard";
            public const string Duplicate = "Duplicate";
        }

        public static void Initialize()
        {
            Properties.Settings.Default.Zoom = 10;
            Properties.Settings.Default.Rotate = 2;

            Properties.Settings.Default.Shortcut = new XmlSerializableNameValueCollection();
            Properties.Settings.Default.Shortcut.Add(Key.OpenFile, ((int)(Keys.Control | Keys.O)).ToString());
            Properties.Settings.Default.Shortcut.Add(Key.BeforeHistory, ((int)(Keys.LWin)).ToString());
            Properties.Settings.Default.Shortcut.Add(Key.AfterHistory, ((int)(Keys.Apps)).ToString());
            Properties.Settings.Default.Shortcut.Add(Key.OpenContainingFolder, ((int)(Keys.Control | Keys.C)).ToString());
            Properties.Settings.Default.Shortcut.Add(Key.Close, ((int)(Keys.Control | Keys.Q)).ToString());
            Properties.Settings.Default.Shortcut.Add(Key.ZoomIn, ((int)Keys.X).ToString());
            Properties.Settings.Default.Shortcut.Add(Key.ZoomOut, ((int)Keys.C).ToString());
            Properties.Settings.Default.Shortcut.Add(Key.Fit, ((int)Keys.Z).ToString());
            Properties.Settings.Default.Shortcut.Add(Key.IncreaseOpacity, ((int)Keys.S).ToString());
            Properties.Settings.Default.Shortcut.Add(Key.DecreaseOpacity, ((int)Keys.A).ToString());
            Properties.Settings.Default.Shortcut.Add(Key.OpacityMax, ((int)(Keys.Shift | Keys.S)).ToString());
            Properties.Settings.Default.Shortcut.Add(Key.OpacityMin, ((int)(Keys.Shift | Keys.A)).ToString());
            Properties.Settings.Default.Shortcut.Add(Key.CW, ((int)Keys.E).ToString());
            Properties.Settings.Default.Shortcut.Add(Key.CCW, ((int)Keys.W).ToString());
            Properties.Settings.Default.Shortcut.Add(Key.ResetRotation, ((int)(Keys.Shift | Keys.R)).ToString());
            Properties.Settings.Default.Shortcut.Add(Key.FlipHorizontal, ((int)(Keys.Shift | Keys.H)).ToString());
            Properties.Settings.Default.Shortcut.Add(Key.PasteFromClipboard, ((int)(Keys.Shift | Keys.V)).ToString());

            Properties.Settings.Default.Shortcut.Add(Key.Duplicate, ((int)(Keys.Control | Keys.D)).ToString());
            Properties.Settings.Default.Save();
        }
    }
}
