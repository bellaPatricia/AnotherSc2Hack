using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using PluginInterface;
using PredefinedTypes = Predefined.PredefinedData;

namespace TestPlugin
{
    public class AnotherSc2HackPlugin : IPlugins
    {

        private Renderer _rRenderer = new Renderer();

        
        

        public string GetPluginDescription()
        {
            return "This is some sample Plugin description...";

            
        }

        public string GetPluginName()
        {
            
            return "Dummy2 Plugin...";

            
        }

        public void SetMap(PredefinedTypes.Map map)
        {
            _rRenderer.Map = map;
        }

        public void SetUnits(List<PredefinedTypes.Unit> units)
        {
            _rRenderer.Units = units;
        }

        public void SetPlayers(PredefinedTypes.PList players)
        {
            _rRenderer.Players = players;
        }

        public void SetSelection(PredefinedTypes.LSelection selection)
        {
            _rRenderer.Selection = selection;
        }

        public void SetGroups(List<PredefinedTypes.Groups> groups)
        {
            _rRenderer.Groups = groups;
        }

        public void SetGameinfo(PredefinedTypes.Gameinformation gameinfo)
        {
            _rRenderer.Gameinfo = gameinfo;
        }


        public void StartPlugin()
        {
            if (_rRenderer == null)
                _rRenderer = new Renderer();

            if (_rRenderer.Created)
                _rRenderer.Close();

            else
            {
                if (_rRenderer.IsDisposed)
                    _rRenderer = new Renderer();

                _rRenderer.Show();
            }
        }

        public void StopPlugin()
        {
            _rRenderer.Close();
        }
    }

    public class Renderer : Form
    {
        public Boolean IsDestoyed { get; set; }

        public PredefinedTypes.Map Map { get; set; }
        public PredefinedTypes.Gameinformation Gameinfo { get; set; }
        public PredefinedTypes.PList Players { get; set; }
        public List<PredefinedTypes.Unit> Units { get; set; }

        public PredefinedTypes.LSelection Selection { get; set; }

        public List<PredefinedTypes.Groups> Groups { get; set; }

        private readonly Timer _tmrMainTick = new Timer();

        public Renderer()
        {
            SetStyle(ControlStyles.DoubleBuffer |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint, true);

            _tmrMainTick.Tick += _tmrMainTick_Tick;
            _tmrMainTick.Enabled = true;
            _tmrMainTick.Interval = 16;
        }

        void _tmrMainTick_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnClosed(EventArgs e)
        {
            IsDestoyed = true;

            base.OnClosed(e);
        }

