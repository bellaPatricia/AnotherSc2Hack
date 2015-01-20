using System;
using System.Collections.Generic;
using PredefinedTypes = Predefined.PredefinedData;

namespace PluginInterface
{
    public interface IPlugins
    {
        string GetPluginName();
        string GetPluginDescription();
        Version GetPluginVersion();
        string GetFileLocation();
        Boolean GetRequiresMap();
        Boolean GetRequiresPlayer();
        Boolean GetRequiresUnit();
        Boolean GetRequiresSelection();
        Boolean GetRequiresGroups();
        Boolean GetRequiresGameinfo();

        void StartPlugin();

        void StopPlugin();

        void SetMap(PredefinedTypes.Map map);

        void SetUnits(List<PredefinedTypes.Unit> units);

        void SetPlayers(PredefinedTypes.PList players);

        void SetSelection(PredefinedTypes.LSelection selection);

        void SetGroups(List<PredefinedTypes.Groups> groups);

        void SetGameinfo(PredefinedTypes.Gameinformation gameinfo);
    }
}
