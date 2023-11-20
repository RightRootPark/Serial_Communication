using System;
using System.Collections.Generic;
using System.IO.Ports;  //시리얼통신을 위해 추가해줘야 함
using System.Windows.Forms;

namespace Serial_Communication
{
    public partial class Form1 : Form
    {
        static SerialPort serialPort;
        static List<byte> receivedDataBuffer = new List<byte>();
        static byte[] receivedEX = { 0x2, 0x5, 0x2B, 0x0, 0x8A, 0x20, 0x0, 0x0, 0x0, 0xCE, 0x12, 0xD4, 0x12, 0xD4, 0x12, 0xD4, 0x12, 0xD4, 0x12, 0xD3, 0x12, 0xD4, 0x12, 0xD3, 0x12, 0xD1, 0x12, 0xD3, 0x12, 0xD3, 0x12, 0xD3, 0x12, 0xD3, 0x12, 0xD3, 0x12, 0xD3, 0x12, 0xCB, 0x12, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x42, 0x36, 0x3 };


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)  //폼이 로드되면
        {
            comboBox_port.DataSource = SerialPort.GetPortNames(); //연결 가능한 시리얼포트 이름을 콤보박스에 가져오기 
            comboBox_band.SelectedIndex = 10; //보레이트 기본설정(그냥 연결 눌렀다가 에러나지 않게)
            serialPort = new SerialPort("COM!", 115200, Parity.None, 8, StopBits.One);
        }

