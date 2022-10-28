
using Spire.Barcode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2.Application
{
    public class BarCodeService : IBarCodeService
    {
        public BarcodeSettings BarCode { get; set; }
        public BarCodeGenerator BarCodeGenerator { get; set; }

        public string GenerateBarCode(string toEncode)
        {
            BarCode = new();
            BarCode.Type = BarCodeType.Code39Extended;
            BarCode.Data = toEncode;
            BarCodeGenerator = new BarCodeGenerator(BarCode);
            var path = $"{toEncode}.PNG";
            BarCodeGenerator.GenerateImage().Save(path);

            var barCodeToString = getBase64(path);
            File.Delete(path);
            return barCodeToString;

        }

        private string getBase64(string path)
        {
            var base64String = string.Empty;
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                }
            }
            return base64String;

        }



    }
}
