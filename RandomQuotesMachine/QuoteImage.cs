using System.Drawing;

namespace RandomQuotesMachine
{
    public class QuoteImage
    {
        public static Image DrawQuote(string text, string fontName, int fontSize)
        {

            Font drawFont = new Font("Arial", 16);

            SizeF textSize = TextSizeCalculator(text, drawFont);

            var img = new Bitmap((int)textSize.Width, (int)textSize.Height);

            var drawing = Graphics.FromImage(img);



            return img;
        }

        private static SizeF TextSizeCalculator(string text, Font fontToMeasure)
        {
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            SizeF textSize = drawing.MeasureString(text, fontToMeasure);

            img.Dispose();
            drawing.Dispose();

            return textSize;
        }

        
    }
}