using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自制网络助手
{
    class JytHttpReturnValue
    {
        public string SerialPortData
        {
            get
            {
                return _SerialPortData;
            }
            set
            {
                _SerialPortData = value;
            }
        }
        public string TcpClientData
        {
            get
            {
                return _TcpClientData;
            }
            set
            {
                _TcpClientData = value;
            }
        }
        public string TcpServerData
        {
            get
            {
                return _TcpServerData;
            }
            set
            {
                _TcpServerData = value;
            }
        }
        public string UdpClientData
        {
            get
            {
                return _UdpClientData;
            }
            set
            {
                _UdpClientData = value;
            }
        }
        public string UdpServerData
        {
            get
            {
                return _UdpServerData;
            }
            set
            {
                _UdpServerData = value;
            }
        }
        private static string _SerialPortData;
        private static string _TcpClientData;
        private static string _TcpServerData;
        private static string _UdpClientData;
        private static string _UdpServerData;
    }
}
