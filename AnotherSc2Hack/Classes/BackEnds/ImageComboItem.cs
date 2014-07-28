using System.Drawing;

namespace AnotherSc2Hack.Classes.BackEnds
{

	public class ImageComboItem : object
	{
		// forecolor: transparent = inherit

	    // constructors
		public ImageComboItem()
		{
		    ForeColor = Color.FromKnownColor(KnownColor.Transparent);
		    ImageIndex = -1;
		    Text = null;
		    Tag = null;
		    Mark = false;
		}

	    public ImageComboItem(string text)
	    {
	        ForeColor = Color.FromKnownColor(KnownColor.Transparent);
	        ImageIndex = -1;
	        Tag = null;
	        Mark = false;
	        Text = text;
	    }

	    public ImageComboItem(string text, int imageIndex)
		{
	        ForeColor = Color.FromKnownColor(KnownColor.Transparent);
	        Tag = null;
	        Mark = false;
	        Text = text;
			ImageIndex = imageIndex;
		}

		public ImageComboItem(string text, int imageIndex, bool mark)
		{
		    ForeColor = Color.FromKnownColor(KnownColor.Transparent);
		    Tag = null;
		    Text = text;
			ImageIndex = imageIndex;
			Mark = mark;
		}

		public ImageComboItem(string text, int imageIndex, bool mark, Color foreColor)
		{
		    Tag = null;
		    Text = text;
			ImageIndex = imageIndex;
			Mark = mark;
			ForeColor = foreColor;
		}

		public ImageComboItem(string text, int imageIndex, bool mark, Color foreColor, object tag)
		{
			Text = text;
			ImageIndex = imageIndex;
			Mark = mark;
			ForeColor = foreColor;
			Tag = tag;
		}

		// forecolor
	    public Color ForeColor { get; set; }

	    // image index
	    public int ImageIndex { get; set; }

	    // mark (bold)
	    public bool Mark { get; set; }

	    // tag
	    public object Tag { get; set; }

	    // item text
	    public string Text { get; set; }

	    // ToString() should return item text
		public override string ToString() 
		{
			return Text;
		}

	}

}
