using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using adWin = Autodesk.Windows;
using System.Windows;

namespace KPSP_Stamp
{
    public class Main : IExternalApplication
    {
        public static string TabName { get; set; } = "Надстройки";
        public static string PanelStampName { get; set; } = "Штамп";

        public Result OnStartup(UIControlledApplication application)
        {
            var stampPanel = application.CreateRibbonPanel(PanelStampName);
            string path = Assembly.GetExecutingAssembly().Location;

            var StampBtnData = new PushButtonData("StampBtnData", "Заполнить\nштамп", path, "KPSP_Stamp.FillStampCommand")
            {
                ToolTipImage = new BitmapImage(new Uri(Path.GetDirectoryName(path) + "\\res\\stamp-32.png", UriKind.Absolute)),
                ToolTip = "Заполняет штамп"
            };
            var StampBtn = stampPanel.AddItem(StampBtnData) as PushButton;
            StampBtn.LargeImage = new BitmapImage(new Uri(Path.GetDirectoryName(path) + "\\res\\stamp-32.png", UriKind.Absolute));

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
