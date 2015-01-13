using System.Drawing;
using System.Windows.Forms;
using PredefinedTypes = Predefined.PredefinedData;

namespace AnotherSc2Hack.Classes.FrontEnds
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
				e.Graphics.DrawString(Text, Font, new SolidBrush(e.ForeColor), e.Bounds.Left + _imgs.ImageSize.Width, e.Bounds.Top);

			else
			{
				
				// check if item is an ImageComboItem
				if (Items[e.Index].GetType() == typeof(ImageComboItem)) 
				{															

					// get item to draw
					var item = (ImageComboItem) Items[e.Index];

					// get forecolor & font
					Color forecolor = (item.ForeColor != Color.FromKnownColor(KnownColor.Transparent)) ? item.ForeColor : e.ForeColor;
					Font font = item.Mark ? new Font(Font, FontStyle.Bold) : Font;

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

				        var fHeightXPoint = ItemHeight - TextRenderer.MeasureText(item.Text, font).Height;
				        fHeightXPoint /= 2;

                        //Text
                        e.Graphics.DrawString(item.Text, font, new SolidBrush(forecolor), e.Bounds.Left + ImageSize.Width,
                            e.Bounds.Top+ fHeightXPoint);
				    }

				    else
				    {
                        // draw text (indented)
                        e.Graphics.DrawString(item.Text, font, new SolidBrush(forecolor), e.Bounds.Left + _imgs.ImageSize.Width,
                            e.Bounds.Top);
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
            #region Terran

            #region Units

            Items.Add(new ImageComboItem("SCV", Properties.Resources.trans_tu_scv, PredefinedTypes.UnitId.TuScv));
            Items.Add(new ImageComboItem("MULE", Properties.Resources.trans_tu_mule, PredefinedTypes.UnitId.TuMule));
            Items.Add(new ImageComboItem("Marine", Properties.Resources.trans_tu_marine, PredefinedTypes.UnitId.TuMarine));
            Items.Add(new ImageComboItem("Marauder", Properties.Resources.trans_tu_marauder, PredefinedTypes.UnitId.TuMarauder));
            Items.Add(new ImageComboItem("Reaper", Properties.Resources.trans_tu_reaper, PredefinedTypes.UnitId.TuReaper));
            Items.Add(new ImageComboItem("Ghost", Properties.Resources.trans_tu_ghost, PredefinedTypes.UnitId.TuGhost));
            Items.Add(new ImageComboItem("Hellion", Properties.Resources.trans_tu_hellion, PredefinedTypes.UnitId.TuHellion));
            Items.Add(new ImageComboItem("Hellbat", Properties.Resources.trans_tu_hellbat, PredefinedTypes.UnitId.TuHellbat));
            Items.Add(new ImageComboItem("Widow Mine", Properties.Resources.trans_tu_widowmine, PredefinedTypes.UnitId.TuWidowMine));
            Items.Add(new ImageComboItem("Siege Tank", Properties.Resources.trans_tu_siegetank, PredefinedTypes.UnitId.TuSiegetank));
            Items.Add(new ImageComboItem("Thor", Properties.Resources.trans_tu_thor, PredefinedTypes.UnitId.TuThor));
            Items.Add(new ImageComboItem("Viking", Properties.Resources.trans_tu_vikingair, PredefinedTypes.UnitId.TuVikingAir));
            Items.Add(new ImageComboItem("Medivac", Properties.Resources.trans_tu_medivac, PredefinedTypes.UnitId.TuMedivac));
            Items.Add(new ImageComboItem("Banshee", Properties.Resources.trans_tu_banshee, PredefinedTypes.UnitId.TuBanshee));
            Items.Add(new ImageComboItem("Raven", Properties.Resources.trans_tu_raven, PredefinedTypes.UnitId.TuRaven));
            Items.Add(new ImageComboItem("Battlecruiser", Properties.Resources.trans_tu_battlecruiser, PredefinedTypes.UnitId.TuBattlecruiser));

            #endregion

            #region Buildings

            Items.Add(new ImageComboItem("Command Center", Properties.Resources.trans_tb_commandcenter, PredefinedTypes.UnitId.TbCcGround));
            Items.Add(new ImageComboItem("Orbital Command", Properties.Resources.trans_tb_orbitalcommand, PredefinedTypes.UnitId.TbOrbitalGround));
            Items.Add(new ImageComboItem("Planetary Fortress", Properties.Resources.trans_tb_planetaryfortress, PredefinedTypes.UnitId.TbPlanetary));
            Items.Add(new ImageComboItem("Supply Depot", Properties.Resources.trans_tb_supplydepot, PredefinedTypes.UnitId.TbSupplyGround));
            Items.Add(new ImageComboItem("Barracks", Properties.Resources.trans_tb_barracks, PredefinedTypes.UnitId.TbBarracksGround));
            Items.Add(new ImageComboItem("Refinery", Properties.Resources.trans_tb_refinery, PredefinedTypes.UnitId.TbRefinery));
            Items.Add(new ImageComboItem("Bunker", Properties.Resources.trans_tb_bunker, PredefinedTypes.UnitId.TbBunker));
            Items.Add(new ImageComboItem("Engineering Bay", Properties.Resources.trans_tb_engineeringbay, PredefinedTypes.UnitId.TbEbay));
            Items.Add(new ImageComboItem("Missle Turret", Properties.Resources.trans_tb_missileturret, PredefinedTypes.UnitId.TbTurret));
            Items.Add(new ImageComboItem("Sensor Tower", Properties.Resources.trans_tb_sensortower, PredefinedTypes.UnitId.TbSensortower));
            Items.Add(new ImageComboItem("Factory", Properties.Resources.trans_tb_factory, PredefinedTypes.UnitId.TbFactoryGround));
            Items.Add(new ImageComboItem("Starport", Properties.Resources.trans_tb_starport, PredefinedTypes.UnitId.TbStarportGround));
            Items.Add(new ImageComboItem("Ghost Academy", Properties.Resources.trans_tb_ghostacademy, PredefinedTypes.UnitId.TbGhostacademy));
            Items.Add(new ImageComboItem("Fusion Core", Properties.Resources.trans_tb_fusioncore, PredefinedTypes.UnitId.TbFusioncore));
            Items.Add(new ImageComboItem("Armory", Properties.Resources.trans_tb_armory, PredefinedTypes.UnitId.TbArmory));

            #endregion

            #endregion

            #region Protoss

            #region Units

            Items.Add(new ImageComboItem("Probe", Properties.Resources.trans_pu_probe, PredefinedTypes.UnitId.PuProbe));
            Items.Add(new ImageComboItem("Zealot", Properties.Resources.trans_pu_zealot, PredefinedTypes.UnitId.PuZealot));
            Items.Add(new ImageComboItem("Stalker", Properties.Resources.trans_pu_stalker, PredefinedTypes.UnitId.PuStalker));
            Items.Add(new ImageComboItem("Sentry", Properties.Resources.trans_pu_sentry, PredefinedTypes.UnitId.PuSentry));
            Items.Add(new ImageComboItem("Dark Templar", Properties.Resources.trans_pu_darktemplar, PredefinedTypes.UnitId.PuDarktemplar));
            Items.Add(new ImageComboItem("High Templar", Properties.Resources.trans_pu_hightemplar, PredefinedTypes.UnitId.PuHightemplar));
            Items.Add(new ImageComboItem("Immortal", Properties.Resources.trans_pu_immortal, PredefinedTypes.UnitId.PuImmortal));
            Items.Add(new ImageComboItem("Observer", Properties.Resources.trans_pu_observer, PredefinedTypes.UnitId.PuObserver));
            Items.Add(new ImageComboItem("Warp Prism", Properties.Resources.trans_pu_warpprism, PredefinedTypes.UnitId.PuWarpprismTransport));
            Items.Add(new ImageComboItem("Colossus", Properties.Resources.trans_pu_colossus, PredefinedTypes.UnitId.PuColossus));
            Items.Add(new ImageComboItem("Phoenix", Properties.Resources.trans_pu_phoenix, PredefinedTypes.UnitId.PuPhoenix));
            Items.Add(new ImageComboItem("Void Ray", Properties.Resources.trans_pu_voidray, PredefinedTypes.UnitId.PuVoidray));
            Items.Add(new ImageComboItem("oracle", Properties.Resources.trans_pu_oracle, PredefinedTypes.UnitId.PuOracle));
            Items.Add(new ImageComboItem("Tenpest", Properties.Resources.trans_pu_tempest, PredefinedTypes.UnitId.PuTempest));
            Items.Add(new ImageComboItem("Carrier", Properties.Resources.trans_pu_carrier, PredefinedTypes.UnitId.PuCarrier));
            Items.Add(new ImageComboItem("Mothership Core", Properties.Resources.trans_pu_mothershipcore, PredefinedTypes.UnitId.PuMothershipCore));
            Items.Add(new ImageComboItem("Mothership", Properties.Resources.trans_pu_mothership, PredefinedTypes.UnitId.PuMothership));

            #endregion 

            #region Buildings

            Items.Add(new ImageComboItem("Nexus", Properties.Resources.trans_pb_nexus, PredefinedTypes.UnitId.PbNexus));
            Items.Add(new ImageComboItem("Pylon", Properties.Resources.trans_pb_pylon, PredefinedTypes.UnitId.PbPylon));
            Items.Add(new ImageComboItem("Gateway", Properties.Resources.trans_pb_gateway, PredefinedTypes.UnitId.PbGateway));
            Items.Add(new ImageComboItem("Warpgate", Properties.Resources.trans_pb_warpgate, PredefinedTypes.UnitId.PupWarpGate));
            Items.Add(new ImageComboItem("Assimilator", Properties.Resources.trans_pb_assimilator, PredefinedTypes.UnitId.PbAssimilator));
            Items.Add(new ImageComboItem("Photon Cannon", Properties.Resources.trans_pb_photoncannon, PredefinedTypes.UnitId.PbCannon));
            Items.Add(new ImageComboItem("Forge", Properties.Resources.trans_pb_forge, PredefinedTypes.UnitId.PbForge));
            Items.Add(new ImageComboItem("Templar Archive", Properties.Resources.trans_pb_templararchive, PredefinedTypes.UnitId.PbTemplararchives));
            Items.Add(new ImageComboItem("Dark Shrine", Properties.Resources.trans_pb_darkshrine, PredefinedTypes.UnitId.PbDarkshrine));
            Items.Add(new ImageComboItem("Twilight Council", Properties.Resources.trans_pb_twilightcouncil, PredefinedTypes.UnitId.PbTwilightcouncil));
            Items.Add(new ImageComboItem("Stargate", Properties.Resources.trans_pb_stargate, PredefinedTypes.UnitId.PbStargate));
            Items.Add(new ImageComboItem("Robotics Bay", Properties.Resources.trans_pb_roboticsbay, PredefinedTypes.UnitId.PbRoboticssupportbay));
            Items.Add(new ImageComboItem("Robotics Facility", Properties.Resources.trans_pb_roboticsfacility, PredefinedTypes.UnitId.PbRoboticsbay));
            Items.Add(new ImageComboItem("Fleet Beacon", Properties.Resources.trans_pb_fleetbeacon, PredefinedTypes.UnitId.PbFleetbeacon));

            #endregion

            #endregion

            #region Zerg

            #region Units

            Items.Add(new ImageComboItem("Larva", Properties.Resources.trans_zu_larva, PredefinedTypes.UnitId.ZuLarva));
            Items.Add(new ImageComboItem("Queen", Properties.Resources.trans_zu_queen, PredefinedTypes.UnitId.ZuQueen));
            Items.Add(new ImageComboItem("Drone", Properties.Resources.trans_zu_drone, PredefinedTypes.UnitId.ZuDrone));
            Items.Add(new ImageComboItem("Zergling", Properties.Resources.trans_zu_zergling, PredefinedTypes.UnitId.ZuZergling));
            Items.Add(new ImageComboItem("Baneling Cocoon", Properties.Resources.trans_zu_banelingcocoon, PredefinedTypes.UnitId.ZuBanelingCocoon));
            Items.Add(new ImageComboItem("Baneling", Properties.Resources.trans_zu_baneling, PredefinedTypes.UnitId.ZuBaneling));
            Items.Add(new ImageComboItem("Roach", Properties.Resources.trans_zu_roach, PredefinedTypes.UnitId.ZuRoach));
            Items.Add(new ImageComboItem("Hydralisk", Properties.Resources.trans_zu_hydralisk, PredefinedTypes.UnitId.ZuHydralisk));
            Items.Add(new ImageComboItem("Mutalisk", Properties.Resources.trans_zu_mutalisk, PredefinedTypes.UnitId.ZuMutalisk));
            Items.Add(new ImageComboItem("Infestor", Properties.Resources.trans_zu_infestor, PredefinedTypes.UnitId.ZuInfestor));
            Items.Add(new ImageComboItem("Infested Terran", Properties.Resources.trans_zu_InfestedTerran, PredefinedTypes.UnitId.ZuInfestedTerran));
            Items.Add(new ImageComboItem("Viper", Properties.Resources.trans_zu_viper, PredefinedTypes.UnitId.ZuViper));
            Items.Add(new ImageComboItem("Corruptor", Properties.Resources.trans_zu_corruptor, PredefinedTypes.UnitId.ZuCorruptor));
            Items.Add(new ImageComboItem("Changeling", Properties.Resources.trans_zu_changeling, PredefinedTypes.UnitId.ZuChangeling));
            Items.Add(new ImageComboItem("Broodlord Cocoon", Properties.Resources.trans_zu_BroodLordCocoon, PredefinedTypes.UnitId.ZuBroodlordCocoon));
            Items.Add(new ImageComboItem("Broodlord", Properties.Resources.trans_zu_broodlord, PredefinedTypes.UnitId.ZuBroodlord));
            Items.Add(new ImageComboItem("Ultralisk", Properties.Resources.trans_zu_ultralisk, PredefinedTypes.UnitId.ZuUltra));

            #endregion

            #region Buildings

            Items.Add(new ImageComboItem("Hatchery", Properties.Resources.trans_zb_hatchery, PredefinedTypes.UnitId.ZbHatchery));
            Items.Add(new ImageComboItem("Lair", Properties.Resources.trans_zb_lair, PredefinedTypes.UnitId.ZbLiar));
            Items.Add(new ImageComboItem("Hive", Properties.Resources.trans_zb_hive, PredefinedTypes.UnitId.ZbHive));
            Items.Add(new ImageComboItem("Spawning Pool", Properties.Resources.trans_zb_spawningpool, PredefinedTypes.UnitId.ZbSpawningPool));
            Items.Add(new ImageComboItem("Baneling Nest", Properties.Resources.trans_zb_banelingnest, PredefinedTypes.UnitId.ZbBanelingNest));
            Items.Add(new ImageComboItem("Evolution Chamber", Properties.Resources.trans_zb_evolutionchamber, PredefinedTypes.UnitId.ZbEvolutionChamber));
            Items.Add(new ImageComboItem("Spine Crawler", Properties.Resources.trans_zb_spinecrawler, PredefinedTypes.UnitId.ZbSpineCrawler));
            Items.Add(new ImageComboItem("Sport Crawler", Properties.Resources.trans_zb_sporecrawler, PredefinedTypes.UnitId.ZbSporeCrawler));
            Items.Add(new ImageComboItem("Roach Warren", Properties.Resources.trans_zb_roachwarren, PredefinedTypes.UnitId.ZbRoachWarren));
            Items.Add(new ImageComboItem("Hydralisk Den", Properties.Resources.trans_zb_hydraliskden, PredefinedTypes.UnitId.ZbHydraDen));
            Items.Add(new ImageComboItem("Infestation Pit", Properties.Resources.trans_zb_infestationpit, PredefinedTypes.UnitId.ZbInfestationPit));
            Items.Add(new ImageComboItem("Spire", Properties.Resources.trans_zb_spire, PredefinedTypes.UnitId.ZbSpire));
            Items.Add(new ImageComboItem("Greater Spire", Properties.Resources.trans_zb_greaterspire, PredefinedTypes.UnitId.ZbGreaterspire));
            Items.Add(new ImageComboItem("Ultralisk Cavern", Properties.Resources.trans_zb_ultraliskcavern, PredefinedTypes.UnitId.ZbUltraCavern));

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

        public ImageComboItem(string text, Image image, PredefinedTypes.UnitId unitId)
        {
            Text = text;
            Image = image;
            UnitId = unitId;
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

        private PredefinedTypes.UnitId _unitId = PredefinedTypes.UnitId.NbXelNagaTower;

        public PredefinedTypes.UnitId UnitId
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
