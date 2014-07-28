using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public class GraphicalPanel : Panel
    {
        public Stroke Stroke { get; set; }

        public GraphicalPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.UserPaint | 
                ControlStyles.OptimizedDoubleBuffer | 
                ControlStyles.ResizeRedraw, true);

            Stroke = new Stroke();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Stroke.Color), Stroke.Thickness),
                new Rectangle(Location, Size));

            base.OnPaint(e);
        }
    }

    [TypeConverterAttribute(typeof(StrokeConverter)),
    DescriptionAttribute("Expand to see the spelling options for the application.")]
    public class Stroke
    {
        public float Thickness { get; set; }
        public Color Color { get; set; }

        public Stroke()
        {
            Thickness = 0;
            Color = Color.Transparent;
        }

        public Stroke(Int32 thickness, Color color)
        {
            Thickness = thickness;
            Color = color;
        }
    }

    public class StrokeConverter : TypeConverter
    {
        // Overrides the CanConvertFrom method of TypeConverter.
        // The ITypeDescriptorContext interface provides the context for the
        // conversion. Typically, this interface is used at design time to 
        // provide information about the design-time container.
        public override bool CanConvertFrom(ITypeDescriptorContext context,
           Type sourceType)
        {

            if (sourceType == typeof(Stroke))
                return true;
            
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(Stroke))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override bool IsValid(ITypeDescriptorContext context, object value)
        {
            
                return true;

            return base.IsValid(context, value);
        }



        // Overrides the ConvertFrom method of TypeConverter.
        public override object ConvertFrom(ITypeDescriptorContext context,
           CultureInfo culture, object value)
        {
            if (value is string)
            {
                try
                {
                    var s = (string)value;
                    int semicolon = s.IndexOf(';');

                    if (semicolon != -1)
                    {
                        string checkWhileTyping = s.Substring(0,
                                                        (semicolon - 1));

                        string checkCaps = s.Substring(semicolon + 1,
                                                        (s.Length - semicolon - 1));

                        var so = new Stroke();

                        ColorConverter cc = new ColorConverter();
                        var cl = (Color)cc.ConvertFrom(checkWhileTyping);

                        so.Color = cl;
                        so.Thickness = float.Parse(checkCaps);

                        return so;
                    }
                }
                catch
                {
                    throw new ArgumentException(
                        "Can not convert '" + (string)value +
                                           "' to type SpellingOptions");
                }
            }
            return base.ConvertFrom(context, culture, value);
        }

        // Overrides the ConvertTo method of TypeConverter.
        public override object ConvertTo(ITypeDescriptorContext context,
           CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(String) && value is Stroke)
            {
                return ((Stroke)value).Color.Name + ";" + ((Stroke)value).Thickness;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
