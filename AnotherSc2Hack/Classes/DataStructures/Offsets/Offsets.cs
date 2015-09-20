using System;
using System.Collections.Generic;
using System.Diagnostics;
using _ = Utilities.InfoManager.InfoManager;

namespace AnotherSc2Hack.Classes.DataStructures.Offsets
{
    public static class Offsets
    {
        public static Process Starcraft { get; set; }

        private static readonly Dictionary<string, VersionMapping> VersionMappings = new Dictionary<string, VersionMapping>();

        private delegate void VersionMapping(Process startcraft);

        public static void MapOffsets(Process starcraft = null)
        {
            if (Starcraft != null)
                Starcraft = starcraft;

            FillDictionary();
            MapSpecificOffsets();
        }

        private static void FillDictionary()
        {
            VersionMappings.Clear();

            VersionMappings.Add("2.1.12.36657", Version211236657.MapOffsets);
        }

        private static void MapSpecificOffsets()
        {
            try
            {
                var mappingMethod = VersionMappings[Starcraft.MainModule.FileVersionInfo.FileVersion];
                mappingMethod(Starcraft);
            }

            catch (KeyNotFoundException)
            {
                _.Info(
                    $"Key for version {Starcraft.MainModule.FileVersionInfo.FileVersion} not found - Please wait for an update!",
                    _.InfoImportance.VeryImportant);
            }

            catch (Exception ex)
            {
                _.Info($"Something badly happened! {ex}", _.InfoImportance.VeryImportant);
            }
        }
    }
}
