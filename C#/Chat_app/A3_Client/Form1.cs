using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;


namespace A3_Client
{
    public partial class Form1 : Form
    {
        static string clientIP { get; set; }

        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] MsgToSend = System.Text.Encoding.ASCII.GetBytes(textBox2.Text + "$");
            serverStream.Write(MsgToSend, 0, MsgToSend.Length);
            serverStream.Flush();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clientIP = textBox4.Text;
            readData = "Conected to the Chat Room";
            msg();
            clientSocket.Connect(clientIP, 8888);
            serverStream = clientSocket.GetStream();

            byte[] user = System.Text.Encoding.ASCII.GetBytes(textBox3.Text + "$");
            serverStream.Write(user, 0, user.Length);
            serverStream.Flush();

            Thread ctThread = new Thread(getMessage);
            ctThread.Start();

            textBox3.Enabled = false;
            textBox4.Enabled = false;
            button1.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            button1.Enabled = true;
        }

        private void getMessage()
        {
            while (true)
            {
                serverStream = clientSocket.GetStream();
                byte[] message = new byte[1024];
                serverStream.Read(message, 0, message.Length);
                string returndata = System.Text.Encoding.ASCII.GetString(message);
                readData = "" + returndata;
                msg();
            }
        }

        private void msg()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else
                textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + readData;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void sendMsg(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox2.Text + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] user = System.Text.Encoding.ASCII.GetBytes(" left the room" + "%");
            serverStream.Write(user, 0, user.Length);
            serverStream.Flush();

        }
    }
}
