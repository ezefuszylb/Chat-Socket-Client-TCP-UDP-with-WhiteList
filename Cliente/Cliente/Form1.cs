using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Transitions;

namespace Cliente
{    

    public partial class Form1 : Form
    {
        static private NetworkStream stream;
        static private StreamWriter streamw;//variables de lectura y escritura
        static private StreamReader streamr;
        static private TcpClient client = new TcpClient();//nos permite hacer contacto entre clientes y servidor
        static private string nombre = "unknown";//identifico al usuario

        private delegate void DaddItem(String s);

        private void AddItem(String s)
        {
            listBox1.Items.Add(s);
        }
        public Form1()
        {
            InitializeComponent();

        }

        void Listen()
        {
            while(client.Connected)//mientras el cliente este conectado
            {
                try
                {
                    this.Invoke(new DaddItem(AddItem), streamr.ReadLine());//lee el servidor 
                }
                catch//si no esta abierto el servidor
                {
                    MessageBox.Show("No se ha podido conectar al servidor");//pasa esto y se cierra
                    Application.Exit();
                }
            }
        }

        void Conectar()
        {
            try
            {
                client.Connect("127.0.0.1", 8000);//se conecta a esa ip y soket
                if(client.Connected)//si se conecta
                {
                    Thread t = new Thread(Listen);//creo el objeto que escuche

                    stream = client.GetStream();
                    streamw = new StreamWriter(stream);//y el cliente lee y escribe
                    streamr = new StreamReader(stream);


                    streamw.WriteLine(nombre);
                    streamw.Flush();

                    t.Start();
                }
                else
                {//si no se conecta
                    MessageBox.Show("Servidor no Disponible"); //una cajita de mensaje
                }
            }
            catch(Exception ex)
            {//si el servidr no se prendio
                MessageBox.Show("Servidor no Disponible");
                Application.Exit();
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            nombre = txtUsuario.Text;
            Conectar();
            Transition t = new Transition(new TransitionType_EaseInEaseOut(900));
            t.add(lbTitulo1, "Left", 555);
            t.add(txtUsuario, "Left", 555);
            t.add(btnConectar, "Left", 555);
            t.add(listBox1, "Left", 26);
            t.add(txtMensaje, "Left", 26);
            t.add(btnEnviar, "Left", 283);
            t.run();

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            IPEndPoint ipep = (IPEndPoint)client.Client.RemoteEndPoint;
            IPAddress ipa = ipep.Address;
            streamw.WriteLine(" (" + ipa + ") = " + txtMensaje.Text);
            streamw.Flush();
            txtMensaje.Clear();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnEnviar.Location = new Point(-329, 250);
            txtMensaje.Location = new Point(-329, 250);
            listBox1.Location = new Point(-329, 23);
        }
    }
}
