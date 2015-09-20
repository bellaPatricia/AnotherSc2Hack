using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnotherSc2Hack.Classes.DataStructures.Game
{
    public static class Mind
    {
        private static bool _bMindActive;
        private static int _sleepTime = 100;

        private static readonly List<Thread> LWorkers = new List<Thread>(); 

        public static void Initialize()
        {
            LWorkers.Add(new Thread(PlayerWorker) {Name = "Worker: Player"});

            LWorkers.ForEach(worker => worker.Start(worker));
        }

        private static void PlayerWorker(object sender)
        {
            var currentWorker = sender as Thread;
            if (currentWorker == null)
                return;

            while (_bMindActive)
            {
                Thread.Sleep(_sleepTime);
            }
        }
    }
}
