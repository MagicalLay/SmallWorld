using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Jeu;

namespace Graphics
{
    public static class Util
    {
        private static string[] ImageResourceNameFromFaction;
        private static ResourceManager rm = new System.Resources.ResourceManager("WpfSmallWorld.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());

        static Util()
        {
            ImageResourceNameFromFaction = new string[Enum.GetNames(typeof(Unit.Type)).Length];
            ImageResourceNameFromFaction[(int)Unit.Type.Orc] = "Orc";
            ImageResourceNameFromFaction[(int)Unit.Type.Dwarf] = "Dwarf";
            ImageResourceNameFromFaction[(int)Unit.Type.Elf] = "Elf";
        }

        private static string getImageResourceNameFromFaction(Unit.Type f)
        {
            return ImageResourceNameFromFaction[(int)f];
        }

        public static BitmapSource getImageResourceFromFaction(Unit.Type f)
        {
            Bitmap imageP1 = (Bitmap)rm.GetObject(getImageResourceNameFromFaction(f));
            Int32Rect rectP1 = new Int32Rect(0, 0, imageP1.Width, imageP1.Height);
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(imageP1.GetHbitmap(), IntPtr.Zero, rectP1, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
