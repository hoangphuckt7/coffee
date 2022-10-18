using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.Utils
{
    public class OrderDataPanel : Panel
    {
        private readonly Panel _panel;

        public OrderDataPanel(Panel panel)
        {
            _panel = panel;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, _panel.ClientRectangle,
            Color.DimGray, 0, ButtonBorderStyle.Solid, // left
            Color.DimGray, 3, ButtonBorderStyle.Solid, // top
            Color.DimGray, 0, ButtonBorderStyle.Solid, // right
            Color.DimGray, 0, ButtonBorderStyle.Solid);// bottom
        }
    }
}
