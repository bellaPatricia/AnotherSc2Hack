using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataSimulator
{
    public class Sender
    {

        private IPEndPoint _ipEndPoint;
        private Socket _socket;
        private GeneratePlayerData _playerDataSimulator = new GeneratePlayerData();

        public Sender()
        {
            _ipEndPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.Config.IpAddress),
                ConfigurationManager.Config.Port);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        }

        public void SendSimulatedData()
        {
            var players = _playerDataSimulator.Pull();

            foreach (var player in players)
            {
                Console.WriteLine(player);
            }
        }
    }
}
