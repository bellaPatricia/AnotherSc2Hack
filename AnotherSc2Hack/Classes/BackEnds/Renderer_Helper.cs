using System.Collections.Generic;
using System.Drawing;
using PredefinedTypes;

namespace AnotherSc2Hack.Classes.BackEnds
{
    class RendererHelper
    {
        public static void TeamColor(List<Player> pPlayers, int iIndex, bool isTeamcolorEnabled, ref Color clPlayercolor)
        {
            if (!isTeamcolorEnabled)
                return;

            if (Player.LocalPlayer == null)
                return;


            
                if (pPlayers[iIndex].Index == Player.LocalPlayer.Index)
                    clPlayercolor = Color.Green;

                else if (pPlayers[iIndex].Team ==
                         Player.LocalPlayer.Team &&
                         pPlayers[iIndex].Index != Player.LocalPlayer.Index)
                    clPlayercolor = Color.Yellow;

                else if (Player.LocalPlayer.Team !=
                         pPlayers[iIndex].Team)
                    clPlayercolor = Color.Red;

                else
                    clPlayercolor = Color.White;
            

        }

        public static void TeamColor(List<Player> pPlayers, List<Unit> uUnit , int iIndex, bool isTeamcolorEnabled, ref Color clPlayercolor)
        {
            if (!isTeamcolorEnabled)
                return;


            if (Player.LocalPlayer == null)
                return;

                if (pPlayers[uUnit[iIndex].Owner].Index == Player.LocalPlayer.Index)
                    clPlayercolor = Color.FromArgb(255, 0, 187, 0);

                else if (pPlayers[uUnit[iIndex].Owner].Team ==
                         Player.LocalPlayer.Team &&
                         pPlayers[uUnit[iIndex].Owner].Index != Player.LocalPlayer.Index)
                    clPlayercolor = Color.Yellow;

                else if (pPlayers[uUnit[iIndex].Owner].Type.Equals(PlayerType.Neutral))
                    clPlayercolor = Color.White;

                else
                    clPlayercolor = Color.Red;
            
        }

    }
}
