using System;
using System.Collections.Generic;
using System.Drawing;
using PredefinedTypes;
using PredefinedTypes = PredefinedTypes.PredefinedData;


namespace AnotherSc2Hack.Classes.BackEnds
{
    class RendererHelper
    {
        public static void TeamColor(List<PredefinedData.PlayerStruct> pPlayers, Int32 iIndex, Boolean isTeamcolorEnabled, ref Color clPlayercolor)
        {
            if (!isTeamcolorEnabled)
                return;


            if (pPlayers[0].Localplayer < pPlayers.Count)
            {
                if (pPlayers[iIndex].IsLocalplayer)
                    clPlayercolor = Color.Green;

                else if (pPlayers[iIndex].Team ==
                         pPlayers[pPlayers[0].Localplayer].Team &&
                         !pPlayers[iIndex].IsLocalplayer)
                    clPlayercolor = Color.Yellow;

                else if (pPlayers[pPlayers[0].Localplayer].Team !=
                         pPlayers[iIndex].Team)
                    clPlayercolor = Color.Red;

                else
                    clPlayercolor = Color.White;
            }

        }

        public static void TeamColor(List<PredefinedData.PlayerStruct> pPlayers, List<PredefinedData.Unit> uUnit , Int32 iIndex, Boolean isTeamcolorEnabled, ref Color clPlayercolor)
        {
            if (!isTeamcolorEnabled)
                return;


            if (pPlayers[0].Localplayer < pPlayers.Count)
            {
                if (pPlayers[uUnit[iIndex].Owner].IsLocalplayer)
                    clPlayercolor = Color.FromArgb(255, 0, 187, 0);

                else if (pPlayers[uUnit[iIndex].Owner].Team ==
                         pPlayers[pPlayers[0].Localplayer].Team &&
                         !pPlayers[uUnit[iIndex].Owner].IsLocalplayer)
                    clPlayercolor = Color.Yellow;

                else if (pPlayers[uUnit[iIndex].Owner].Type.Equals(PredefinedData.PlayerType.Neutral))
                    clPlayercolor = Color.White;

                else
                    clPlayercolor = Color.Red;
            }
        }

    }
}
