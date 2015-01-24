/**
 * Plugin interface
 * This allows you to transfer data to a plugin and work with it
 * 
 * The plugin can only receive the data as it's a readonly connection
 * It's designed to give as much data as needed to give the plugin
 * developer an easy time develop a plugin
 * 
 * Author: bellaPatricia
 * Date: 29 - July - 2014
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * 
 * Date: 24 - January - 2015
 * - - - - - - - - - - - - -
 * Added Process so you can create a bot or something as plugin with the correct process
 * Without searching for the process on your own.
 * 
 * The handle to SC2 would be obtained using [PROCESS_VARIABLE].MainWindowHandle (IntPtr)
 * 
 * */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using PredefinedTypes = Predefined.PredefinedData;

namespace PluginInterface
{
    public interface IPlugins
    {
        #region Launch/ Stop the plugin

        /// <summary>
        /// Starts the plugin after it was loaded into the host application
        /// </summary>
        void StartPlugin();

        /// <summary>
        /// Stops the plugin after it was loaded into the host application
        /// </summary>
        void StopPlugin();

        #endregion

        #region Getters - Send data to the host application

        /// <summary>
        /// Returns the pluginname to the host application
        /// </summary>
        /// <returns>Pluginname</returns>
        string GetPluginName();

        /// <summary>
        /// Returns a basic plugin description to the host application
        /// </summary>
        /// <returns>A basic description</returns>
        string GetPluginDescription();

        /// <summary>
        /// Returns the pluginversion to the host application
        /// </summary>
        /// <returns>The version of the plugin</returns>
        Version GetPluginVersion();

        /// <summary>
        /// Returns the location of the plugin and sends it to the host application
        /// </summary>
        /// <returns>The file location of the plugin</returns>
        string GetFileLocation();

        /// <summary>
        /// Returns true if the plugin requires the map-data 
        /// It enables the memory gathering for map-data
        /// </summary>
        /// <returns>True if you need the map-data</returns>
        Boolean GetRequiresMap();

        /// <summary>
        /// Returns true if the plugin requires the player-data 
        /// It enables the memory gathering for player-data
        /// </summary>
        /// <returns>True if you need the player-data</returns>
        Boolean GetRequiresPlayer();

        /// <summary>
        /// Returns true if the plugin requires the unit-data 
        /// It enables the memory gathering for unit-data
        /// </summary>
        /// <returns>True if you need the unit-data</returns>
        Boolean GetRequiresUnit();

        /// <summary>
        /// Returns true if the plugin requires the selection-data 
        /// It enables the memory gathering for selection-data
        /// </summary>
        /// <returns>True if you need the selection-data</returns>
        Boolean GetRequiresSelection();

        /// <summary>
        /// Returns true if the plugin requires the group-data 
        /// It enables the memory gathering for group-data
        /// </summary>
        /// <returns>True if you need the group-data</returns>
        Boolean GetRequiresGroups();

        /// <summary>
        /// Returns true if the plugin requires the game-data 
        /// It enables the memory gathering for game-data
        /// </summary>
        /// <returns>True if you need the game-data</returns>
        Boolean GetRequiresGameinfo();

        #endregion  

        #region Setters - Send data to the plugin

        /// <summary>
        /// Supplies the map-data to the plugin to use it
        /// </summary>
        /// <param name="map">The actual map data-structure</param>
        void SetMap(PredefinedTypes.Map map);

        /// <summary>
        /// Supplies the unit-data to the plugin to use it
        /// </summary>
        /// <param name="units">The actual unit data-structure</param>
        void SetUnits(List<PredefinedTypes.Unit> units);

        /// <summary>
        /// Supplies the player-data to the plugin to use it
        /// </summary>
        /// <param name="players">The actual player data-structure</param>
        void SetPlayers(PredefinedTypes.PList players);

        /// <summary>
        /// Supplies the selection-data to the plugin to use it
        /// </summary>
        /// <param name="selection">The actual selection data-structure</param>
        void SetSelection(PredefinedTypes.LSelection selection);

        /// <summary>
        /// Supplies the group-data to the plugin to use it
        /// </summary>
        /// <param name="groups">The actual group data-structure</param>
        void SetGroups(List<PredefinedTypes.Groups> groups);

        /// <summary>
        /// Supplies the game-data to the plugin to use it
        /// </summary>
        /// <param name="gameinfo">The actual game data-structure</param>
        void SetGameinfo(PredefinedTypes.Gameinformation gameinfo);

        /// <summary>
        /// Supplies the process-data to the plugin to use it
        /// </summary>
        /// <param name="sc2Process">The sc2 process</param>
        void SetStarcraftProcess(Process sc2Process);

        #endregion
    }
}
