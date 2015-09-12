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

            Items.Add(new ImageComboItem("SCV", Properties.Resources.trans_tu_scv, UnitId.TuScv, imgTerran));
            Items.Add(new ImageComboItem("MULE", Properties.Resources.trans_tu_mule, UnitId.TuMule, imgTerran));
            Items.Add(new ImageComboItem("Marine", Properties.Resources.trans_tu_marine, UnitId.TuMarine, imgTerran));
            Items.Add(new ImageComboItem("Marauder", Properties.Resources.trans_tu_marauder, UnitId.TuMarauder, imgTerran));
            Items.Add(new ImageComboItem("Reaper", Properties.Resources.trans_tu_reaper, UnitId.TuReaper, imgTerran));
            Items.Add(new ImageComboItem("Ghost", Properties.Resources.trans_tu_ghost, UnitId.TuGhost, imgTerran));
            Items.Add(new ImageComboItem("Hellion", Properties.Resources.trans_tu_hellion, UnitId.TuHellion, imgTerran));
            Items.Add(new ImageComboItem("Hellbat", Properties.Resources.trans_tu_hellbat, UnitId.TuHellbat, imgTerran));
            Items.Add(new ImageComboItem("Widow Mine", Properties.Resources.trans_tu_widowmine, UnitId.TuWidowMine, imgTerran));
            Items.Add(new ImageComboItem("Siege Tank", Properties.Resources.trans_tu_siegetank, UnitId.TuSiegetank, imgTerran));
            Items.Add(new ImageComboItem("Thor", Properties.Resources.trans_tu_thor, UnitId.TuThor, imgTerran));
            Items.Add(new ImageComboItem("Viking", Properties.Resources.trans_tu_vikingair, UnitId.TuVikingAir, imgTerran));
            Items.Add(new ImageComboItem("Medivac", Properties.Resources.trans_tu_medivac, UnitId.TuMedivac, imgTerran));
            Items.Add(new ImageComboItem("Banshee", Properties.Resources.trans_tu_banshee, UnitId.TuBanshee, imgTerran));
            Items.Add(new ImageComboItem("Raven", Properties.Resources.trans_tu_raven, UnitId.TuRaven, imgTerran));
            Items.Add(new ImageComboItem("Battlecruiser", Properties.Resources.trans_tu_battlecruiser, UnitId.TuBattlecruiser, imgTerran));

            #endregion

            #region Buildings

            Items.Add(new ImageComboItem("Command Center", Properties.Resources.trans_tb_commandcenter, UnitId.TbCcGround, imgTerran));
            Items.Add(new ImageComboItem("Orbital Command", Properties.Resources.trans_tb_orbitalcommand, UnitId.TbOrbitalGround, imgTerran));
            Items.Add(new ImageComboItem("Planetary Fortress", Properties.Resources.trans_tb_planetaryfortress, UnitId.TbPlanetary, imgTerran));
            Items.Add(new ImageComboItem("Supply Depot", Properties.Resources.trans_tb_supplydepot, UnitId.TbSupplyGround, imgTerran));
            Items.Add(new ImageComboItem("Barracks", Properties.Resources.trans_tb_barracks, UnitId.TbBarracksGround, imgTerran));
            Items.Add(new ImageComboItem("Refinery", Properties.Resources.trans_tb_refinery, UnitId.TbRefinery, imgTerran));
            Items.Add(new ImageComboItem("Bunker", Properties.Resources.trans_tb_bunker, UnitId.TbBunker, imgTerran));
            Items.Add(new ImageComboItem("Engineering Bay", Properties.Resources.trans_tb_engineeringbay, UnitId.TbEbay, imgTerran));
            Items.Add(new ImageComboItem("Missle Turret", Properties.Resources.trans_tb_missileturret, UnitId.TbTurret, imgTerran));
            Items.Add(new ImageComboItem("Sensor Tower", Properties.Resources.trans_tb_sensortower, UnitId.TbSensortower, imgTerran));
            Items.Add(new ImageComboItem("Factory", Properties.Resources.trans_tb_factory, UnitId.TbFactoryGround, imgTerran));
            Items.Add(new ImageComboItem("Starport", Properties.Resources.trans_tb_starport, UnitId.TbStarportGround, imgTerran));
            Items.Add(new ImageComboItem("Ghost Academy", Properties.Resources.trans_tb_ghostacademy, UnitId.TbGhostacademy, imgTerran));
            Items.Add(new ImageComboItem("Fusion Core", Properties.Resources.trans_tb_fusioncore, UnitId.TbFusioncore, imgTerran));
            Items.Add(new ImageComboItem("Armory", Properties.Resources.trans_tb_armory, UnitId.TbArmory, imgTerran));

            #endregion

            #endregion

            #region Protoss

            #region Units

            Items.Add(new ImageComboItem("Probe", Properties.Resources.trans_pu_probe, UnitId.PuProbe, imgProtoss));
            Items.Add(new ImageComboItem("Zealot", Properties.Resources.trans_pu_zealot, UnitId.PuZealot, imgProtoss));
            Items.Add(new ImageComboItem("Stalker", Properties.Resources.trans_pu_stalker, UnitId.PuStalker, imgProtoss));
            Items.Add(new ImageComboItem("Sentry", Properties.Resources.trans_pu_sentry, UnitId.PuSentry, imgProtoss));
            Items.Add(new ImageComboItem("Dark Templar", Properties.Resources.trans_pu_darktemplar, UnitId.PuDarktemplar, imgProtoss));
            Items.Add(new ImageComboItem("High Templar", Properties.Resources.trans_pu_hightemplar, UnitId.PuHightemplar, imgProtoss));
            Items.Add(new ImageComboItem("Immortal", Properties.Resources.trans_pu_immortal, UnitId.PuImmortal, imgProtoss));
            Items.Add(new ImageComboItem("Observer", Properties.Resources.trans_pu_observer, UnitId.PuObserver, imgProtoss));
            Items.Add(new ImageComboItem("Warp Prism", Properties.Resources.trans_pu_warpprism, UnitId.PuWarpprismTransport, imgProtoss));
            Items.Add(new ImageComboItem("Colossus", Properties.Resources.trans_pu_colossus, UnitId.PuColossus, imgProtoss));
            Items.Add(new ImageComboItem("Phoenix", Properties.Resources.trans_pu_phoenix, UnitId.PuPhoenix, imgProtoss));
            Items.Add(new ImageComboItem("Void Ray", Properties.Resources.trans_pu_voidray, UnitId.PuVoidray, imgProtoss));
            Items.Add(new ImageComboItem("oracle", Properties.Resources.trans_pu_oracle, UnitId.PuOracle, imgProtoss));
            Items.Add(new ImageComboItem("Tenpest", Properties.Resources.trans_pu_tempest, UnitId.PuTempest, imgProtoss));
            Items.Add(new ImageComboItem("Carrier", Properties.Resources.trans_pu_carrier, UnitId.PuCarrier, imgProtoss));
            Items.Add(new ImageComboItem("Mothership Core", Properties.Resources.trans_pu_mothershipcore, UnitId.PuMothershipCore, imgProtoss));
            Items.Add(new ImageComboItem("Mothership", Properties.Resources.trans_pu_mothership, UnitId.PuMothership, imgProtoss));

            #endregion 

            #region Buildings

            Items.Add(new ImageComboItem("Nexus", Properties.Resources.trans_pb_nexus, UnitId.PbNexus, imgProtoss));
            Items.Add(new ImageComboItem("Pylon", Properties.Resources.trans_pb_pylon, UnitId.PbPylon, imgProtoss));
            Items.Add(new ImageComboItem("Gateway", Properties.Resources.trans_pb_gateway, UnitId.PbGateway, imgProtoss));
            Items.Add(new ImageComboItem("Warpgate", Properties.Resources.trans_pb_warpgate, UnitId.PupWarpGate, imgProtoss));
            Items.Add(new ImageComboItem("Assimilator", Properties.Resources.trans_pb_assimilator, UnitId.PbAssimilator, imgProtoss));
            Items.Add(new ImageComboItem("Photon Cannon", Properties.Resources.trans_pb_photoncannon, UnitId.PbCannon, imgProtoss));
            Items.Add(new ImageComboItem("Forge", Properties.Resources.trans_pb_forge, UnitId.PbForge, imgProtoss));
            Items.Add(new ImageComboItem("Templar Archive", Properties.Resources.trans_pb_templararchive, UnitId.PbTemplararchives, imgProtoss));
            Items.Add(new ImageComboItem("Dark Shrine", Properties.Resources.trans_pb_darkshrine, UnitId.PbDarkshrine, imgProtoss));
            Items.Add(new ImageComboItem("Twilight Council", Properties.Resources.trans_pb_twilightcouncil, UnitId.PbTwilightcouncil, imgProtoss));
            Items.Add(new ImageComboItem("Stargate", Properties.Resources.trans_pb_stargate, UnitId.PbStargate, imgProtoss));
            Items.Add(new ImageComboItem("Robotics Bay", Properties.Resources.trans_pb_roboticsbay, UnitId.PbRoboticssupportbay, imgProtoss));
            Items.Add(new ImageComboItem("Robotics Facility", Properties.Resources.trans_pb_roboticsfacility, UnitId.PbRoboticsbay, imgProtoss));
            Items.Add(new ImageComboItem("Fleet Beacon", Properties.Resources.trans_pb_fleetbeacon, UnitId.PbFleetbeacon, imgProtoss));

            #endregion

            #endregion

            #region Zerg

            #region Units

            Items.Add(new ImageComboItem("Larva", Properties.Resources.trans_zu_larva, UnitId.ZuLarva, imgZerg));
            Items.Add(new ImageComboItem("Queen", Properties.Resources.trans_zu_queen, UnitId.ZuQueen, imgZerg));
            Items.Add(new ImageComboItem("Drone", Properties.Resources.trans_zu_drone, UnitId.ZuDrone, imgZerg));
            Items.Add(new ImageComboItem("Overlord", Properties.Resources.trans_zu_overlord, UnitId.ZuOverlord, imgZerg));
            Items.Add(new ImageComboItem("Overseer", Properties.Resources.trans_zu_overseer, UnitId.ZuOverseer, imgZerg));
            Items.Add(new ImageComboItem("Zergling", Properties.Resources.trans_zu_zergling, UnitId.ZuZergling, imgZerg));
            Items.Add(new ImageComboItem("Baneling Cocoon", Properties.Resources.trans_zu_banelingcocoon, UnitId.ZuBanelingCocoon, imgZerg));
            Items.Add(new ImageComboItem("Baneling", Properties.Resources.trans_zu_baneling, UnitId.ZuBaneling, imgZerg));
            Items.Add(new ImageComboItem("Roach", Properties.Resources.trans_zu_roach, UnitId.ZuRoach, imgZerg));
            Items.Add(new ImageComboItem("Hydralisk", Properties.Resources.trans_zu_hydralisk, UnitId.ZuHydralisk, imgZerg));
            Items.Add(new ImageComboItem("Mutalisk", Properties.Resources.trans_zu_mutalisk, UnitId.ZuMutalisk, imgZerg));
            Items.Add(new ImageComboItem("Infestor", Properties.Resources.trans_zu_infestor, UnitId.ZuInfestor, imgZerg));
            Items.Add(new ImageComboItem("Infested Terran", Properties.Resources.trans_zu_InfestedTerran, UnitId.ZuInfestedTerran, imgZerg));
            Items.Add(new ImageComboItem("Viper", Properties.Resources.trans_zu_viper, UnitId.ZuViper, imgZerg));
            Items.Add(new ImageComboItem("Corruptor", Properties.Resources.trans_zu_corruptor, UnitId.ZuCorruptor, imgZerg));
            Items.Add(new ImageComboItem("Changeling", Properties.Resources.trans_zu_changeling, UnitId.ZuChangeling, imgZerg));
            Items.Add(new ImageComboItem("Broodlord Cocoon", Properties.Resources.trans_zu_BroodLordCocoon, UnitId.ZuBroodlordCocoon, imgZerg));
            Items.Add(new ImageComboItem("Broodlord", Properties.Resources.trans_zu_broodlord, UnitId.ZuBroodlord, imgZerg));
            Items.Add(new ImageComboItem("Ultralisk", Properties.Resources.trans_zu_ultralisk, UnitId.ZuUltra, imgZerg));

            #endregion

            #region Buildings

            Items.Add(new ImageComboItem("Hatchery", Properties.Resources.trans_zb_hatchery, UnitId.ZbHatchery, imgZerg));
            Items.Add(new ImageComboItem("Lair", Properties.Resources.trans_zb_lair, UnitId.ZbLiar, imgZerg));
            Items.Add(new ImageComboItem("Hive", Properties.Resources.trans_zb_hive, UnitId.ZbHive, imgZerg));
            Items.Add(new ImageComboItem("Spawning Pool", Properties.Resources.trans_zb_spawningpool, UnitId.ZbSpawningPool, imgZerg));
            Items.Add(new ImageComboItem("Baneling Nest", Properties.Resources.trans_zb_banelingnest, UnitId.ZbBanelingNest, imgZerg));
            Items.Add(new ImageComboItem("Evolution Chamber", Properties.Resources.trans_zb_evolutionchamber, UnitId.ZbEvolutionChamber, imgZerg));
            Items.Add(new ImageComboItem("Spine Crawler", Properties.Resources.trans_zb_spinecrawler, UnitId.ZbSpineCrawler, imgZerg));
            Items.Add(new ImageComboItem("Sport Crawler", Properties.Resources.trans_zb_sporecrawler, UnitId.ZbSporeCrawler, imgZerg));
            Items.Add(new ImageComboItem("Roach Warren", Properties.Resources.trans_zb_roachwarren, UnitId.ZbRoachWarren, imgZerg));
            Items.Add(new ImageComboItem("Hydralisk Den", Properties.Resources.trans_zb_hydraliskden, UnitId.ZbHydraDen, imgZerg));
            Items.Add(new ImageComboItem("Infestation Pit", Properties.Resources.trans_zb_infestationpit, UnitId.ZbInfestationPit, imgZerg));
            Items.Add(new ImageComboItem("Spire", Properties.Resources.trans_zb_spire, UnitId.ZbSpire, imgZerg));
            Items.Add(new ImageComboItem("Greater Spire", Properties.Resources.trans_zb_greaterspire, UnitId.ZbGreaterspire, imgZerg));
            Items.Add(new ImageComboItem("Ultralisk Cavern", Properties.Resources.trans_zb_ultraliskcavern, UnitId.ZbUltraCavern, imgZerg));

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
