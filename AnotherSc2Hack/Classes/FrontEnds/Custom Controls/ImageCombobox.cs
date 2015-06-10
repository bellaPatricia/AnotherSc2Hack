using System.Drawing;
using System.Windows.Forms;
using PredefinedTypes;
using Utilities.ExtensionMethods;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    class ImageCombobox : ComboBox
    {
        private ImageList _imgs = new ImageList();

        private Size _imageSize = new Size(30,30);

        public Size ImageSize
        {
            get { return _imageSize; }
            set { _imageSize = value; }
        }

        private bool _initializeUnits = false;

        public bool InitializeUnits
        {
            get {  return _initializeUnits;}
            set
            {
                _initializeUnits = value;

                if (value)
                    LoadUnits();

                else 
                    Items.Clear();
            }
        }

		// constructor
		public ImageCombobox()
		{
			// set draw mode to owner draw
			DrawMode = DrawMode.OwnerDrawFixed;

		    SetStyle(ControlStyles.OptimizedDoubleBuffer |
		             ControlStyles.DoubleBuffer |
		             ControlStyles.AllPaintingInWmPaint, true);
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
           

			// check if it is an item from the Items collection
			if (e.Index < 0)

				// not an item, draw the text (indented)
				e.Graphics.DrawString(Text, Font, new SolidBrush(e.ForeColor), e.Bounds.Left + _imgs.ImageSize.Width, e.Bounds.Top);

			else
			{
				
				// check if item is an ImageComboItem
				if (Items[e.Index].GetType() == typeof(ImageComboItem)) 
				{															

					// get item to draw
					var item = (ImageComboItem) Items[e.Index];
                    
                    

					// get forecolor & font
					var forecolor = (item.ForeColor != Color.FromKnownColor(KnownColor.Transparent)) ? item.ForeColor : Color.Black;
				    var clBackground = e.Index%2 == 0 ? new SolidBrush(BackColor) : Brushes.WhiteSmoke;
					Font font = item.Mark ? new Font(Font, FontStyle.Bold) : Font;

                    var fHeightXPoint = ItemHeight - TextRenderer.MeasureText(item.Text, font).Height;
                    fHeightXPoint /= 2;

				    
                    //Draw the correct background
				    if (e.State == DrawItemState.Selected ||
				        e.State == (DrawItemState.Focus | DrawItemState.Selected))
				        e.Graphics.FillRectangle(new SolidBrush(Color.RoyalBlue), e.Bounds);

				    else
				        e.Graphics.FillRectangle(clBackground, e.Bounds);




				    // -1: no image
				    if (item.ImageIndex != -1)
				    {
				        // draw image, then draw text next to it
				        ImageList.Draw(e.Graphics, e.Bounds.Left, e.Bounds.Top, item.ImageIndex);
				        e.Graphics.DrawString(item.Text, font, new SolidBrush(forecolor), e.Bounds.Left + _imgs.ImageSize.Width,
				            e.Bounds.Top);
				    }

                    //Draw the set image
				    else if (item.Image != null)
				    {
				        //Image
				        e.Graphics.DrawImage(item.Image, e.Bounds.Left, e.Bounds.Top, ImageSize.Width, ImageSize.Height);

                        //Text
                        e.Graphics.DrawString(item.Text, font, new SolidBrush(forecolor), e.Bounds.Left + ImageSize.Width,
                            e.Bounds.Top+ fHeightXPoint);

                        //Background Image
				        if (item.BackgroundImage != null)    
				            e.Graphics.DrawImage(item.BackgroundImage, e.Bounds.Right - ImageSize.Width, e.Bounds.Top, ImageSize.Width, ImageSize.Height);
				        
				    }

				    else
				    {
                        // draw text (indented)
                        e.Graphics.DrawString(item.Text, font, new SolidBrush(forecolor), e.Bounds.Left,
                            e.Bounds.Top + fHeightXPoint);
				    }
				}
				else
				
					// it is not an ImageComboItem, draw it
					e.Graphics.DrawString(Items[e.Index].ToString(), Font, new SolidBrush(e.ForeColor), e.Bounds.Left + _imgs.ImageSize.Width, e.Bounds.Top);
				
			}

			base.OnDrawItem (e);
		}

        //So we only have to do this once...
        private void LoadUnits()
        {
            var imgTerran = Properties.Resources.Race_Terran64.SetImageOpacity(0.5f);
            var imgProtoss = Properties.Resources.Race_Protoss64.SetImageOpacity(0.5f);
            var imgZerg = Properties.Resources.Race_Zerg64.SetImageOpacity(0.5f);
            

            #region Terran

            #region Units

            Items.Add(new ImageComboItem("SCV", Properties.Resources.trans_tu_scv, PredefinedData.UnitId.TuScv, imgTerran));
            Items.Add(new ImageComboItem("MULE", Properties.Resources.trans_tu_mule, PredefinedData.UnitId.TuMule, imgTerran));
            Items.Add(new ImageComboItem("Marine", Properties.Resources.trans_tu_marine, PredefinedData.UnitId.TuMarine, imgTerran));
            Items.Add(new ImageComboItem("Marauder", Properties.Resources.trans_tu_marauder, PredefinedData.UnitId.TuMarauder, imgTerran));
            Items.Add(new ImageComboItem("Reaper", Properties.Resources.trans_tu_reaper, PredefinedData.UnitId.TuReaper, imgTerran));
            Items.Add(new ImageComboItem("Ghost", Properties.Resources.trans_tu_ghost, PredefinedData.UnitId.TuGhost, imgTerran));
            Items.Add(new ImageComboItem("Hellion", Properties.Resources.trans_tu_hellion, PredefinedData.UnitId.TuHellion, imgTerran));
            Items.Add(new ImageComboItem("Hellbat", Properties.Resources.trans_tu_hellbat, PredefinedData.UnitId.TuHellbat, imgTerran));
            Items.Add(new ImageComboItem("Widow Mine", Properties.Resources.trans_tu_widowmine, PredefinedData.UnitId.TuWidowMine, imgTerran));
            Items.Add(new ImageComboItem("Siege Tank", Properties.Resources.trans_tu_siegetank, PredefinedData.UnitId.TuSiegetank, imgTerran));
            Items.Add(new ImageComboItem("Thor", Properties.Resources.trans_tu_thor, PredefinedData.UnitId.TuThor, imgTerran));
            Items.Add(new ImageComboItem("Viking", Properties.Resources.trans_tu_vikingair, PredefinedData.UnitId.TuVikingAir, imgTerran));
            Items.Add(new ImageComboItem("Medivac", Properties.Resources.trans_tu_medivac, PredefinedData.UnitId.TuMedivac, imgTerran));
            Items.Add(new ImageComboItem("Banshee", Properties.Resources.trans_tu_banshee, PredefinedData.UnitId.TuBanshee, imgTerran));
            Items.Add(new ImageComboItem("Raven", Properties.Resources.trans_tu_raven, PredefinedData.UnitId.TuRaven, imgTerran));
            Items.Add(new ImageComboItem("Battlecruiser", Properties.Resources.trans_tu_battlecruiser, PredefinedData.UnitId.TuBattlecruiser, imgTerran));

            #endregion

            #region Buildings

            Items.Add(new ImageComboItem("Command Center", Properties.Resources.trans_tb_commandcenter, PredefinedData.UnitId.TbCcGround, imgTerran));
            Items.Add(new ImageComboItem("Orbital Command", Properties.Resources.trans_tb_orbitalcommand, PredefinedData.UnitId.TbOrbitalGround, imgTerran));
            Items.Add(new ImageComboItem("Planetary Fortress", Properties.Resources.trans_tb_planetaryfortress, PredefinedData.UnitId.TbPlanetary, imgTerran));
            Items.Add(new ImageComboItem("Supply Depot", Properties.Resources.trans_tb_supplydepot, PredefinedData.UnitId.TbSupplyGround, imgTerran));
            Items.Add(new ImageComboItem("Barracks", Properties.Resources.trans_tb_barracks, PredefinedData.UnitId.TbBarracksGround, imgTerran));
            Items.Add(new ImageComboItem("Refinery", Properties.Resources.trans_tb_refinery, PredefinedData.UnitId.TbRefinery, imgTerran));
            Items.Add(new ImageComboItem("Bunker", Properties.Resources.trans_tb_bunker, PredefinedData.UnitId.TbBunker, imgTerran));
            Items.Add(new ImageComboItem("Engineering Bay", Properties.Resources.trans_tb_engineeringbay, PredefinedData.UnitId.TbEbay, imgTerran));
            Items.Add(new ImageComboItem("Missle Turret", Properties.Resources.trans_tb_missileturret, PredefinedData.UnitId.TbTurret, imgTerran));
            Items.Add(new ImageComboItem("Sensor Tower", Properties.Resources.trans_tb_sensortower, PredefinedData.UnitId.TbSensortower, imgTerran));
            Items.Add(new ImageComboItem("Factory", Properties.Resources.trans_tb_factory, PredefinedData.UnitId.TbFactoryGround, imgTerran));
            Items.Add(new ImageComboItem("Starport", Properties.Resources.trans_tb_starport, PredefinedData.UnitId.TbStarportGround, imgTerran));
            Items.Add(new ImageComboItem("Ghost Academy", Properties.Resources.trans_tb_ghostacademy, PredefinedData.UnitId.TbGhostacademy, imgTerran));
            Items.Add(new ImageComboItem("Fusion Core", Properties.Resources.trans_tb_fusioncore, PredefinedData.UnitId.TbFusioncore, imgTerran));
            Items.Add(new ImageComboItem("Armory", Properties.Resources.trans_tb_armory, PredefinedData.UnitId.TbArmory, imgTerran));

            #endregion

            #endregion

            #region Protoss

            #region Units

            Items.Add(new ImageComboItem("Probe", Properties.Resources.trans_pu_probe, PredefinedData.UnitId.PuProbe, imgProtoss));
            Items.Add(new ImageComboItem("Zealot", Properties.Resources.trans_pu_zealot, PredefinedData.UnitId.PuZealot, imgProtoss));
            Items.Add(new ImageComboItem("Stalker", Properties.Resources.trans_pu_stalker, PredefinedData.UnitId.PuStalker, imgProtoss));
            Items.Add(new ImageComboItem("Sentry", Properties.Resources.trans_pu_sentry, PredefinedData.UnitId.PuSentry, imgProtoss));
            Items.Add(new ImageComboItem("Dark Templar", Properties.Resources.trans_pu_darktemplar, PredefinedData.UnitId.PuDarktemplar, imgProtoss));
            Items.Add(new ImageComboItem("High Templar", Properties.Resources.trans_pu_hightemplar, PredefinedData.UnitId.PuHightemplar, imgProtoss));
            Items.Add(new ImageComboItem("Immortal", Properties.Resources.trans_pu_immortal, PredefinedData.UnitId.PuImmortal, imgProtoss));
            Items.Add(new ImageComboItem("Observer", Properties.Resources.trans_pu_observer, PredefinedData.UnitId.PuObserver, imgProtoss));
            Items.Add(new ImageComboItem("Warp Prism", Properties.Resources.trans_pu_warpprism, PredefinedData.UnitId.PuWarpprismTransport, imgProtoss));
            Items.Add(new ImageComboItem("Colossus", Properties.Resources.trans_pu_colossus, PredefinedData.UnitId.PuColossus, imgProtoss));
            Items.Add(new ImageComboItem("Phoenix", Properties.Resources.trans_pu_phoenix, PredefinedData.UnitId.PuPhoenix, imgProtoss));
            Items.Add(new ImageComboItem("Void Ray", Properties.Resources.trans_pu_voidray, PredefinedData.UnitId.PuVoidray, imgProtoss));
            Items.Add(new ImageComboItem("oracle", Properties.Resources.trans_pu_oracle, PredefinedData.UnitId.PuOracle, imgProtoss));
            Items.Add(new ImageComboItem("Tenpest", Properties.Resources.trans_pu_tempest, PredefinedData.UnitId.PuTempest, imgProtoss));
            Items.Add(new ImageComboItem("Carrier", Properties.Resources.trans_pu_carrier, PredefinedData.UnitId.PuCarrier, imgProtoss));
            Items.Add(new ImageComboItem("Mothership Core", Properties.Resources.trans_pu_mothershipcore, PredefinedData.UnitId.PuMothershipCore, imgProtoss));
            Items.Add(new ImageComboItem("Mothership", Properties.Resources.trans_pu_mothership, PredefinedData.UnitId.PuMothership, imgProtoss));

            #endregion 

            #region Buildings

            Items.Add(new ImageComboItem("Nexus", Properties.Resources.trans_pb_nexus, PredefinedData.UnitId.PbNexus, imgProtoss));
            Items.Add(new ImageComboItem("Pylon", Properties.Resources.trans_pb_pylon, PredefinedData.UnitId.PbPylon, imgProtoss));
            Items.Add(new ImageComboItem("Gateway", Properties.Resources.trans_pb_gateway, PredefinedData.UnitId.PbGateway, imgProtoss));
            Items.Add(new ImageComboItem("Warpgate", Properties.Resources.trans_pb_warpgate, PredefinedData.UnitId.PupWarpGate, imgProtoss));
            Items.Add(new ImageComboItem("Assimilator", Properties.Resources.trans_pb_assimilator, PredefinedData.UnitId.PbAssimilator, imgProtoss));
            Items.Add(new ImageComboItem("Photon Cannon", Properties.Resources.trans_pb_photoncannon, PredefinedData.UnitId.PbCannon, imgProtoss));
            Items.Add(new ImageComboItem("Forge", Properties.Resources.trans_pb_forge, PredefinedData.UnitId.PbForge, imgProtoss));
            Items.Add(new ImageComboItem("Templar Archive", Properties.Resources.trans_pb_templararchive, PredefinedData.UnitId.PbTemplararchives, imgProtoss));
            Items.Add(new ImageComboItem("Dark Shrine", Properties.Resources.trans_pb_darkshrine, PredefinedData.UnitId.PbDarkshrine, imgProtoss));
            Items.Add(new ImageComboItem("Twilight Council", Properties.Resources.trans_pb_twilightcouncil, PredefinedData.UnitId.PbTwilightcouncil, imgProtoss));
            Items.Add(new ImageComboItem("Stargate", Properties.Resources.trans_pb_stargate, PredefinedData.UnitId.PbStargate, imgProtoss));
            Items.Add(new ImageComboItem("Robotics Bay", Properties.Resources.trans_pb_roboticsbay, PredefinedData.UnitId.PbRoboticssupportbay, imgProtoss));
            Items.Add(new ImageComboItem("Robotics Facility", Properties.Resources.trans_pb_roboticsfacility, PredefinedData.UnitId.PbRoboticsbay, imgProtoss));
            Items.Add(new ImageComboItem("Fleet Beacon", Properties.Resources.trans_pb_fleetbeacon, PredefinedData.UnitId.PbFleetbeacon, imgProtoss));

            #endregion

            #endregion

            #region Zerg

            #region Units

            Items.Add(new ImageComboItem("Larva", Properties.Resources.trans_zu_larva, PredefinedData.UnitId.ZuLarva, imgZerg));
            Items.Add(new ImageComboItem("Queen", Properties.Resources.trans_zu_queen, PredefinedData.UnitId.ZuQueen, imgZerg));
            Items.Add(new ImageComboItem("Drone", Properties.Resources.trans_zu_drone, PredefinedData.UnitId.ZuDrone, imgZerg));
            Items.Add(new ImageComboItem("Zergling", Properties.Resources.trans_zu_zergling, PredefinedData.UnitId.ZuZergling, imgZerg));
            Items.Add(new ImageComboItem("Baneling Cocoon", Properties.Resources.trans_zu_banelingcocoon, PredefinedData.UnitId.ZuBanelingCocoon, imgZerg));
            Items.Add(new ImageComboItem("Baneling", Properties.Resources.trans_zu_baneling, PredefinedData.UnitId.ZuBaneling, imgZerg));
            Items.Add(new ImageComboItem("Roach", Properties.Resources.trans_zu_roach, PredefinedData.UnitId.ZuRoach, imgZerg));
            Items.Add(new ImageComboItem("Hydralisk", Properties.Resources.trans_zu_hydralisk, PredefinedData.UnitId.ZuHydralisk, imgZerg));
            Items.Add(new ImageComboItem("Mutalisk", Properties.Resources.trans_zu_mutalisk, PredefinedData.UnitId.ZuMutalisk, imgZerg));
            Items.Add(new ImageComboItem("Infestor", Properties.Resources.trans_zu_infestor, PredefinedData.UnitId.ZuInfestor, imgZerg));
            Items.Add(new ImageComboItem("Infested Terran", Properties.Resources.trans_zu_InfestedTerran, PredefinedData.UnitId.ZuInfestedTerran, imgZerg));
            Items.Add(new ImageComboItem("Viper", Properties.Resources.trans_zu_viper, PredefinedData.UnitId.ZuViper, imgZerg));
            Items.Add(new ImageComboItem("Corruptor", Properties.Resources.trans_zu_corruptor, PredefinedData.UnitId.ZuCorruptor, imgZerg));
            Items.Add(new ImageComboItem("Changeling", Properties.Resources.trans_zu_changeling, PredefinedData.UnitId.ZuChangeling, imgZerg));
            Items.Add(new ImageComboItem("Broodlord Cocoon", Properties.Resources.trans_zu_BroodLordCocoon, PredefinedData.UnitId.ZuBroodlordCocoon, imgZerg));
            Items.Add(new ImageComboItem("Broodlord", Properties.Resources.trans_zu_broodlord, PredefinedData.UnitId.ZuBroodlord, imgZerg));
            Items.Add(new ImageComboItem("Ultralisk", Properties.Resources.trans_zu_ultralisk, PredefinedData.UnitId.ZuUltra, imgZerg));

            #endregion

            #region Buildings

            Items.Add(new ImageComboItem("Hatchery", Properties.Resources.trans_zb_hatchery, PredefinedData.UnitId.ZbHatchery, imgZerg));
            Items.Add(new ImageComboItem("Lair", Properties.Resources.trans_zb_lair, PredefinedData.UnitId.ZbLiar, imgZerg));
            Items.Add(new ImageComboItem("Hive", Properties.Resources.trans_zb_hive, PredefinedData.UnitId.ZbHive, imgZerg));
            Items.Add(new ImageComboItem("Spawning Pool", Properties.Resources.trans_zb_spawningpool, PredefinedData.UnitId.ZbSpawningPool, imgZerg));
            Items.Add(new ImageComboItem("Baneling Nest", Properties.Resources.trans_zb_banelingnest, PredefinedData.UnitId.ZbBanelingNest, imgZerg));
            Items.Add(new ImageComboItem("Evolution Chamber", Properties.Resources.trans_zb_evolutionchamber, PredefinedData.UnitId.ZbEvolutionChamber, imgZerg));
            Items.Add(new ImageComboItem("Spine Crawler", Properties.Resources.trans_zb_spinecrawler, PredefinedData.UnitId.ZbSpineCrawler, imgZerg));
            Items.Add(new ImageComboItem("Sport Crawler", Properties.Resources.trans_zb_sporecrawler, PredefinedData.UnitId.ZbSporeCrawler, imgZerg));
            Items.Add(new ImageComboItem("Roach Warren", Properties.Resources.trans_zb_roachwarren, PredefinedData.UnitId.ZbRoachWarren, imgZerg));
            Items.Add(new ImageComboItem("Hydralisk Den", Properties.Resources.trans_zb_hydraliskden, PredefinedData.UnitId.ZbHydraDen, imgZerg));
            Items.Add(new ImageComboItem("Infestation Pit", Properties.Resources.trans_zb_infestationpit, PredefinedData.UnitId.ZbInfestationPit, imgZerg));
            Items.Add(new ImageComboItem("Spire", Properties.Resources.trans_zb_spire, PredefinedData.UnitId.ZbSpire, imgZerg));
            Items.Add(new ImageComboItem("Greater Spire", Properties.Resources.trans_zb_greaterspire, PredefinedData.UnitId.ZbGreaterspire, imgZerg));
            Items.Add(new ImageComboItem("Ultralisk Cavern", Properties.Resources.trans_zb_ultraliskcavern, PredefinedData.UnitId.ZbUltraCavern, imgZerg));

            #endregion

            #endregion
        }
		
	
    }

    public class ImageComboItem
    {

        #region Constructors

        public ImageComboItem(string text)
        {
            Text = text;
        }

        public ImageComboItem(string text, Image image)
        {
            Text = text;
            Image = image;
        }

        public ImageComboItem(string text, Image image, PredefinedData.UnitId unitId)
        {
            Text = text;
            Image = image;
            UnitId = unitId;
        }

        public ImageComboItem(string text, Image image, PredefinedData.UnitId unitId, Image backgroundImage)
        {
            Text = text;
            Image = image;
            UnitId = unitId;
            BackgroundImage = backgroundImage;
        }

        public ImageComboItem(string text, int imageIndex)
        {
            Text = text;
            ImageIndex = imageIndex;
        }

        public ImageComboItem(string text, int imageIndex, bool mark)
        {
            Text = text;
            ImageIndex = imageIndex;
            Mark = mark;
        }

        public ImageComboItem(string text, int imageIndex, bool mark, Color foreColor)
        {
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

        #endregion

        #region Properties

        private Color _foreColor = Color.FromKnownColor(KnownColor.Transparent);

        public Color ForeColor
        {
            get {return _foreColor;}
            set { _foreColor = value; }
        }

        private int _imageIndex = -1;

        public int ImageIndex
        {
            get { return _imageIndex; }
            set { _imageIndex = value; }
        }

        public bool Mark { get; set; }

        public object Tag { get; set; }

        public string Text { get; set; }

        private Image _image = null;

        public Image Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public Image BackgroundImage { get; set; }

        private PredefinedData.UnitId _unitId = PredefinedData.UnitId.NbXelNagaTower;

        public PredefinedData.UnitId UnitId
        {
            get { return _unitId; }
            set { _unitId = value; }
        }

        #endregion

        // ToString() should return item text
        public override string ToString()
        {
            return Text;
        }
    }
}
