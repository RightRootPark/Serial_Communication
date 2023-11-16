using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Communication
{
    internal class BatteryInfo
    {

        // 수신된 데이터를 저장할 변수들
        static byte receivedSTX;
        static byte receivedCmd;
        static ushort receivedLength;
        static ushort receivedTotalVoltage;
        static short receivedCurrent;
        static byte receivedSOC;
        static ushort[] receivedCV = new ushort[18];//CellVoltage 1~16
        static ushort[] receivedBL = new ushort[3];//Battery Level 1~3 status
        static byte[] receivedEX = { 0x2, 0x5, 0x2B, 0x0, 0x8A, 0x20, 0x0, 0x0, 0x0, 0xCE, 0x12, 0xD4, 0x12, 0xD4, 0x12, 0xD4, 0x12, 0xD4, 0x12, 0xD3, 0x12, 0xD4, 0x12, 0xD3, 0x12, 0xD1, 0x12, 0xD3, 0x12, 0xD3, 0x12, 0xD3, 0x12, 0xD3, 0x12, 0xD3, 0x12, 0xD3, 0x12, 0xCB, 0x12, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x42, 0x36, 0x3 };
        static ushort receivedChecksum;
        static byte receivedETX;

        private static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // 데이터를 수신할 때 호출되는 이벤트 핸들러
            SerialPort sp = (SerialPort)sender;
            int bytesToRead = sp.BytesToRead;

            byte[] buffer = new byte[bytesToRead];
            sp.Read(buffer, 0, bytesToRead);

            // 데이터 처리
            ProcessReceivedData(buffer);
        }
        public static void ProcessReceivedData(byte[] data)
        {
            byte calchecksum = 0;
            receivedChecksum = BitConverter.ToUInt16(data, 47);
            for (byte i=0;i<47;i++)//cal checksum
            {
                calchecksum += data[i];
            }

            // 데이터를 패킷 구조에 따라 변수에 저장
            receivedSTX = data[0];
            receivedCmd = data[1];
            receivedLength = BitConverter.ToUInt16(data, 2);
            receivedTotalVoltage = BitConverter.ToUInt16(data, 4);
            receivedCurrent = BitConverter.ToInt16(data, 6);
            receivedSOC = data[8];

            // CV 데이터 저장
            int cvIndex = 9;
            for (int i = 0; i < 16; i++)
            {
                receivedCV[i] = BitConverter.ToUInt16(data, cvIndex);
                cvIndex += 2;
            }

            // BL 데이터 저장
            int blIndex = 41;
            for (int i = 0; i < 3; i++)
            {
                receivedBL[i] = BitConverter.ToUInt16(data, blIndex);
                blIndex += 2;
            }

            receivedETX = data[49];

            // 데이터 출력
            Console.WriteLine("수신된 데이터:");
            Console.WriteLine($"STX: {receivedSTX}");
            Console.WriteLine($"CMD: {receivedCmd}");
            Console.WriteLine($"Length: {receivedLength}");
            Console.WriteLine($"Total Voltage: {receivedTotalVoltage}");
            Console.WriteLine($"Current: {receivedCurrent}");
            Console.WriteLine($"SOC: {receivedSOC}");
            Console.WriteLine("CV:");
            for (int i = 0; i < 16; i++)
            {
                Console.Write($"{receivedCV[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine("BL:");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{receivedBL[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Checksum: {receivedChecksum}");
            Console.WriteLine($"ETX: {receivedETX}");        


        }


    }
}
