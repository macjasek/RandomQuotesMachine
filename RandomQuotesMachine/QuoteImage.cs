using System.Drawing;

namespace RandomQuotesMachine
{
    public class QuoteImage
    {
        public static Image DrawQuote(string text, string author, string fontName, int fontSize)
        {

            fontSize = CalculateMaxTextSize(text, fontName);

            Font drawFont = new Font(fontName, fontSize);

            text = text.ToUpper();

            SizeF textSize = TextSizeCalculator(text, drawFont);

            //Recommended image size: 1200 × 628 pixels

            var img = new Bitmap(1200, 628);

            var drawing = Graphics.FromImage(img);

            Color backColor = new Color();
            backColor = Color.FromArgb(0, 205, 207);
             

            drawing.Clear(backColor);

            Color textColor = Color.White;

            Brush textBrush = new SolidBrush(textColor);

            int xCoordinateOfText = (int)(1200 - textSize.Width)/2;
            int yCoordinateOfText = (int)(((628 - textSize.Height) / 2) - textSize.Height);

            drawing.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            drawing.DrawString(text, drawFont, textBrush, xCoordinateOfText, yCoordinateOfText);

            drawing.DrawString(author, drawFont, textBrush, xCoordinateOfText, 528);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            img.Save("D:\\test.png",System.Drawing.Imaging.ImageFormat.Png);

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

        private static int CalculateMaxTextSize(string text, string fontName)
        {
            int maxTextSize = 1;

            Font fontToMeasure = new Font(fontName, maxTextSize);

            int textWidth = 0;

            while (textWidth < 1000)
            {
                SizeF textSize = TextSizeCalculator(text.ToUpper(), fontToMeasure);
                textWidth = (int)textSize.Width;
                maxTextSize++;
                fontToMeasure = new Font(fontName, maxTextSize);
            }


            return maxTextSize;
        }

        
    }
}