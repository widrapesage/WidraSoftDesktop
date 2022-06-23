using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidraSoft.UI
{
    public class MyBackgroundColors
    {
        public int Width;
        public int Height;

        public  MyBackgroundColors(int width, int height)           
        {
           Width = width;
           Height = height;    
        }
        public void set_Background(Object sender, PaintEventArgs e)
        {

            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.Black, Color.MediumSeaGreen, 125f);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }

        public void set_Menu_Background(Object sender, PaintEventArgs e)
        {

            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.MediumSeaGreen, Color.MintCream, 280f);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }

        public void set_Button_Background(Object sender, PaintEventArgs e)
        {

            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.MediumSeaGreen, Color.MintCream, 280f);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }
    }
}
