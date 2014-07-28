using System.Drawing;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    class ImageCombobox : ComboBox
    {
        private ImageList _imgs = new ImageList();

		// constructor
		public ImageCombobox()
		{
			// set draw mode to owner draw
			DrawMode = DrawMode.OwnerDrawFixed;	
		}

		// ImageList property
		public ImageList ImageList 
		{
			get 
			{
				return _imgs;
			}
			set 
			{
				_imgs = value;
			}
		}

		// customized drawing process
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			// draw background & focus rect
			e.DrawBackground();
			e.DrawFocusRectangle();

			// check if it is an item from the Items collection
			if (e.Index < 0)

				// not an item, draw the text (indented)
				e.Graphics.DrawString(Text, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + _imgs.ImageSize.Width, e.Bounds.Top);

			else
			{
				
				// check if item is an ImageComboItem
				if (Items[e.Index].GetType() == typeof(ImageComboItem)) 
				{															

					// get item to draw
					var item = (ImageComboItem) Items[e.Index];

					// get forecolor & font
					Color forecolor = (item.ForeColor != Color.FromKnownColor(KnownColor.Transparent)) ? item.ForeColor : e.ForeColor;
					Font font = item.Mark ? new Font(e.Font, FontStyle.Bold) : e.Font;

					// -1: no image
					if (item.ImageIndex != -1) 
					{
						// draw image, then draw text next to it
						ImageList.Draw(e.Graphics, e.Bounds.Left, e.Bounds.Top, item.ImageIndex);
						e.Graphics.DrawString(item.Text, font, new SolidBrush(forecolor), e.Bounds.Left + _imgs.ImageSize.Width, e.Bounds.Top);
					}
					else
						// draw text (indented)
						e.Graphics.DrawString(item.Text, font, new SolidBrush(forecolor), e.Bounds.Left + _imgs.ImageSize.Width, e.Bounds.Top);

				}
				else
				
					// it is not an ImageComboItem, draw it
					e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + _imgs.ImageSize.Width, e.Bounds.Top);
				
			}

			base.OnDrawItem (e);
		}
		
	
    }
}
