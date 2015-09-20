using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AnotherSc2Hack.Classes.BackEnds;
using _ = Utilities.InfoManager.InfoManager;

namespace AnotherSc2Hack.Classes.DataStructures.Game
{
    public class Mind
    {
        private static bool _bMindActive;
        private static int _sleepTime = 100;

        private const int MaximumPlayerCount = 16;
        private Memory _memory;

        private static readonly List<Thread> LWorkers = new List<Thread>();
        private readonly Process _stacraft;

        public Mind(Process starcraft)
        {
            _.Info("Initialized Mind", _.InfoImportance.VeryImportant);

            _stacraft = starcraft;
            _bMindActive = true;

            Initialize();
        }

        public void Initialize()
        {
            
            _memory = new Memory(_stacraft);
            _memory.UnlockedProcess += _memory_UnlockedProcess;
            _memory.DesiredAccess = Memory.VmRead;

            LWorkers.Add(new Thread(PlayerWorker) {Name = "Worker: Player"});

            LWorkers.ForEach(worker => worker.Start(worker));
        }

        private void _memory_UnlockedProcess(object sender, EventArgs e)
        {
            _.Info("Unlocked Process", _.InfoImportance.VeryImportant);
            Offsets.Offsets.MapOffsets(_memory.Process);
        }

        private void PlayerWorker(object sender)
        {
            var currentWorker = sender as Thread;
            if (currentWorker == null)
                return;

            while (_bMindActive)
            {
                Thread.Sleep(_sleepTime);

                var playerChunk = ReadPlayerChunk();

                
            }
        }

        private byte[] ReadPlayerChunk()
        {
            var playerLenght = MaximumPlayerCount*Offsets.Player.Size;
            
            var playerChunk = _memory.ReadMemory(Offsets.Player.Struct, playerLenght);


            return playerChunk;
        }
    }
}
