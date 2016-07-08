using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace SyncChatServer
{
    class User
    {
        public TcpClient client { get; private set; }
        private BinaryReader br;
        private BinaryWriter bw;
        public string userName { get; set; }

        public User(TcpClient client)
        {
            this.client = client;
            NetworkStream networkStream = client.GetStream();
            br = new BinaryReader(networkStream);
            bw = new BinaryWriter(networkStream);
        }

      
        public string StartReadFile()
        {
            List<byte> total = new List<byte>();
            byte[] buff = new byte[102400];
            int len;
            try
            {
                bool end = false;
                while (!end && ((len = br.Read(buff, 0, buff.Length)) != 0))
                {
                    if (len < buff.Length)
                    {
                        List<byte> temp = new List<byte>();
                        for (int i = 0; i < len; i++)
                        {
                            temp.Add(buff[i]);
                        }
                        buff = temp.ToArray();
                    }

                    string endTest = Encoding.Default.GetString(buff);
                    if (endTest.EndsWith("END"))
                    {
                        buff = Encoding.Default.GetBytes(endTest.Substring(0, endTest.Length - 3));
                        end = true;
                    }
                    total.AddRange(buff);
                }
            }
            catch
            {

            }
            return Encoding.Default.GetString(total.ToArray());
        }

        public void StartSendFile(string message)
        {
            message += "END";
            byte[] total = Encoding.Default.GetBytes(message);
            bw.Write(total);
            //byte[] buff = new byte[1024];
            //if (total.Length < 1024)
            //{
            //    bw.Write(total);               
            //}
            //else
            //{
            //    int len = 0;
            //    while (total.Length - len > 0)
            //    {
            //        int temp = total.Length - len;
            //        if (temp >= 1024)
            //            temp = 1024;
            //        buff = new byte[temp];
            //        //按实际的字节总量发送信息
            //        for (int i = 0; i < temp; i++)
            //        {
            //            buff[i] = total[len + i];
            //        }
            //        bw.Write(buff);
            //    }
            //}
           // string test = Encoding.Default.GetString(total);
            bw.Flush();
        }

        public void Close()
        {
            br.Close();
            bw.Close();
            client.Close();
        }

    }
}
