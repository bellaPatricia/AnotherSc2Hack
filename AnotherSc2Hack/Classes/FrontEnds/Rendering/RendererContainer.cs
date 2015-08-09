using System.Collections.Generic;
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

        public void SetDrawingInterval(int interval)
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

        public void CloseNicely()
        {
            foreach (var renderer in this)
            {
                renderer.IsAllowedToClose = true;
                renderer.Close();
            }
        }
    }
}