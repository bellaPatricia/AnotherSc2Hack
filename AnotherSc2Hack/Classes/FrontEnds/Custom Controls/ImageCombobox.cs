using System.Drawing;
using System.Windows.Forms;
using AnotherSc2Hack.Properties;
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
            var imgTerran = Resources.Race_Terran64.SetImageOpacity(0.5f);
            var imgProtoss = Resources.Race_Protoss64.SetImageOpacity(0.5f);
            var imgZerg = Resources.Race_Zerg64.SetImageOpacity(0.5f);
            

            #region Terran

            #region Units

            Items.Add(new ImageComboItem("SCV", Resources.trans_tu_scv, UnitId.TuScv, imgTerran));
            Items.Add(new ImageComboItem("MULE", Resources.trans_tu_mule, UnitId.TuMule, imgTerran));
            Items.Add(new ImageComboItem("Marine", Resources.trans_tu_marine, UnitId.TuMarine, imgTerran));
            Items.Add(new ImageComboItem("Marauder", Resources.trans_tu_marauder, UnitId.TuMarauder, imgTerran));
            Items.Add(new ImageComboItem("Reaper", Resources.trans_tu_reaper, UnitId.TuReaper, imgTerran));
            Items.Add(new ImageComboItem("Ghost", Resources.trans_tu_ghost, UnitId.TuGhost, imgTerran));
            Items.Add(new ImageComboItem("Hellion", Resources.trans_tu_hellion, UnitId.TuHellion, imgTerran));
            Items.Add(new ImageComboItem("Hellbat", Resources.trans_tu_hellbat, UnitId.TuHellbat, imgTerran));
            Items.Add(new ImageComboItem("Widow Mine", Resources.trans_tu_widowmine, UnitId.TuWidowMine, imgTerran));
            Items.Add(new ImageComboItem("Siege Tank", Resources.trans_tu_siegetank, UnitId.TuSiegetank, imgTerran));
            Items.Add(new ImageComboItem("Thor", Resources.trans_tu_thor, UnitId.TuThor, imgTerran));
            Items.Add(new ImageComboItem("Viking", Resources.trans_tu_vikingair, UnitId.TuVikingAir, imgTerran));
            Items.Add(new ImageComboItem("Medivac", Resources.trans_tu_medivac, UnitId.TuMedivac, imgTerran));
            Items.Add(new ImageComboItem("Banshee", Resources.trans_tu_banshee, UnitId.TuBanshee, imgTerran));
            Items.Add(new ImageComboItem("Raven", Resources.trans_tu_raven, UnitId.TuRaven, imgTerran));
            Items.Add(new ImageComboItem("Battlecruiser", Resources.trans_tu_battlecruiser, UnitId.TuBattlecruiser, imgTerran));

            #endregion

            #region Buildings

            Items.Add(new ImageComboItem("Command Center", Resources.trans_tb_commandcenter, UnitId.TbCcGround, imgTerran));
            Items.Add(new ImageComboItem("Orbital Command", Resources.trans_tb_orbitalcommand, UnitId.TbOrbitalGround, imgTerran));
            Items.Add(new ImageComboItem("Planetary Fortress", Resources.trans_tb_planetaryfortress, UnitId.TbPlanetary, imgTerran));
            Items.Add(new ImageComboItem("Supply Depot", Resources.trans_tb_supplydepot, UnitId.TbSupplyGround, imgTerran));
            Items.Add(new ImageComboItem("Barracks", Resources.trans_tb_barracks, UnitId.TbBarracksGround, imgTerran));
            Items.Add(new ImageComboItem("Refinery", Resources.trans_tb_refinery, UnitId.TbRefinery, imgTerran));
            Items.Add(new ImageComboItem("Bunker", Resources.trans_tb_bunker, UnitId.TbBunker, imgTerran));
            Items.Add(new ImageComboItem("Engineering Bay", Resources.trans_tb_engineeringbay, UnitId.TbEbay, imgTerran));
            Items.Add(new ImageComboItem("Missle Turret", Resources.trans_tb_missileturret, UnitId.TbTurret, imgTerran));
            Items.Add(new ImageComboItem("Sensor Tower", Resources.trans_tb_sensortower, UnitId.TbSensortower, imgTerran));
            Items.Add(new ImageComboItem("Factory", Resources.trans_tb_factory, UnitId.TbFactoryGround, imgTerran));
            Items.Add(new ImageComboItem("Starport", Resources.trans_tb_starport, UnitId.TbStarportGround, imgTerran));
            Items.Add(new ImageComboItem("Ghost Academy", Resources.trans_tb_ghostacademy, UnitId.TbGhostacademy, imgTerran));
            Items.Add(new ImageComboItem("Fusion Core", Resources.trans_tb_fusioncore, UnitId.TbFusioncore, imgTerran));
            Items.Add(new ImageComboItem("Armory", Resources.trans_tb_armory, UnitId.TbArmory, imgTerran));

            #endregion

            #endregion

            #region Protoss

            #region Units

            Items.Add(new ImageComboItem("Probe", Resources.trans_pu_probe, UnitId.PuProbe, imgProtoss));
            Items.Add(new ImageComboItem("Zealot", Resources.trans_pu_zealot, UnitId.PuZealot, imgProtoss));
            Items.Add(new ImageComboItem("Stalker", Resources.trans_pu_stalker, UnitId.PuStalker, imgProtoss));
            Items.Add(new ImageComboItem("Sentry", Resources.trans_pu_sentry, UnitId.PuSentry, imgProtoss));
            Items.Add(new ImageComboItem("Dark Templar", Resources.trans_pu_darktemplar, UnitId.PuDarktemplar, imgProtoss));
            Items.Add(new ImageComboItem("High Templar", Resources.trans_pu_hightemplar, UnitId.PuHightemplar, imgProtoss));
            Items.Add(new ImageComboItem("Immortal", Resources.trans_pu_immortal, UnitId.PuImmortal, imgProtoss));
            Items.Add(new ImageComboItem("Observer", Resources.trans_pu_observer, UnitId.PuObserver, imgProtoss));
            Items.Add(new ImageComboItem("Warp Prism", Resources.trans_pu_warpprism, UnitId.PuWarpprismTransport, imgProtoss));
            Items.Add(new ImageComboItem("Colossus", Resources.trans_pu_colossus, UnitId.PuColossus, imgProtoss));
            Items.Add(new ImageComboItem("Phoenix", Resources.trans_pu_phoenix, UnitId.PuPhoenix, imgProtoss));
            Items.Add(new ImageComboItem("Void Ray", Resources.trans_pu_voidray, UnitId.PuVoidray, imgProtoss));
            Items.Add(new ImageComboItem("oracle", Resources.trans_pu_oracle, UnitId.PuOracle, imgProtoss));
            Items.Add(new ImageComboItem("Tenpest", Resources.trans_pu_tempest, UnitId.PuTempest, imgProtoss));
            Items.Add(new ImageComboItem("Carrier", Resources.trans_pu_carrier, UnitId.PuCarrier, imgProtoss));
            Items.Add(new ImageComboItem("Mothership Core", Resources.trans_pu_mothershipcore, UnitId.PuMothershipCore, imgProtoss));
            Items.Add(new ImageComboItem("Mothership", Resources.trans_pu_mothership, UnitId.PuMothership, imgProtoss));

            #endregion 

            #region Buildings

            Items.Add(new ImageComboItem("Nexus", Resources.trans_pb_nexus, UnitId.PbNexus, imgProtoss));
            Items.Add(new ImageComboItem("Pylon", Resources.trans_pb_pylon, UnitId.PbPylon, imgProtoss));
            Items.Add(new ImageComboItem("Gateway", Resources.trans_pb_gateway, UnitId.PbGateway, imgProtoss));
            Items.Add(new ImageComboItem("Warpgate", Resources.trans_pb_warpgate, UnitId.PupWarpGate, imgProtoss));
            Items.Add(new ImageComboItem("Assimilator", Resources.trans_pb_assimilator, UnitId.PbAssimilator, imgProtoss));
            Items.Add(new ImageComboItem("Photon Cannon", Resources.trans_pb_photoncannon, UnitId.PbCannon, imgProtoss));
            Items.Add(new ImageComboItem("Forge", Resources.trans_pb_forge, UnitId.PbForge, imgProtoss));
            Items.Add(new ImageComboItem("Templar Archive", Resources.trans_pb_templararchive, UnitId.PbTemplararchives, imgProtoss));
            Items.Add(new ImageComboItem("Dark Shrine", Resources.trans_pb_darkshrine, UnitId.PbDarkshrine, imgProtoss));
            Items.Add(new ImageComboItem("Twilight Council", Resources.trans_pb_twilightcouncil, UnitId.PbTwilightcouncil, imgProtoss));
            Items.Add(new ImageComboItem("Stargate", Resources.trans_pb_stargate, UnitId.PbStargate, imgProtoss));
            Items.Add(new ImageComboItem("Robotics Bay", Resources.trans_pb_roboticsbay, UnitId.PbRoboticssupportbay, imgProtoss));
            Items.Add(new ImageComboItem("Robotics Facility", Resources.trans_pb_roboticsfacility, UnitId.PbRoboticsbay, imgProtoss));
            Items.Add(new ImageComboItem("Fleet Beacon", Resources.trans_pb_fleetbeacon, UnitId.PbFleetbeacon, imgProtoss));

            #endregion

            #endregion

            #region Zerg

            #region Units

            Items.Add(new ImageComboItem("Larva", Resources.trans_zu_larva, UnitId.ZuLarva, imgZerg));
            Items.Add(new ImageComboItem("Queen", Resources.trans_zu_queen, UnitId.ZuQueen, imgZerg));
            Items.Add(new ImageComboItem("Drone", Resources.trans_zu_drone, UnitId.ZuDrone, imgZerg));
            Items.Add(new ImageComboItem("Overlord", Resources.trans_zu_overlord, UnitId.ZuOverlord, imgZerg));
            Items.Add(new ImageComboItem("Overseer", Resources.trans_zu_overseer, UnitId.ZuOverseer, imgZerg));
            Items.Add(new ImageComboItem("Zergling", Resources.trans_zu_zergling, UnitId.ZuZergling, imgZerg));
            Items.Add(new ImageComboItem("Baneling Cocoon", Resources.trans_zu_banelingcocoon, UnitId.ZuBanelingCocoon, imgZerg));
            Items.Add(new ImageComboItem("Baneling", Resources.trans_zu_baneling, UnitId.ZuBaneling, imgZerg));
            Items.Add(new ImageComboItem("Roach", Resources.trans_zu_roach, UnitId.ZuRoach, imgZerg));
            Items.Add(new ImageComboItem("Hydralisk", Resources.trans_zu_hydralisk, UnitId.ZuHydralisk, imgZerg));
            Items.Add(new ImageComboItem("Mutalisk", Resources.trans_zu_mutalisk, UnitId.ZuMutalisk, imgZerg));
            Items.Add(new ImageComboItem("Infestor", Resources.trans_zu_infestor, UnitId.ZuInfestor, imgZerg));
            Items.Add(new ImageComboItem("Infested Terran", Resources.trans_zu_InfestedTerran, UnitId.ZuInfestedTerran, imgZerg));
            Items.Add(new ImageComboItem("Viper", Resources.trans_zu_viper, UnitId.ZuViper, imgZerg));
            Items.Add(new ImageComboItem("Corruptor", Resources.trans_zu_corruptor, UnitId.ZuCorruptor, imgZerg));
            Items.Add(new ImageComboItem("Changeling", Resources.trans_zu_changeling, UnitId.ZuChangeling, imgZerg));
            Items.Add(new ImageComboItem("Broodlord Cocoon", Resources.trans_zu_BroodLordCocoon, UnitId.ZuBroodlordCocoon, imgZerg));
            Items.Add(new ImageComboItem("Broodlord", Resources.trans_zu_broodlord, UnitId.ZuBroodlord, imgZerg));
            Items.Add(new ImageComboItem("Ultralisk", Resources.trans_zu_ultralisk, UnitId.ZuUltra, imgZerg));

            #endregion

            #region Buildings

            Items.Add(new ImageComboItem("Hatchery", Resources.trans_zb_hatchery, UnitId.ZbHatchery, imgZerg));
            Items.Add(new ImageComboItem("Lair", Resources.trans_zb_lair, UnitId.ZbLiar, imgZerg));
            Items.Add(new ImageComboItem("Hive", Resources.trans_zb_hive, UnitId.ZbHive, imgZerg));
            Items.Add(new ImageComboItem("Spawning Pool", Resources.trans_zb_spawningpool, UnitId.ZbSpawningPool, imgZerg));
            Items.Add(new ImageComboItem("Baneling Nest", Resources.trans_zb_banelingnest, UnitId.ZbBanelingNest, imgZerg));
            Items.Add(new ImageComboItem("Evolution Chamber", Resources.trans_zb_evolutionchamber, UnitId.ZbEvolutionChamber, imgZerg));
            Items.Add(new ImageComboItem("Spine Crawler", Resources.trans_zb_spinecrawler, UnitId.ZbSpineCrawler, imgZerg));
            Items.Add(new ImageComboItem("Sport Crawler", Resources.trans_zb_sporecrawler, UnitId.ZbSporeCrawler, imgZerg));
            Items.Add(new ImageComboItem("Roach Warren", Resources.trans_zb_roachwarren, UnitId.ZbRoachWarren, imgZerg));
            Items.Add(new ImageComboItem("Hydralisk Den", Resources.trans_zb_hydraliskden, UnitId.ZbHydraDen, imgZerg));
            Items.Add(new ImageComboItem("Infestation Pit", Resources.trans_zb_infestationpit, UnitId.ZbInfestationPit, imgZerg));
            Items.Add(new ImageComboItem("Spire", Resources.trans_zb_spire, UnitId.ZbSpire, imgZerg));
            Items.Add(new ImageComboItem("Greater Spire", Resources.trans_zb_greaterspire, UnitId.ZbGreaterspire, imgZerg));
            Items.Add(new ImageComboItem("Ultralisk Cavern", Resources.trans_zb_ultraliskcavern, UnitId.ZbUltraCavern, imgZerg));

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

        public ImageComboItem(string text, Image image, UnitId unitId)
        {
            Text = text;
            Image = image;
            UnitId = unitId;
        }

        public ImageComboItem(string text, Image image, UnitId unitId, Image backgroundImage)
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

        private UnitId _unitId = UnitId.NbXelNagaTower;

        public UnitId UnitId
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
