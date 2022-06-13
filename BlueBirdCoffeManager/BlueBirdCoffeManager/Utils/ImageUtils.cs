using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.Utils
{
    public class ImageUtils
    {
        public static Image ByteArrayToImage(byte[] input)
        {
            using (var ms = new MemoryStream(input))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