        private void Button_connect_Click(object sender, EventArgs e)  //통신 연결하기 버튼
        {
            if (!serialPort.IsOpen)  //시리얼포트가 열려 있지 않으면
            {
                serialPort.PortName = comboBox_port.Text;  //콤보박스의 선택된 COM포트명을 시리얼포트명으로 지정
                serialPort.BaudRate = Convert.ToInt32(comboBox_band.Text);// 9600;  //보레이트 변경이 필요하면 숫자 변경하기
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.Parity = Parity.None;
                //serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived); //이것이 꼭 필요하다
                serialPort.DataReceived += serialPort_DataReceived; //이것이 꼭 필요하다

                serialPort.Open();  //시리얼포트 열기

                label_status.Text = "포트가 열렸습니다.";
                comboBox_port.Enabled = false;  //COM포트설정 콤보박스 비활성화
            }
            else  //시리얼포트가 열려 있으면
            {
                label_status.Text = "포트가 이미 열려 있습니다.";
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)  //수신 이벤트가 발생하면 이 부분이 실행된다.
        {
            this.Invoke(new EventHandler(MySerialReceived));  //메인 쓰레드와 수신 쓰레드의 충돌 방지를 위해 Invoke 사용. MySerialReceived로 이동하여 추가 작업 실행.
        }
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)  //수신 이벤트가 발생하면 이 부분이 실행된다.
        {
            SerialPort sp = (SerialPort)sender;
            int byte2Reed = sp.BytesToRead;
            byte[] bufferr = new byte[byte2Reed];
            sp.Read(bufferr, 0, byte2Reed);
            // 수신된 데이터를 버퍼에 추가
            receivedDataBuffer.AddRange(bufferr);
            // 패킷을 찾아서 처리
            ProcessReceivedData();

        }
        private  void ProcessReceivedData()
        {
            // STX(시작)와 ETX(종료)를 기준으로 패킷을 찾아 처리
            while (receivedDataBuffer.Contains(0x02) && receivedDataBuffer.Contains(0x03))
            {
                int startIndex = receivedDataBuffer.IndexOf(0x02);
                int endIndex = receivedDataBuffer.IndexOf(0x03);

                if (startIndex < endIndex)
                {
                    // 패킷 추출
                    byte[] packet = receivedDataBuffer.GetRange(startIndex, endIndex - startIndex + 1).ToArray();

                    // 패킷 처리
                    ProcessPacket(packet);

                    // 추출한 패킷은 버퍼에서 제거
                    receivedDataBuffer.RemoveRange(startIndex, endIndex - startIndex + 1);
                    if (this.InvokeRequired)//UI쓰레드 충돌 없애기
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            BatteryInfoUpdate();
                        }));
                    }

                }
                else
                {
                    // 시작이 종료보다 뒤에 있는 경우, 이전 데이터는 무시하고 삭제
                    receivedDataBuffer.RemoveRange(0, endIndex + 1);
                }
            }
        }
        private static void ProcessPacket(byte[] packet)
        {
            // 여기서 패킷을 파싱하고 필요한 처리를 수행
            Console.WriteLine($"수신된 패킷: {BitConverter.ToString(packet)}");
            BatteryInfo.ProcessReceivedData(packet);
        }

        private void MySerialReceived(object s, EventArgs e)  //여기에서 수신 데이타를 사용자의 용도에 따라 처리한다.
        {
            int ReceiveData = serialPort.ReadByte();  //시리얼 버터에 수신된 데이타를 ReceiveData 읽어오기
            richTextBox_received.Text = richTextBox_received.Text + string.Format("{0:X2}", ReceiveData);  //int 형식을 string형식으로 변환하여 출력

            if (tabControl1.SelectedIndex == 1)
            {
                int bytesToRead = serialPort.BytesToRead;
                if (bytesToRead >= 48)
                {
                    byte[] buffer = new byte[bytesToRead];
                    serialPort.Read(buffer, 0, bytesToRead);
                    if (buffer[0] == 0x02 && buffer[1] == 0x05)
                    {
                        richTextBox_received.Text = richTextBox_received.Text + string.Format("{0:X2}", ReceiveData);
                        // 데이터 처리
                        // BatteryInfo.ProcessReceivedData(buffer);

                    }

                }


            }

        }

        private void Button_send_Click(object sender, EventArgs e)  //보내기 버튼을 클릭하면
        {
            serialPort.Write(textBox_send.Text);  //텍스트박스의 텍스트를 시리얼통신으로 송신
        }

        private void Button_disconnect_Click(object sender, EventArgs e)  //통신 연결끊기 버튼
        {
            if (serialPort.IsOpen)  //시리얼포트가 열려 있으면
            {
                serialPort.Close();  //시리얼포트 닫기

                label_status.Text = "포트가 닫혔습니다.";
                comboBox_port.Enabled = true;  //COM포트설정 콤보박스 활성화
            }
            else  //시리얼포트가 닫혀 있으면
            {
                label_status.Text = "포트가 이미 닫혀 있습니다.";
            }
        }

        //battery receive test \\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        private void button_BATtest_Click(object sender, EventArgs e)
        {
            BatteryInfo.ProcessReceivedData(receivedEX);
            BatteryInfoUpdate();
        }
        void BatteryInfoUpdate()
        {
            BatteryInfoTxt.Text = "TotalVoltage :" + ((double)BatteryInfo.receivedTotalVoltage / 100).ToString() + "\n";
            BatteryInfoTxt.Text += "Current :" + ((double)BatteryInfo.receivedCurrent / 100).ToString() + "\n";
            BatteryInfoTxt.Text += "SOC :" + BatteryInfo.receivedSOC.ToString() + "\n";
            BatteryInfoTxt.Text += "CV1 :" + ((double)BatteryInfo.receivedCV[0] / 1000).ToString() + "\n";
            BatteryInfoTxt.Text += "CV2 :" + ((double)BatteryInfo.receivedCV[1] / 1000).ToString() + "\n";
            BatteryInfoTxt.Text += "CV3 :" + ((double)BatteryInfo.receivedCV[2] / 1000).ToString() + "\n";
            BatteryInfoTxt.Text += "CV4 :" + ((double)BatteryInfo.receivedCV[3] / 1000).ToString() + "\n";
            BatteryInfoTxt.Text += "CV5 :" + ((double)BatteryInfo.receivedCV[4] / 1000).ToString() + "\n";
            BatteryInfoTxt.Text += "CV6 :" + ((double)BatteryInfo.receivedCV[5] / 1000).ToString() + "\n";
            BatteryInfoTxt.Text += "CV7 :" + ((double)BatteryInfo.receivedCV[6] / 1000).ToString() + "\n";
            BatteryInfoTxt.Text += "CV8 :" + ((double)BatteryInfo.receivedCV[7] / 1000).ToString() + "\n";
            BatteryInfoTxt.Text += "CV9 :" + ((double)BatteryInfo.receivedCV[8] / 1000).ToString() + "\n";
            BatteryInfoTxt.Text += "CV10 :" + ((double)BatteryInfo.receivedCV[9] / 1000).ToString() + "\n";
            BatteryInfoTxt.Text += "CV11 :" + ((double)BatteryInfo.receivedCV[10] / 1000).ToString() + "\n";
            BatteryInfoTxt.Text += "CV12 :" + ((double)BatteryInfo.receivedCV[11] / 1000).ToString() + "\n";
            BatteryInfoTxt.Text += "CV13 :" + ((double)BatteryInfo.receivedCV[12] / 1000).ToString() + "\n";
            BatteryInfoTxt.Text += "CV14 :" + ((double)BatteryInfo.receivedCV[13] / 1000).ToString() + "\n";
            BatteryInfoTxt.Text += "CV15 :" + ((double)BatteryInfo.receivedCV[14] / 1000).ToString() + "\n";
            BatteryInfoTxt.Text += "CV16 :" + ((double)BatteryInfo.receivedCV[15] / 1000).ToString() + "\n";
            BatteryInfoTxt.Text += "BL1 :" + ((double)BatteryInfo.receivedBL[0]).ToString() + "\n";
            BatteryInfoTxt.Text += "BL2 :" + ((double)BatteryInfo.receivedBL[1]).ToString() + "\n";
            BatteryInfoTxt.Text += "BL3 :" + ((double)BatteryInfo.receivedBL[2]).ToString() + "\n";
            //Check Sum? STX ~ data까지 모든 데이터 합산한 1Byte Hex 값을 ASCII로 변환
            //예) 0x02 + 0x05 + 0xF2 + 0x5A = 0x153 -> 0x53 -> '5','3' - > 0x35,0x33 /
            //revers 0x42, 0x36 -> 'B', '6' ->B6 ->0x__B6
            //rerevers F22->
            int calChecksum = 0;
            for (int i = 0; i < 46; i++)
            {
                calChecksum += receivedEX[i];
            }//=3874=F22
             // calChecksum %= 256;
            byte[] checksumBytes = new byte[2];
            checksumBytes[0] = (byte)(calChecksum >> 8);
            checksumBytes[1] = (byte)(calChecksum & 0xFF);

            BatteryInfoTxt.Text += "ReceiveCSum :" + ((double)BatteryInfo.receivedChecksum).ToString() + "\n";//받은거 13890
            BatteryInfoTxt.Text += "CalChechsum :" + calChecksum + "\n";// 계산한거 3874 ->F22
            BatteryInfoTxt.Text += "CalChechsum2 :" + checksumBytes[1];// 계산한거 3874 ->F22
        }
    }
}
