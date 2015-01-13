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
            Image = null;
		}

	    public ImageComboItem(string text)
	    {
	        ForeColor = Color.FromKnownColor(KnownColor.Transparent);
	        ImageIndex = -1;
	        Tag = null;
	        Mark = false;
	        Text = text;
            Image = null;
	    }

	    public ImageComboItem(string text, Image image)
	    {
	        Text = text;
	        Image = image;
	        ImageIndex = -1;
	        Tag = null;
	        Mark = false;
	        ForeColor = Color.FromKnownColor(KnownColor.Transparent);
	    }

	    public ImageComboItem(string text, int imageIndex)
		{
	        ForeColor = Color.FromKnownColor(KnownColor.Transparent);
	        Tag = null;
	        Mark = false;
	        Text = text;
			ImageIndex = imageIndex;
            Image = null;
		}

		public ImageComboItem(string text, int imageIndex, bool mark)
		{
		    ForeColor = Color.FromKnownColor(KnownColor.Transparent);
		    Tag = null;
		    Text = text;
			ImageIndex = imageIndex;
			Mark = mark;
            Image = null;
		}

		public ImageComboItem(string text, int imageIndex, bool mark, Color foreColor)
		{
		    Tag = null;
		    Text = text;
			ImageIndex = imageIndex;
			Mark = mark;
			ForeColor = foreColor;
            Image = null;
		}

		public ImageComboItem(string text, int imageIndex, bool mark, Color foreColor, object tag)
		{
			Text = text;
			ImageIndex = imageIndex;
			Mark = mark;
			ForeColor = foreColor;
			Tag = tag;
            Image = null;
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

	    public Image Image { get; set; }

	    // ToString() should return item text
		public override string ToString() 
		{
			return Text;
		}



	}

}