        protected override void OnPaint(PaintEventArgs g)
        {
            base.OnPaint(g);


            try
            {
                if (Players == null ||
                    Units == null ||
                    !Gameinfo.IsIngame)
                    return;


                var tmpMap = Map;
                
                #region Introduction

                #region Variables

                float fScale,
                      fX,
                      fY;

                #endregion

                #region Get minimap Bounds

                var fa = Height / (float)Width;
                var fb = ((float)tmpMap.PlayableHeight / tmpMap.PlayableWidth);

                if (fa >= fb)
                {
                    fScale = (float)Width / tmpMap.PlayableWidth;
                    fX = 0;
                    fY = (Height - fScale * tmpMap.PlayableHeight) / 2;
                }
                else
                {
                    fScale = (float)Height / tmpMap.PlayableHeight;
                    fY = 0;
                    fX = (Width - fScale * tmpMap.PlayableWidth) / 2;
                }



                #endregion

                #region Draw Bounds

                
                    /* Draw Rectangle */
                    g.Graphics.DrawRectangle(new Pen(Brushes.Black), 0, 0, Width - 1,
                                             Height - 1);

                    /* Draw Playable Area */
                    g.Graphics.DrawRectangle(new Pen(Brushes.Yellow), fX, fY, Width - fX * 2 - 1,
                                             Height - fY * 2 - 1);
                

                #endregion

                #endregion

                #region Actual Drawing

                #region Draw Unit- destination

               
                    for (var i = 0; i < Units.Count; i++)
                    {
                        var clDestination = Color.Yellow;

                        var tmpUnit = Units[i];




                        #region Escape Sequences


                       

                        /* Dead Units */
                        if ((tmpUnit.TargetFilter & (ulong)PredefinedTypes.TargetFilterFlag.Dead) > 0)
                            continue;


                        /* Moving- state */
                        if (tmpUnit.Movestate.Equals(0))
                            continue;




                        #endregion

                        #region Scalling (Unitposition + UnitDestination)

                        var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
                        var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;

                        var iUnitDestPosX = (tmpUnit.DestinationPositionX - tmpMap.Left) * fScale +
                                            fX;
                        var iUnitDestPosY = (tmpMap.Top - tmpUnit.DestinationPositionY) * fScale +
                                            fY;

                        if (float.IsNaN(iUnitPosX) ||
                            float.IsNaN(iUnitPosY) ||
                            float.IsNaN(iUnitDestPosX) ||
                            float.IsNaN(iUnitDestPosY))
                        {
                            continue;
                        }


                        #endregion
                        
                        g.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                        g.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                        /* Draws the Line */
                        if (tmpUnit.DestinationPositionX > 10 &&
                            tmpUnit.DestinationPositionY > 10)
                            g.Graphics.DrawLine(new Pen(new SolidBrush(clDestination)), iUnitPosX, iUnitPosY,
                                                iUnitDestPosX,
                                                iUnitDestPosY);

                        g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
                        g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                        g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;

                    
                }

                #endregion

                #region Draw Creeptumors

                for (var i = 0; i < Units.Count; i++)
                {
                    var tmpUnit = Units[i];

                    #region Exceptions

                   

                    /* Dead Units */
                    if ((tmpUnit.TargetFilter & (ulong)PredefinedTypes.TargetFilterFlag.Dead) > 0)
                        continue;

                    #endregion

                    #region Actual Drawing


                    if (tmpUnit.Id == PredefinedTypes.UnitId.ZbCreeptumor ||
                        tmpUnit.Id == PredefinedTypes.UnitId.ZbCreepTumorBuilding ||
                        tmpUnit.Id == PredefinedTypes.UnitId.ZbCreepTumorMissle ||
                        tmpUnit.Id == PredefinedTypes.UnitId.ZbCreeptumorBurrowed)
                    {

                        #region Scalling (Unitposition)

                        var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
                        var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;

                        if (float.IsNaN(iUnitPosX) ||
                            float.IsNaN(iUnitPosY))
                        {
                            continue;
                        }


                        #endregion


                        const Int32 iRadius = 4;





                        g.Graphics.DrawLine(new Pen(Brushes.Black, 2), iUnitPosX - iRadius, iUnitPosY - iRadius, iUnitPosX + iRadius, iUnitPosY + iRadius);
                        g.Graphics.DrawLine(new Pen(Brushes.Black, 2), iUnitPosX + iRadius, iUnitPosY - iRadius, iUnitPosX - iRadius, iUnitPosY + iRadius);


                    }


                    #endregion

                }

                #endregion

                #region Draw Unit (Border/ outer Rectangle)

                for (var i = 0; i < Units.Count; i++)
                {
                    var tmpUnit = Units[i];
                    var clUnitBound = Color.Black;

                    if (tmpUnit.Owner >= (Players.Count))
                        continue;


                    #region Escape Sequences

                   

                    /* Dead Units */
                    if ((tmpUnit.TargetFilter & (ulong)PredefinedTypes.TargetFilterFlag.Dead) > 0)
                        continue;

                    /* Creep tumor */
                    if (tmpUnit.Id ==
                        PredefinedTypes.UnitId.ZbCreeptumorBurrowed)
                        continue;




                    #endregion

                    #region Scalling (Unitposition)

                    var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
                    var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;

                    if (float.IsNaN(iUnitPosX) ||
                        float.IsNaN(iUnitPosY))
                    {
                        continue;
                    }


                    #endregion



                    var fUnitSize = tmpUnit.Size;
                    var size = 2.0f;

                    if (fUnitSize >= 0.5)
                        size = 3;

                    if (fUnitSize >= 0.875)
                        size = 4;

                    if (fUnitSize >= 1.5)
                        size = 6;

                    if (fUnitSize >= 2.0)
                        size = 8;

                    if (fUnitSize >= 2.5)
                        size = 10;

                    size += 0.5f;


                    #region Actual drawing

                    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

                    if (tmpUnit.IsCloaked &&
                        tmpUnit.Id != PredefinedTypes.UnitId.ZbCreeptumorBurrowed)
                    {
                        g.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Gray)), iUnitPosX - size / 2,
                                                 iUnitPosY - size / 2, size, size);

                        g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBound)), iUnitPosX - size / 2 - 0.5f,
                                                 iUnitPosY - size / 2 - 0.5f, size + 1, size + 1);
                    }

                    else
                    {
                        g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBound)), iUnitPosX - size / 2,
                                                 iUnitPosY - size / 2, size, size);
                    }

                    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

                    #endregion
                }

                #endregion

                #region Draw Unit (Inner Rectangle)

                for (var i = 0; i < Units.Count; i++)
                {
                    var tmpUnit = Units[i];
                    //Color clUnit = LUnit[i].Owner > LPlayer.Count ? Color.Transparent : LPlayer[LUnit[i].Owner].Color;

                    if (tmpUnit.Owner >= Players.Count)
                        continue;


                    var clUnit = Players[tmpUnit.Owner].Color;


                    #region Scalling (Unitposition)

                    var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
                    var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;


                    if (float.IsNaN(iUnitPosX) ||
                        float.IsNaN(iUnitPosY))
                    {
                        continue;
                    }

                    #endregion

                    #region Escape Sequences

                   

                    /* Dead Units */
                    if ((tmpUnit.TargetFilter & (ulong)PredefinedTypes.TargetFilterFlag.Dead) > 0)
                        continue;

                    /* Creep tumor */
                    if (tmpUnit.Id ==
                         PredefinedTypes.UnitId.ZbCreeptumorBurrowed)
                        continue;




                    #endregion

                    var fUnitSize = tmpUnit.Size;
                    var size = 2.0f;

                    if (fUnitSize >= 0.5f)
                        size = 3;

                    if (fUnitSize >= 0.875)
                        size = 4;

                    if (fUnitSize >= 1.5)
                        size = 6;

                    if (fUnitSize >= 2.0)
                        size = 8;

                    if (fUnitSize >= 2.5)
                        size = 10;

                    size -= 0.5f;


                    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

                    /* Draw the Unit (Actual Unit) */
                    g.Graphics.FillRectangle(new SolidBrush(clUnit), iUnitPosX - size / 2, iUnitPosY - size / 2, size, size);

                    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

                }

                #endregion

                #region Draw Border of special Units

                for (var i = 0; i < Units.Count; i++)
                {
                    var tmpUnit = Units[i];
                    var clUnitBoundBorder = Color.Black;

                    if (tmpUnit.Owner >= (Players.Count))
                        continue;


                    #region Scalling (Unitposition)

                    var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
                    var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;


                    if (float.IsNaN(iUnitPosX) ||
                        float.IsNaN(iUnitPosY))
                    {
                        continue;
                    }

                    #endregion

                    #region Escape Sequences

                    


                    /* Dead Units */
                    if ((tmpUnit.TargetFilter & (ulong)PredefinedTypes.TargetFilterFlag.Dead) > 0)
                        continue;






                    #endregion


                    var fUnitSize = tmpUnit.Size;
                    var size = 2.0f;

                    if (fUnitSize >= 0.875)
                        size = 4;

                    if (fUnitSize >= 1.5)
                        size = 6;

                    if (fUnitSize >= 2.0)
                        size = 8;

                    if (fUnitSize >= 2.5)
                        size = 10;

                    size += 0.5f;


                    #region Border special Units

                    

                    #region CreepTumors

                    //if (_hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int) PredefinedTypes.UnitId.ZbCreeptumor)
                    //{
                    //    g.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Gray), 1.5f),
                    //                             (iUnitPosX - size/2), (iUnitPosY - size/2), size, size);

                    //    g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBoundBorder)),
                    //                             iUnitPosX - ((size/2) + 0.75f),
                    //                             iUnitPosY - ((size/2) + 0.75f), size + 1.75f, size + 1.75f);
                    //}


                    //if (_hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int)PredefinedTypes.UnitId.ZbCreeptumor ||
                    //    _hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int)PredefinedTypes.UnitId.ZbCreepTumorBuilding ||
                    //    _hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int)PredefinedTypes.UnitId.ZbCreepTumorMissle ||
                    //    _hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int)PredefinedTypes.UnitId.ZbCreeptumorBurrowed)
                    //{
                    //    const Int32 iRadius = 4;

                    //    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    //    g.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                    //    g.Graphics.DrawLine(Constants.PBlack1, iUnitPosX - iRadius, iUnitPosY - iRadius, iUnitPosX + iRadius, iUnitPosY + iRadius);
                    //    g.Graphics.DrawLine(Constants.PBlack1, iUnitPosX + iRadius, iUnitPosY - iRadius, iUnitPosX - iRadius, iUnitPosY + iRadius);

                    //    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    //    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                    //}

                    #endregion

                   

                    #endregion

                }

                #endregion

                #region Draw Player camera

                
                    for (var i = 0; i < Players.Count; i++)
                    {
                        var clPlayercolor = Players[i].Color;

                        

                        #region Escape Sequences

                       

                        /* Hosile */
                        if (Players[i].Type.Equals(PredefinedTypes.PlayerType.Hostile))
                            continue;

                        if (float.IsInfinity(fScale))
                            continue;

                   

                        #endregion

                        #region Drawing

                        //The actrual position of the Cameras
                        var fPlayerX = (Players[i].CameraPositionX - tmpMap.Left) * fScale + fX;
                        var fPlayerY = (tmpMap.Top - Players[i].CameraPositionY) * fScale + fY;


                        if (fPlayerX <= 0 || fPlayerX >= Width ||
                            fPlayerY <= 0 || fPlayerY >= Height)
                            continue;


                        var ptPoints = new PointF[4];
                        ptPoints[0] = new PointF(fPlayerX - 35f, fPlayerY - 24f);
                        ptPoints[1] = new PointF(fPlayerX + 35f, fPlayerY - 24f);
                        ptPoints[2] = new PointF(fPlayerX + 24f, fPlayerY + 10f);
                        ptPoints[3] = new PointF(fPlayerX - 24f, fPlayerY + 10f);




                        g.Graphics.DrawPolygon(new Pen(new SolidBrush(clPlayercolor), 2), ptPoints);

                        #endregion

                    
                }

                #endregion

                #endregion

            }

            catch (Exception ex)
            {
                
            }
        }
    }
}
