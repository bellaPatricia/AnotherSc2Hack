using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    public class RendererContainer : List<BaseRenderer>
    {
        public void ToggleShowHide()
        {
            foreach (var renderer in this)
                renderer.ToggleShowHide();
        }

        public void SetDrawingInterval(Int32 interval)
        {
            foreach (var renderer in this)
                renderer.tmrRefreshGraphic.Interval = interval;
        }

        public void Show()
        {
            foreach (var renderer in this)
                renderer.Show();
        }

        public void Hide()
        {
            foreach (var renderer in this)
                renderer.Hide();
        }

        public void Visible()
        {
            foreach (var renderer in this)
                renderer.Visible = true;
        }

        public void Invisible()
        {
            foreach (var renderer in this)
                renderer.Visible = false;
        }

        public void ReleadPreferencesIntoControls()
        {
            foreach (var renderer in this)
                renderer.ReloadPreferencesIntoControls();
        }

        public void SetFormBorderStyle(FormBorderStyle fbs)
        {
            foreach (var renderer in this)
                renderer.FormBorderStyle = fbs;
        }

        public void CloseClean()
        {
            foreach (var renderer in this)
            {
                renderer.IsAllowedToClose = true;
                renderer.Close();
            }
        }
    }
}
