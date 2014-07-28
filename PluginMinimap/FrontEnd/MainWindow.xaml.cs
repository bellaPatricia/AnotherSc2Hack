using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using PluginInterface;
using PredefinedTypes =Predefined.PredefinedData;

namespace PluginMinimap.FrontEnd
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PredefinedTypes.Map Map { get; set; }
        public PredefinedTypes.Gameinformation Gameinfo { get; set; }
        public PredefinedTypes.PList Players { get; set; }
        public List<PredefinedTypes.Unit> Units { get; set; }
        public PredefinedTypes.LSelection Selection { get; set; }
        public List<PredefinedTypes.Groups> Groups { get; set; }

        private DispatcherTimer _tmrMainTimer = new DispatcherTimer();

        private List<Rectangle> _lRecs = new List<Rectangle>(); 
        private List<Polygon> _lPolygons = new List<Polygon>(); 

        public MainWindow()
        {
            InitializeComponent();
            SetupLocalControls();
        }

        private void SetupLocalControls()
        {
            #region Rectangles

            for (var i = 0; i < 1000; i++)
            {
                var rec = new Rectangle();
                rec.Width = 50;
                rec.Height = 25;
                rec.Fill = Brushes.Aqua;
                _lRecs.Add(rec);
                CnvMainCanvas.Children.Add(_lRecs[i]);
                Canvas.SetLeft(_lRecs[i], 0);
                Canvas.SetTop(_lRecs[i], 0);
            }

            #endregion

            #region Polygons

            for (var i = 0; i < 16; i++)
            {
                _lPolygons.Add(new Polygon());
                CnvMainCanvas.Children.Add(_lPolygons[i]);
            }

            #endregion

            #region Dispatchertimer

            _tmrMainTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            _tmrMainTimer.IsEnabled = true;
            _tmrMainTimer.Tick += _tmrMainTimer_Tick;

            #endregion
        }

        private Int32 _iX = 0;
        private Int32 _iY = 0;
        Random rnd = new Random();
        void _tmrMainTimer_Tick(object sender, EventArgs e)
        {
            DrawMap();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            
        }

        private void DrawMap()
        {

            var _iPositionOfChild = 0;

            //Opacity = _pSettings.MaphackOpacity;

            //if (!_bChangingPosition)
            //{
            //    Height = _pSettings.MaphackHeight;
            //    Width = _pSettings.MaphackWidth;
            //}

            var tmpMap = Map;

            #region Introduction

            #region Variables

            float fScale,
                fX,
                fY;

            #endregion

            #region Get minimap Bounds

            var fa = Height/(float) Width;
            var fb = ((float) tmpMap.PlayableHeight/tmpMap.PlayableWidth);

            if (fa >= fb)
            {
                fScale = (float) Width/tmpMap.PlayableWidth;
                fX = 0;
                fY = ((float) Height - fScale*tmpMap.PlayableHeight)/2;
            }
            else
            {
                fScale = (float) Height/tmpMap.PlayableHeight;
                fY = 0;
                fX = ((float) Width - fScale*tmpMap.PlayableWidth)/2;
            }



            #endregion

            #region Draw Bounds

            if (_lRecs == null ||
                _lRecs.Count <= 0)
                return;

            /* Set the outer rectangle */
            Canvas.SetLeft(_lRecs[0], 0);
            Canvas.SetTop(_lRecs[0], 0);

            _lRecs[0].Stroke = Brushes.Red;
            _lRecs[0].Fill = Brushes.Transparent;

            _lRecs[0].Width = CnvMainCanvas.ActualWidth;
            _lRecs[0].Height = CnvMainCanvas.ActualHeight;


            /* Set the inner, actual rectangle */
            Canvas.SetLeft(_lRecs[1], fX);
            Canvas.SetTop(_lRecs[1], fY);

            _lRecs[1].Stroke = Brushes.Green;
            _lRecs[1].Fill = Brushes.Transparent;

            _lRecs[1].Width = CnvMainCanvas.ActualWidth - fX*2;
            _lRecs[1].Height = CnvMainCanvas.ActualHeight - fY*2;

            #endregion

            #endregion

            if (Players == null)
                return;

            //#region Actual Drawing

            //#region Draw Unit- destination

            //if (!_pSettings.MaphackDisableDestinationLine)
            //{
            //    for (var i = 0; i < _hMainHandler.GInformation.Unit.Count; i++)
            //    {
            //        var clDestination = _pSettings.MaphackDestinationColor;

            //        var tmpUnit = _hMainHandler.GInformation.Unit[i];




            //        #region Escape Sequences


            //        /* Ai */
            //        if (_pSettings.MaphackRemoveAi)
            //        {
            //            if (
            //                _hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(
            //                    PredefinedTypes.PlayerType.Ai))
            //                continue;
            //        }

            //        /* Allie */
            //        if (_pSettings.MaphackRemoveAllie)
            //        {
            //            if (_hMainHandler.GInformation.Player[0].Localplayer < _hMainHandler.GInformation.Player.Count)
            //            {
            //                if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Team ==
            //                    _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Team &&
            //                    !_hMainHandler.GInformation.Player[tmpUnit.Owner].IsLocalplayer)
            //                    continue;
            //            }
            //        }

            //        /* Localplayer Units */
            //        if (_pSettings.MaphackRemoveLocalplayer)
            //        {
            //            if (tmpUnit.Owner == _hMainHandler.GInformation.Player[0].Localplayer)
            //                continue;
            //        }

            //        /* Neutral Units */
            //        if (_pSettings.MaphackRemoveNeutral)
            //        {
            //            if (
            //                _hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(
            //                    PredefinedTypes.PlayerType.Neutral))
            //                continue;
            //        }

            //        /* Dead Units */
            //        if ((tmpUnit.TargetFilter & (ulong)PredefinedTypes.TargetFilterFlag.Dead) > 0)
            //            continue;


            //        /* Moving- state */
            //        if (tmpUnit.Movestate.Equals(0))
            //            continue;




            //        #endregion

            //        #region Scalling (Unitposition + UnitDestination)

            //        var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
            //        var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;

            //        var iUnitDestPosX = (tmpUnit.DestinationPositionX - tmpMap.Left) * fScale +
            //                            fX;
            //        var iUnitDestPosY = (tmpMap.Top - tmpUnit.DestinationPositionY) * fScale +
            //                            fY;

            //        if (float.IsNaN(iUnitPosX) ||
            //            float.IsNaN(iUnitPosY) ||
            //            float.IsNaN(iUnitDestPosX) ||
            //            float.IsNaN(iUnitDestPosY))
            //        {
            //            continue;
            //        }


            //        #endregion

            //        g.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            //        g.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //        g.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            //        /* Draws the Line */
            //        if (tmpUnit.DestinationPositionX > 10 &&
            //            tmpUnit.DestinationPositionY > 10)
            //            g.Graphics.DrawLine(new Pen(new SolidBrush(clDestination)), iUnitPosX, iUnitPosY,
            //                                iUnitDestPosX,
            //                                iUnitDestPosY);

            //        g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            //        g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            //        g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;

            //    }
            //}

            //#endregion

            //#region Draw Creeptumors

            //for (var i = 0; i < _hMainHandler.GInformation.Unit.Count; i++)
            //{
            //    var tmpUnit = _hMainHandler.GInformation.Unit[i];

            //    #region Exceptions

            //    /* Ai */
            //    if (_pSettings.MaphackRemoveAi)
            //    {
            //        if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedTypes.PlayerType.Ai))
            //            continue; //clUnitBoundBorder = Color.Transparent;

            //    }

            //    /* Allie */
            //    if (_pSettings.MaphackRemoveAllie)
            //    {
            //        if (_hMainHandler.GInformation.Player[0].Localplayer < _hMainHandler.GInformation.Player.Count)
            //        {
            //            if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Team ==
            //                _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Team &&
            //                !_hMainHandler.GInformation.Player[tmpUnit.Owner].IsLocalplayer)
            //                continue; //clUnitBoundBorder = Color.Transparent;

            //        }
            //    }

            //    /* Localplayer Units */
            //    if (_pSettings.MaphackRemoveLocalplayer)
            //    {
            //        if (tmpUnit.Owner == _hMainHandler.GInformation.Player[0].Localplayer)
            //            continue; //clUnitBoundBorder = Color.Transparent;

            //    }

            //    /* Neutral Units */
            //    if (_pSettings.MaphackRemoveNeutral)
            //    {
            //        if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedTypes.PlayerType.Neutral))
            //            continue; //clUnitBoundBorder = Color.Transparent;

            //    }

            //    /* Dead Units */
            //    if ((tmpUnit.TargetFilter & (ulong)PredefinedTypes.TargetFilterFlag.Dead) > 0)
            //        continue;

            //    #endregion

            //    #region Actual Drawing


            //    if (tmpUnit.Id == PredefinedTypes.UnitId.ZbCreeptumor ||
            //        tmpUnit.Id == PredefinedTypes.UnitId.ZbCreepTumorBuilding ||
            //        tmpUnit.Id == PredefinedTypes.UnitId.ZbCreepTumorMissle ||
            //        tmpUnit.Id == PredefinedTypes.UnitId.ZbCreeptumorBurrowed)
            //    {

            //        #region Scalling (Unitposition)

            //        var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
            //        var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;

            //        if (float.IsNaN(iUnitPosX) ||
            //            float.IsNaN(iUnitPosY))
            //        {
            //            continue;
            //        }


            //        #endregion


            //        const Int32 iRadius = 4;





            //        g.Graphics.DrawLine(Constants.PBlack2, iUnitPosX - iRadius, iUnitPosY - iRadius, iUnitPosX + iRadius, iUnitPosY + iRadius);
            //        g.Graphics.DrawLine(Constants.PBlack2, iUnitPosX + iRadius, iUnitPosY - iRadius, iUnitPosX - iRadius, iUnitPosY + iRadius);


            //    }


            //    #endregion

            //}

            //#endregion

            //#region Draw Unit (Border/ outer Rectangle)

            //for (var i = 0; i < _hMainHandler.GInformation.Unit.Count; i++)
            //{
            //    var tmpUnit = _hMainHandler.GInformation.Unit[i];
            //    var clUnitBound = Color.Black;

            //    if (tmpUnit.Owner >= (_hMainHandler.GInformation.Player.Count))
            //        continue;


            //    #region Escape Sequences

            //    /* Ai */
            //    if (_pSettings.MaphackRemoveAi)
            //    {
            //        if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedTypes.PlayerType.Ai))
            //            continue;
            //    }

            //    /* Allie */
            //    if (_pSettings.MaphackRemoveAllie)
            //    {
            //        if (_hMainHandler.GInformation.Player[0].Localplayer < _hMainHandler.GInformation.Player.Count)
            //        {
            //            if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Team ==
            //                _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Team &&
            //                !_hMainHandler.GInformation.Player[tmpUnit.Owner].IsLocalplayer)
            //                continue;
            //        }
            //    }

            //    /* Localplayer Units */
            //    if (_pSettings.MaphackRemoveLocalplayer)
            //    {
            //        if (tmpUnit.Owner == _hMainHandler.GInformation.Player[0].Localplayer)
            //            continue;
            //    }

            //    /* Neutral Units */
            //    if (_pSettings.MaphackRemoveNeutral)
            //    {
            //        if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedTypes.PlayerType.Neutral))
            //            continue;
            //    }


            //    /* Dead Units */
            //    if ((tmpUnit.TargetFilter & (ulong)PredefinedTypes.TargetFilterFlag.Dead) > 0)
            //        continue;

            //    /* Creep tumor */
            //    if (tmpUnit.Id ==
            //        PredefinedTypes.UnitId.ZbCreeptumorBurrowed)
            //        continue;




            //    #endregion

            //    #region Scalling (Unitposition)

            //    var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
            //    var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;

            //    if (float.IsNaN(iUnitPosX) ||
            //        float.IsNaN(iUnitPosY))
            //    {
            //        continue;
            //    }


            //    #endregion



            //    var fUnitSize = tmpUnit.Size;
            //    var size = 2.0f;

            //    if (fUnitSize >= 0.5)
            //        size = 3;

            //    if (fUnitSize >= 0.875)
            //        size = 4;

            //    if (fUnitSize >= 1.5)
            //        size = 6;

            //    if (fUnitSize >= 2.0)
            //        size = 8;

            //    if (fUnitSize >= 2.5)
            //        size = 10;

            //    size += 0.5f;


            //    #region Actual drawing

            //    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            //    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            //    g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

            //    if (tmpUnit.IsCloaked &&
            //        tmpUnit.Id != PredefinedTypes.UnitId.ZbCreeptumorBurrowed)
            //    {
            //        g.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Gray)), iUnitPosX - size / 2,
            //                                 iUnitPosY - size / 2, size, size);

            //        g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBound)), iUnitPosX - size / 2 - 0.5f,
            //                                 iUnitPosY - size / 2 - 0.5f, size + 1, size + 1);
            //    }

            //    else
            //    {
            //        g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBound)), iUnitPosX - size / 2,
            //                                 iUnitPosY - size / 2, size, size);
            //    }

            //    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            //    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            //    g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

            //    #endregion
            //}

            //#endregion

            //#region Draw Unit (Inner Rectangle)

            //for (var i = 0; i < _hMainHandler.GInformation.Unit.Count; i++)
            //{
            //    var tmpUnit = _hMainHandler.GInformation.Unit[i];
            //    //Color clUnit = LUnit[i].Owner > LPlayer.Count ? Color.Transparent : LPlayer[LUnit[i].Owner].Color;

            //    if (tmpUnit.Owner >= _hMainHandler.GInformation.Player.Count)
            //        continue;


            //    var clUnit = _hMainHandler.GInformation.Player[tmpUnit.Owner].Color;

            //    #region Teamcolor

            //    RendererHelper.TeamColor(_hMainHandler.GInformation.Player, _hMainHandler.GInformation.Unit, i,
            //                              _hMainHandler.GInformation.Gameinfo.IsTeamcolor, ref clUnit);

            //    #endregion

            //    #region Scalling (Unitposition)

            //    var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
            //    var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;


            //    if (float.IsNaN(iUnitPosX) ||
            //        float.IsNaN(iUnitPosY))
            //    {
            //        continue;
            //    }

            //    #endregion

            //    #region Escape Sequences

            //    /* Ai */
            //    if (_pSettings.MaphackRemoveAi)
            //    {
            //        if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedTypes.PlayerType.Ai))
            //            continue;
            //    }

            //    /* Allie */
            //    if (_pSettings.MaphackRemoveAllie)
            //    {
            //        if (_hMainHandler.GInformation.Player[0].Localplayer < _hMainHandler.GInformation.Player.Count)
            //        {
            //            if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Team ==
            //                _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Team &&
            //                !_hMainHandler.GInformation.Player[tmpUnit.Owner].IsLocalplayer)
            //                continue;
            //        }
            //    }

            //    /* Localplayer Units */
            //    if (_pSettings.MaphackRemoveLocalplayer)
            //    {
            //        if (tmpUnit.Owner == _hMainHandler.GInformation.Player[0].Localplayer)
            //            continue;
            //    }

            //    /* Neutral Units */
            //    if (_pSettings.MaphackRemoveNeutral)
            //    {
            //        if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedTypes.PlayerType.Neutral))
            //            continue;
            //    }


            //    /* Dead Units */
            //    if ((tmpUnit.TargetFilter & (ulong)PredefinedTypes.TargetFilterFlag.Dead) > 0)
            //        continue;

            //    /* Creep tumor */
            //    if (tmpUnit.Id ==
            //         PredefinedTypes.UnitId.ZbCreeptumorBurrowed)
            //        continue;




            //    #endregion

            //    var fUnitSize = tmpUnit.Size;
            //    var size = 2.0f;

            //    if (fUnitSize >= 0.5f)
            //        size = 3;

            //    if (fUnitSize >= 0.875)
            //        size = 4;

            //    if (fUnitSize >= 1.5)
            //        size = 6;

            //    if (fUnitSize >= 2.0)
            //        size = 8;

            //    if (fUnitSize >= 2.5)
            //        size = 10;

            //    size -= 0.5f;


            //    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            //    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            //    g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

            //    /* Draw the Unit (Actual Unit) */
            //    g.Graphics.FillRectangle(new SolidBrush(clUnit), iUnitPosX - size / 2, iUnitPosY - size / 2, size, size);

            //    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            //    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            //    g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

            //}

            //#endregion

            //#region Draw Border of special Units

            //for (var i = 0; i < _hMainHandler.GInformation.Unit.Count; i++)
            //{
            //    var tmpUnit = _hMainHandler.GInformation.Unit[i];
            //    var clUnitBoundBorder = Color.Black;

            //    if (tmpUnit.Owner >= (_hMainHandler.GInformation.Player.Count))
            //        continue;


            //    #region Scalling (Unitposition)

            //    var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
            //    var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;


            //    if (float.IsNaN(iUnitPosX) ||
            //        float.IsNaN(iUnitPosY))
            //    {
            //        continue;
            //    }

            //    #endregion

            //    #region Escape Sequences

            //    /* Ai */
            //    if (_pSettings.MaphackRemoveAi)
            //    {
            //        if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedTypes.PlayerType.Ai))
            //            continue; //clUnitBoundBorder = Color.Transparent;

            //    }

            //    /* Allie */
            //    if (_pSettings.MaphackRemoveAllie)
            //    {
            //        if (_hMainHandler.GInformation.Player[0].Localplayer < _hMainHandler.GInformation.Player.Count)
            //        {
            //            if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Team ==
            //                _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Team &&
            //                !_hMainHandler.GInformation.Player[tmpUnit.Owner].IsLocalplayer)
            //                continue; //clUnitBoundBorder = Color.Transparent;

            //        }
            //    }

            //    /* Localplayer Units */
            //    if (_pSettings.MaphackRemoveLocalplayer)
            //    {
            //        if (tmpUnit.Owner == _hMainHandler.GInformation.Player[0].Localplayer)
            //            continue; //clUnitBoundBorder = Color.Transparent;

            //    }

            //    /* Neutral Units */
            //    if (_pSettings.MaphackRemoveNeutral)
            //    {
            //        if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedTypes.PlayerType.Neutral))
            //            continue; //clUnitBoundBorder = Color.Transparent;

            //    }


            //    /* Dead Units */
            //    if ((tmpUnit.TargetFilter & (ulong)PredefinedTypes.TargetFilterFlag.Dead) > 0)
            //        continue;






            //    #endregion


            //    var fUnitSize = tmpUnit.Size;
            //    var size = 2.0f;

            //    if (fUnitSize >= 0.875)
            //        size = 4;

            //    if (fUnitSize >= 1.5)
            //        size = 6;

            //    if (fUnitSize >= 2.0)
            //        size = 8;

            //    if (fUnitSize >= 2.5)
            //        size = 10;

            //    size += 0.5f;


            //    #region Border special Units

            //    #region Self created Units

            //    if (_pSettings.MaphackUnitIds != null ||
            //        _pSettings.MaphackUnitColors != null)
            //    {
            //        for (var j = 0; j < _pSettings.MaphackUnitIds.Count; j++)
            //        {
            //            if (tmpUnit.Id == _pSettings.MaphackUnitIds[j])
            //            {
            //                if (_pSettings.MaphackUnitColors[j] != Color.Transparent)
            //                {
            //                    var clUnit = _pSettings.MaphackUnitColors[j];
            //                    if (!tmpUnit.IsAlive)
            //                        continue;

            //                    if (_pSettings.MaphackRemoveLocalplayer)
            //                    {
            //                        if (tmpUnit.Owner ==
            //                            _hMainHandler.GInformation.Player[0].Localplayer)
            //                            continue;
            //                    }

            //                    g.Graphics.DrawRectangle(
            //                        new Pen(new SolidBrush(clUnit), 1.5f),
            //                        (iUnitPosX - size / 2), (iUnitPosY - size / 2), size, size);

            //                    g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBoundBorder)),
            //                                             iUnitPosX - ((size / 2) + 0.75f),
            //                                             iUnitPosY - ((size / 2) + 0.75f), size + 1.75f, size + 1.75f);
            //                }
            //            }
            //        }
            //    }

            //    #endregion

            //    #region CreepTumors

            //    //if (_hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int) PredefinedTypes.UnitId.ZbCreeptumor)
            //    //{
            //    //    g.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Gray), 1.5f),
            //    //                             (iUnitPosX - size/2), (iUnitPosY - size/2), size, size);

            //    //    g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBoundBorder)),
            //    //                             iUnitPosX - ((size/2) + 0.75f),
            //    //                             iUnitPosY - ((size/2) + 0.75f), size + 1.75f, size + 1.75f);
            //    //}


            //    //if (_hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int)PredefinedTypes.UnitId.ZbCreeptumor ||
            //    //    _hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int)PredefinedTypes.UnitId.ZbCreepTumorBuilding ||
            //    //    _hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int)PredefinedTypes.UnitId.ZbCreepTumorMissle ||
            //    //    _hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int)PredefinedTypes.UnitId.ZbCreeptumorBurrowed)
            //    //{
            //    //    const Int32 iRadius = 4;

            //    //    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //    //    g.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            //    //    g.Graphics.DrawLine(Constants.PBlack1, iUnitPosX - iRadius, iUnitPosY - iRadius, iUnitPosX + iRadius, iUnitPosY + iRadius);
            //    //    g.Graphics.DrawLine(Constants.PBlack1, iUnitPosX + iRadius, iUnitPosY - iRadius, iUnitPosX - iRadius, iUnitPosY + iRadius);

            //    //    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            //    //    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

            //    //}

            //    #endregion

            //    #region Unitgroup I - Defensive Buildings

            //    if (_pSettings.MaphackColorDefensivestructuresYellow)
            //    {
            //        if (tmpUnit.Id == PredefinedTypes.UnitId.TbTurret ||
            //            tmpUnit.Id == PredefinedTypes.UnitId.TbBunker ||
            //            tmpUnit.Id == PredefinedTypes.UnitId.TbPlanetary ||
            //            tmpUnit.Id == PredefinedTypes.UnitId.ZbSpineCrawler ||
            //            tmpUnit.Id == PredefinedTypes.UnitId.ZbSpineCrawlerUnrooted ||
            //            tmpUnit.Id == PredefinedTypes.UnitId.ZbSporeCrawler ||
            //            tmpUnit.Id == PredefinedTypes.UnitId.ZbSporeCrawlerUnrooted ||
            //            tmpUnit.Id == PredefinedTypes.UnitId.PbCannon)
            //        {
            //            var clUnitBound = Color.Yellow;


            //            if ((tmpUnit.TargetFilter & (UInt64)PredefinedTypes.TargetFilterFlag.Dead) > 0)
            //                continue;


            //            if (_pSettings.MaphackRemoveLocalplayer)
            //            {
            //                if (tmpUnit.Owner == _hMainHandler.GInformation.Player[0].Localplayer)
            //                    continue;

            //            }

            //            g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBound), 1.5f),
            //                                     (iUnitPosX - size / 2), (iUnitPosY - size / 2), size, size);

            //            g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBoundBorder)),
            //                                     iUnitPosX - ((size / 2) + 0.75f),
            //                                     iUnitPosY - ((size / 2) + 0.75f), size + 1.75f, size + 1.75f);
            //        }
            //    }

            //    #endregion

            //    #endregion

            //}

            //#endregion

            #region Draw Player camera


                for (var i = 0; i < Players.Count; i++)
                {
                    var tmpPlayer = Players[i];
                    if (tmpPlayer.NameLength <= 0)
                    {
                        var ptCol = new PointCollection();
                        ptCol.Add(new Point(CnvMainCanvas.ActualWidth + 10, CnvMainCanvas.ActualHeight + 10));
                        _lPolygons[i].Points = ptCol;
                    }

                    var bR = Players[i].Color.R;
                    var bG = Players[i].Color.G;
                    var bB = Players[i].Color.B;

                    var clPlayercolor = Color.FromArgb(255, bR, bG, bB);

                    #region Teamcolor

                    if (Gameinfo.IsTeamcolor)
                    {
                        if (Players[0].Localplayer < Players.Count)
                        {
                            if (Players[i].IsLocalplayer)
                                clPlayercolor = Colors.Green;

                            else if (Players[i].Team ==
                                     Players[Players[0].Localplayer].Team &&
                                     !Players[i].IsLocalplayer)
                                clPlayercolor = Colors.Yellow;

                            else
                                clPlayercolor = Colors.Red;
                        }
                    }

                    #endregion

                    #region Escape Sequences

                    /* Observer */
                    
                    if (Players[i].Type.Equals(PredefinedTypes.PlayerType.Observer))
                        continue;
                    

                    /* Referee */
                    if (Players[i].Type.Equals(PredefinedTypes.PlayerType.Referee))
                        continue;

                    /* Neutral */
                    if (Players[i].Type.Equals(PredefinedTypes.PlayerType.Neutral))
                        continue;
                    

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

                 

                    var ptPoints = new PointCollection();
                    ptPoints.Add(new Point(fPlayerX - 35f, fPlayerY - 24f));
                    ptPoints.Add(new Point(fPlayerX + 35f, fPlayerY - 24f));
                    ptPoints.Add(new Point(fPlayerX + 24f, fPlayerY + 10f));
                    ptPoints.Add(new Point(fPlayerX - 24f, fPlayerY + 10f));

                    _lPolygons[i].Points = ptPoints;
                    _lPolygons[i].Stroke = new SolidColorBrush(clPlayercolor);
                    _lPolygons[i].Fill = Brushes.Transparent;


                    #endregion


                }

            #endregion

            //#endregion


        }

        private void CnvMainCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DrawMap();
        }
    }

    public class AnotherSc2HackPlugin : IPlugins
    {
        private MainWindow _mMainForm = null;

        public string GetPluginDescription()
        {
            return "This is an example of the usage for the WPF Plugin";
        }

        public string GetPluginName()
        {
            return "Sample WPF Plugin";
        }

        public void SetGameinfo(PredefinedTypes.Gameinformation gameinfo)
        {
            if (_mMainForm != null &&
                _mMainForm.IsLoaded)
            {
                _mMainForm.Gameinfo = gameinfo;
            }
        }

        public void SetGroups(List<PredefinedTypes.Groups> groups)
        {
            if (_mMainForm != null &&
                _mMainForm.IsLoaded)
            {
                _mMainForm.Groups = groups;
            }
        }

        public void SetMap(PredefinedTypes.Map map)
        {
            if (_mMainForm != null &&
                _mMainForm.IsLoaded)
            {
                _mMainForm.Map = map;
            }
        }

        public void SetPlayers(PredefinedTypes.PList players)
        {
            if (_mMainForm != null &&
                _mMainForm.IsLoaded)
            {
                _mMainForm.Players = players;
            }
        }

        public void SetSelection(PredefinedTypes.LSelection selection)
        {
            if (_mMainForm != null &&
                _mMainForm.IsLoaded)
            {
                _mMainForm.Selection = selection;
            }
        }

        public void SetUnits(List<PredefinedTypes.Unit> units)
        {
            if (_mMainForm != null &&
                _mMainForm.IsLoaded)
            {
                _mMainForm.Units = units;
            }
        }


        public void StartPlugin()
        {

            if (_mMainForm == null)
                _mMainForm = new MainWindow();


            if (_mMainForm.IsLoaded)
                _mMainForm.Close();

            else
            {

                _mMainForm = new MainWindow();
                _mMainForm.Show();
            }




        }

        public void StopPlugin()
        {
            if (_mMainForm != null)
                _mMainForm.Close();
        }





        public bool GetRequiresGameinfo()
        {
            return true;
        }

        public bool GetRequiresGroups()
        {
            return true;
        }

        public bool GetRequiresMap()
        {
            return true;
        }

        public bool GetRequiresPlayer()
        {
            return true;
        }

        public bool GetRequiresSelection()
        {
            return true;
        }

        public bool GetRequiresUnit()
        {
            return true;
        }
    }
}
