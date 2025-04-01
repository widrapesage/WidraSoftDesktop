using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidraSoft.UI
{
    public class MyMenuColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.MediumSeaGreen; }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.DimGray; }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.Black; }
        }
        public override Color MenuBorder
        {
            get { return Color.WhiteSmoke; }
        }
        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.Black; }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.Silver; }
        }
        public override Color MenuItemBorder
        {
            get { return Color.MediumSeaGreen; }
        }
    }
}
