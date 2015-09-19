/**
 * This file allows you to preview the images
 * you just downloaded.
 * 
 * This is nothing special.
 * You set the  ImageList into the constructor and that's
 * basicall it.
 * 
 * Author: bellaPatricia
 * Date: 04 - February - 2015
 * */


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    public partial class BigPreviewPicture : Form
    {
        #region Getter / Setter

        private int _iPluginsImageIndex;
        private int IPluginsImageIndex
        {
            get { return _iPluginsImageIndex; }
            set
            {
                _iPluginsImageIndex = value;

                if (_images.Count > 0)
                {
                    pcbBigPicture.Image = _images[_iPluginsImageIndex];
                    lblImageposition.Text = (_iPluginsImageIndex + 1) + "/" + _images.Count;

                    btnPrevious.Enabled = IPluginsImageIndex > 0;
                    btnNext.Enabled = IPluginsImageIndex < _images.Count - 1;

                    PositionButtons();
                }
            }
        }

        #endregion

        #region Variables

        private readonly List<Image> _images;
        private bool _bMove;
        private Point _ptOrigin;
        private const int UnmaximizeDifference = 50;
        private Size _sOriginSize;
        #endregion

        #region Constructors

        public BigPreviewPicture(Image preview)
        {
            _images = new List<Image>(1) {preview};

            InitializeComponent();

            pcbBigPicture.Image = _images[0];
            btnNext.Visible = false;
            btnPrevious.Visible = false;
        }

        public BigPreviewPicture(List<Image> previews)
        {
            _images = previews;

            InitializeComponent();

            pcbBigPicture.Image = _images[0];
        }

        #endregion

        #region Event Methods

        //Draw basic liners
        private void pnlBottom_Paint(object sender, PaintEventArgs e)
        {
            var send = (Panel)sender;

            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, 0, Width, 0);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, send.Height - 1, Width, send.Height - 1);
        }

        //Reposition
        private void BigPreviewPicture_Resize(object sender, EventArgs e)
        {
            PositionButtons();
        }

        //Click on Next to load the next picture
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_images.Count <= 0)
                return;

            if (_images.Count <= 0)
                return;

            if (IPluginsImageIndex < _images.Count - 1)
                IPluginsImageIndex += 1;
        }

        //Click on Previous to load the previous picture
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (IPluginsImageIndex >= 1)
                IPluginsImageIndex -= 1;
        }

        //OnLoad
        private void BigPreviewPicture_Load(object sender, EventArgs e)
        {
            IPluginsImageIndex = 0;

            PositionButtons();
        }

        //Toggle on Mouse Down
        private void pcbBigPicture_MouseDown(object sender, MouseEventArgs e)
        {
            _sOriginSize = Size;
            _ptOrigin = e.Location;
            _bMove = true;
        }

        //Toggle on Mouse Up
        private void pcbBigPicture_MouseUp(object sender, MouseEventArgs e)
        {
            _ptOrigin = new Point(0, 0);
            _bMove = false;
        }

        //Move the Form if it's required
        private void pcbBigPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_bMove)
                return;

            #region Undo Maximize

            var diffX = _ptOrigin.X - e.X;
            var diffY = _ptOrigin.Y - e.Y;
            if (diffX < 0)
                diffX *= -1;

            if (diffY < 0)
                diffY *= -1;

            if (diffX > UnmaximizeDifference ||
                diffY > UnmaximizeDifference)
            {
                WindowState = FormWindowState.Normal;

                //Reset origin position
                var posX = (float)_ptOrigin.X / _sOriginSize.Width * Width;
                var posY = (float)_ptOrigin.Y / _sOriginSize.Height * Height;
                _ptOrigin = new Point((int)posX, (int) posY);
            }

            

            #endregion

            Location = new Point(Cursor.Position.X - _ptOrigin.X - (Width - ClientSize.Width), Cursor.Position.Y - _ptOrigin.Y - (Height - ClientSize.Height));
            OnMove(new EventArgs());
        }

        //Maximize your form
        private void pcbBigPicture_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;

            else if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
        }

        #endregion

        #region Own Methods

        //Reposition buttons - you can't anchor here
        private void PositionButtons()
        {
            const int iButtonSpacer = 30;

            //Middle button
            lblImageposition.Location = new Point((ClientSize.Width / 2) - (lblImageposition.Width / 2), lblImageposition.Location.Y);

            //Left button
            btnPrevious.Location = new Point((ClientSize.Width / 2) - (lblImageposition.Width / 2) - iButtonSpacer - btnPrevious.Width, lblImageposition.Location.Y);

            //Right button
            btnNext.Location = new Point((ClientSize.Width / 2) + (lblImageposition.Width / 2) + iButtonSpacer, lblImageposition.Location.Y);
        }

        #endregion
    }
}
