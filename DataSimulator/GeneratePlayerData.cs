using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PredefinedTypes;
using System.Drawing;

namespace DataSimulator
{
    public class GeneratePlayerData
    {
        public GeneratePlayerData()
        {
            
        }

        public List<Player> Pull()
        {
            var rng = new Random();
            var numberOfPlayers = rng.Next(1, 16);
            var players = new List<Player>(numberOfPlayers);

            for (var i = 0; i < numberOfPlayers; i++)
            {
                var player = new Player();

                player.AccountId = "Bla";
                player.Apm = rng.Next(0, 1000);
                player.ApmAverage = rng.Next(0, 1000);
                player.ArmySupply = rng.Next(4096, 819200);
                player.CameraAngle = 42;
                player.CameraDistance = 42;
                player.CameraPositionX = rng.Next(4096, 4096000);
                player.CameraPositionY = rng.Next(4096, 4096000);
                player.CameraRotation = 42;
                player.ClanTag = "Clantag";
                player.Color = GetGPlayerColorModified(rng.Next(0, 16));
                player.CurrentBuildings = rng.Next(0, 500);
                player.Difficulty = (PlayerDifficulty) rng.Next(1, 11);
                player.Epm = rng.Next(0, 500);
                player.EpmAverage = rng.Next(0, 500);
                player.Gas = rng.Next(0, 99999);
                player.GasArmy = rng.Next(0, 99999);
                player.GasIncome = rng.Next(0, 99999);
                player.Index = i;
                player.Minerals = rng.Next(0, 99999);
                player.MineralsArmy = rng.Next(0, 99999);
                player.MineralsIncome = rng.Next(0, 99999);
                player.Name = $"Name {i}";
                player.NameLength = player.Name.Length;
                player.Status = (PlayerStatus) rng.Next(0, 4);
                player.PlayerRace = PlayerRace.Terran;
                player.SupplyMaxRaw = rng.Next(0, 819200);
                var minRaw = rng.Next(0, 819200);
                if (minRaw > player.SupplyMaxRaw)
                {
                    player.SupplyMinRaw = player.SupplyMaxRaw;
                    player.SupplyMaxRaw = minRaw;
                }

                else
                {
                    player.SupplyMaxRaw = minRaw;
                }

                player.SupplyMax = player.SupplyMaxRaw/4096;
                player.SupplyMin = player.SupplyMinRaw/4096;
                player.Team = rng.Next(0, numberOfPlayers);
                player.Type = (PlayerType) rng.Next(1, 8);
                player.UnitsInProduction = rng.Next(0, 99999);
                player.Worker = rng.Next(0, player.SupplyMax);

                players.Add(player);
            }

            return players;
        }

        /* Translates pure data into types */
        private Color GetGPlayerColorModified(Int32 iValue)
        {
            switch (iValue)
            {
                case (Int32)PlayerColor.Blue:
                    return Color.FromArgb(255, 0, 66, 255);

                case (Int32)PlayerColor.Brown:
                    return Color.FromArgb(255, 78, 42, 4);

                case (Int32)PlayerColor.DarkGray:
                    return Color.FromArgb(255, 35, 35, 35);

                case (Int32)PlayerColor.DarkGreen:
                    return Color.FromArgb(255, 16, 98, 70);

                case (Int32)PlayerColor.Green:
                    return Color.FromArgb(255, 22, 128, 0);

                case (Int32)PlayerColor.LightGray:
                    return Color.FromArgb(255, 82, 84, 148);

                case (Int32)PlayerColor.LightGreen:
                    return Color.FromArgb(255, 150, 255, 145);

                case (Int32)PlayerColor.LightPink:
                    return Color.FromArgb(255, 204, 166, 252);

                case (Int32)PlayerColor.Orange:
                    return Color.FromArgb(255, 254, 138, 14);

                case (Int32)PlayerColor.Pink:
                    return Color.FromArgb(255, 229, 91, 176);

                case (Int32)PlayerColor.Purple:
                    return Color.FromArgb(255, 84, 0, 129);

                case (Int32)PlayerColor.Red:
                    return Color.FromArgb(255, 182, 20, 30);

                case (Int32)PlayerColor.Teal:
                    return Color.FromArgb(255, 28, 167, 234);

                case (Int32)PlayerColor.Violet:
                    return Color.FromArgb(255, 31, 1, 201);

                case (Int32)PlayerColor.White:
                    return Color.White;

                default:
                    return Color.Yellow;
            }
        }
    }
}
