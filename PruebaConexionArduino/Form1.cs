using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaConexionArduino
{
    public partial class Form1 : Form
    {
        System.IO.Ports.SerialPort Port;
        bool IsClosed = false;
        int con;
        string pruebaCont;
        //SerialPort puertoSalida = new SerialPort();
        public Form1()
        {
            InitializeComponent();

            //CheckForIllegalCrossThreadCalls = false;
            Port = new System.IO.Ports.SerialPort();
            Port.PortName = "COM6";
            Port.BaudRate = 9600;
            Port.ReadTimeout = 500;
            Port.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            Thread Hilo = new Thread(EscucharSerial);
            Hilo.Start();

        } 



      

        private void EscucharSerial()
        {
            
            while(!IsClosed)
            {
                try
                {
                    string cadena = Port.ReadLine();

                    txtSalida.Invoke(new MethodInvoker(delegate { txtSalida.Text = cadena; }));

                    txtCont.Invoke(new MethodInvoker(delegate { txtCont.Text = Convert.ToString(con); }));

                    if (txtSalida.Text.Trim() == "9")
                    {
                        ledPuntoEnt.BackColor = Color.Green;
                        ledSistInact.BackColor = Color.LightGray;
                        ledAreaInsp.BackColor = Color.LightGray;
                    }
                    else if (txtSalida.Text.Trim() != "9")
                    {
                        ledPuntoEnt.BackColor = Color.LightGray;
                    }

                    if (txtSalida.Text.Trim() == "1")
                    {
                        Sensor1.BackColor = Color.Yellow;
                        ledZonaLlen.BackColor = Color.Yellow;
               


                    }
                    else if (txtSalida.Text.Trim() == "2")
                    {
                        Sensor2.BackColor = Color.Yellow;
                        ledZonaLlen.BackColor = Color.Yellow;

                    }
                    else if (txtSalida.Text.Trim() == "3")
                    {
                        Sensor3.BackColor = Color.Yellow;
                        ledZonaLlen.BackColor = Color.Yellow;
                    }
  

                    if (txtSalida.Text.Trim() == "11")
                    {
                        ledSistInact.BackColor = Color.Red;
                        ledAreaInsp.BackColor = Color.LightGray;
                    }

                    if (txtSalida.Text.Trim() == "12")
                    {
                        ledAreaInsp.BackColor = Color.Green;
                    }

                    if (txtSalida.Text.Trim() == "15")
                    {
                        ledZonaLlen.BackColor = Color.LightGray;
                        ledPuntoEnt.BackColor = Color.LightGray;
                        ledAreaInsp.BackColor = Color.LightGray;
                        ledSistInact.BackColor = Color.LightGray;

                    }
                    if (txtSalida.Text.Trim() == "10")
                    {
                        Sensor1.BackColor = Color.LightGray;
                        Sensor2.BackColor = Color.LightGray;
                        Sensor3.BackColor = Color.LightGray;
                        ledZonaLlen.BackColor = Color.LightGray;
                        ledSistInact.BackColor = Color.LightGray;
                        ledAreaInsp.BackColor = Color.LightGray;
                        con++;
                    }


                    if (txtSalida.Text.Trim() == "1")
                    {
                        Sensor1.BackColor = Color.Yellow;
                        ledZonaLlen.BackColor = Color.Yellow;



                    }
                    else if (txtSalida.Text.Trim() == "2")
                    {
                        Sensor2.BackColor = Color.Yellow;
                        ledZonaLlen.BackColor = Color.Yellow;

                    }
                    else if (txtSalida.Text.Trim() == "3")
                    {
                        Sensor3.BackColor = Color.Yellow;
                        ledZonaLlen.BackColor = Color.Yellow;
                    }

                }
                catch { }


                if (txtSalida.Text.Trim() == "1")
                {
                    Sensor1.BackColor = Color.Yellow;
                    ledZonaLlen.BackColor = Color.Yellow;



                }
                else if (txtSalida.Text.Trim() == "2")
                {
                    Sensor2.BackColor = Color.Yellow;
                    ledZonaLlen.BackColor = Color.Yellow;

                }
                else if (txtSalida.Text.Trim() == "3")
                {
                    Sensor3.BackColor = Color.Yellow;
                    ledZonaLlen.BackColor = Color.Yellow;
                }

            }

        }

        
        private void inicializar()
        {
            //colocar los puertos de salida/escritura y entrada/lectura
            //var puertos = SerialPort.GetPortNames();

          // this.listaPuertoSalida.Items.Clear();  
            //this.listaPuertoSalida.Items.AddRange(puertos);

            //puertoSalida.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

        }
        /*
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            try
            {
                string indata = sp.ReadExisting();
                this.txtEntrada.Text = indata;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"No se puede leer el puerto {sp.PortName}:{ex.Message}");
            }
        }
        */

        private void button1_Click(object sender, EventArgs e)
        {
            //string numeroPuerto = (string)this.listaPuertoSalida.SelectedItem;
            /*
            if (puertoSalida.IsOpen)
            {
                puertoSalida.Close();
            }
            if(puertoSalida.PortName != numeroPuerto)
            {
                puertoSalida.PortName = numeroPuerto;
            }
            try
            {
                puertoSalida.Open();
                puertoSalida.WriteLine(this.txtSalida.Text);
            }
            catch ( Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el puerto {numeroPuerto}:{ex.Message}");
                throw;
            }
            */
        }
        


        
        private void listaPuertoSalida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void btnprender_Click(object sender, EventArgs e)
        {
            SerialPort sp;
            sp = new SerialPort();
            Port.Write("A");
            btnprender.BackColor = Color.DarkGreen;
            btnstop.BackColor = Color.Salmon;
            
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            SerialPort sp;
            sp = new SerialPort();
            Port.Write("R");
            btnstop.BackColor = Color.DarkRed;
            btnprender.BackColor = Color.PaleGreen;
            con = 0;

        }

       

        /*
        private void luz1()
        {
            puertoSalida.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            if (txtEntrada.Text == "1")
            {
                Sensor1.BackColor = Color.Yellow;
            }
            puertoSalida.Close();
        }

        */
        

        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsClosed = true;
            if (Port.IsOpen)
                Port.Close();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSalida_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
