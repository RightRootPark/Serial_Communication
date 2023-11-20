using System;
using System.IO.Ports;  //시리얼통신을 위해 추가해줘야 함
using System.Windows.Forms;

namespace Serial_Communication
{
    public partial class Form1 : Form
    {
        BatteryInfo batteryInfo ;
        static byte[] receivedEX = { 0x2, 0x5, 0x2B, 0x0, 0x8A, 0x20, 0x0, 0x0, 0x0, 0xCE, 0x12, 0xD4, 0x12, 0xD4, 0x12, 0xD4, 0x12, 0xD4, 0x12, 0xD3, 0x12, 0xD4, 0x12, 0xD3, 0x12, 0xD1, 0x12, 0xD3, 0x12, 0xD3, 0x12, 0xD3, 0x12, 0xD3, 0x12, 0xD3, 0x12, 0xD3, 0x12, 0xCB, 0x12, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x42, 0x36, 0x3 };


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)  //폼이 로드되면
        {
            comboBox_port.DataSource = SerialPort.GetPortNames(); //연결 가능한 시리얼포트 이름을 콤보박스에 가져오기 
            comboBox_band.SelectedIndex = 4; //보레이트 기본설정(그냥 연결 눌렀다가 에러나지 않게)
        }

        private void Button_connect_Click(object sender, EventArgs e)  //통신 연결하기 버튼
        {
            if (!serialPort1.IsOpen)  //시리얼포트가 열려 있지 않으면
            {
                serialPort1.PortName = comboBox_port.Text;  //콤보박스의 선택된 COM포트명을 시리얼포트명으로 지정
                serialPort1.BaudRate = Convert.ToInt32(comboBox_band.Text);// 9600;  //보레이트 변경이 필요하면 숫자 변경하기
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived); //이것이 꼭 필요하다

                serialPort1.Open();  //시리얼포트 열기

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

        private void MySerialReceived(object s, EventArgs e)  //여기에서 수신 데이타를 사용자의 용도에 따라 처리한다.
        {
            int ReceiveData = serialPort1.ReadByte();  //시리얼 버터에 수신된 데이타를 ReceiveData 읽어오기
            richTextBox_received.Text = richTextBox_received.Text + string.Format("{0:X2}", ReceiveData);  //int 형식을 string형식으로 변환하여 출력
            if (tabControl1.SelectedIndex == 1)
            {
                int bytesToRead = serialPort1.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                serialPort1.Read(buffer, 0, bytesToRead);
                // 데이터 처리
                BatteryInfo.ProcessReceivedData(buffer);
                //  ProcessReceivedData(buffer);
                BatteryInfoUpdate();
            }

        }

        private void Button_send_Click(object sender, EventArgs e)  //보내기 버튼을 클릭하면
        {
            serialPort1.Write(textBox_send.Text);  //텍스트박스의 텍스트를 시리얼통신으로 송신
        }

        private void Button_disconnect_Click(object sender, EventArgs e)  //통신 연결끊기 버튼
        {
            if (serialPort1.IsOpen)  //시리얼포트가 열려 있으면
            {
                serialPort1.Close();  //시리얼포트 닫기

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
            BatteryInfoTxt.Text ="TotalVoltage :"+ ((double)BatteryInfo.receivedTotalVoltage/100).ToString()+"\n";
            BatteryInfoTxt.Text +="Current :"+ ((double)BatteryInfo.receivedCurrent/100).ToString()+"\n";
            BatteryInfoTxt.Text +="SOC :"+ BatteryInfo.receivedSOC.ToString()+"\n";
            BatteryInfoTxt.Text +="CV1 :"+ ((double)BatteryInfo.receivedCV[0]/100).ToString()+"\n";
            BatteryInfoTxt.Text +="CV2 :"+ ((double)BatteryInfo.receivedCV[1]/100).ToString()+"\n";
            BatteryInfoTxt.Text +="CV3 :"+ ((double)BatteryInfo.receivedCV[2]/100).ToString()+"\n";
            BatteryInfoTxt.Text +="CV4 :"+ ((double)BatteryInfo.receivedCV[3]/100).ToString()+"\n";
            BatteryInfoTxt.Text +="CV5 :"+ ((double)BatteryInfo.receivedCV[4]/100).ToString()+"\n";
            BatteryInfoTxt.Text +="CV6 :"+ ((double)BatteryInfo.receivedCV[5]/100).ToString()+"\n";
            BatteryInfoTxt.Text +="CV7 :"+ ((double)BatteryInfo.receivedCV[6]/100).ToString()+"\n";
            BatteryInfoTxt.Text +="CV8 :"+ ((double)BatteryInfo.receivedCV[7]/100).ToString()+"\n";
            BatteryInfoTxt.Text +="CV9 :"+ ((double)BatteryInfo.receivedCV[8]/100).ToString()+"\n";
            BatteryInfoTxt.Text +="CV10 :"+ ((double)BatteryInfo.receivedCV[9]/100).ToString()+"\n";
            BatteryInfoTxt.Text +="CV11 :"+ ((double)BatteryInfo.receivedCV[10]/100).ToString()+"\n";
            BatteryInfoTxt.Text +="CV12 :"+ ((double)BatteryInfo.receivedCV[11]/100).ToString()+"\n";
            BatteryInfoTxt.Text +="CV13 :"+ ((double)BatteryInfo.receivedCV[12]/100).ToString()+"\n";
            BatteryInfoTxt.Text +="CV14 :"+ ((double)BatteryInfo.receivedCV[13]/100).ToString()+"\n";
            BatteryInfoTxt.Text +="CV15 :"+ ((double)BatteryInfo.receivedCV[14]/100).ToString()+"\n";
            BatteryInfoTxt.Text +="CV16 :"+ ((double)BatteryInfo.receivedCV[15]/100).ToString()+"\n";
            BatteryInfoTxt.Text +="BL1 :"+ ((double)BatteryInfo.receivedBL[0]).ToString()+"\n";
            BatteryInfoTxt.Text +="BL2 :"+ ((double)BatteryInfo.receivedBL[1]).ToString()+"\n";
            BatteryInfoTxt.Text +="BL3 :"+ ((double)BatteryInfo.receivedBL[2]).ToString()+"\n";


        }
    }
}
