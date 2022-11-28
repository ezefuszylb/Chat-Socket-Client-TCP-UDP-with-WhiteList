using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace Servidor
{/// <summary>
/// como crear un servidor al que se pueden conectar
/// </summary>
    class Servidor_Chat
    {
        /// <summary>
        /// crea el server, que espera la conxion del cliente, y cliente
        /// </summary>
        private TcpListener server;
        private TcpClient client = new TcpClient();
        /// <summary>
        /// establece el ip y el puerto
        /// </summary>
        private IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, 8000);
        /// <summary>
        /// pa que se haga la conexion y que se vea la info
        /// </summary>
        private List<conexion> list = new List<conexion>();

        conexion con; //creo con la conexion con la estructura de abajo

        private struct conexion
        {
            /// <summary>
            /// creo la estructura de mi conexion que despues uso
            /// </summary>
            public NetworkStream stream;
            public StreamWriter streamw;
            public StreamReader streamr;
            public string nombre;
        }

        public bool validarWhiteList(string ip, string whitelist)
        {
            string line = string.Empty;
            StreamReader streamrw = new StreamReader(whitelist);

            while(line != null)
            {
                line = streamrw.ReadLine();
                if(ip == line)
                {
                    return true;
                }
            }
            return false;
        }


        public Servidor_Chat()
        {
            Inicio();//el svr se incia haciendo lo de abajo
        }
        public void Inicio()
        {
            Console.WriteLine("Servidor Activado!");
            
            server = new TcpListener(ipendpoint);//que escuche con la ip y puerto que establecimos antes
            server.Start();


            while(true)
            {
                client = server.AcceptTcpClient();//el servidor acepta al cliente que creamos antes
                IPEndPoint ipep = (IPEndPoint)client.Client.RemoteEndPoint;
                IPAddress ipa = ipep.Address;                
                if(validarWhiteList(ipa.ToString(), "C:/Users/Eze/Desktop/Chat/Servidor/Servidor/bin/Debug/whitelist.txt"))
                {
                    con = new conexion();//se crea la conexion
                    con.stream = client.GetStream();//el cliente hace la conexion con el servidor
                    con.streamr = new StreamReader(con.stream);//el server lee 
                    con.streamw = new StreamWriter(con.stream);// y escribe
                    con.nombre = con.streamr.ReadLine();//el otro lee y capta lo que enviaron

                    list.Add(con);//y agrega al listado de la conexion que hicimos antes

                    Console.WriteLine(con.nombre + " se a Conectado.");
                    Console.WriteLine(ipa + " se a Conectado.");

                    Thread escuchaCon = new Thread(Escuchar_conexion);
                    escuchaCon.Start();//empieza a escuchar la conexion
                }
                else
                {
                    Console.WriteLine("El cliente no esta dentro de la whitelist");
                }
                
            }
        }
        void Escuchar_conexion()
        {

            conexion hcon = con;//una variable con la estructura conexion

            do
            {
                try
                {
                    string mensaje = hcon.streamr.ReadLine();//se verifica si se hizo la conexion, y se lee el mensaje que se envia
                    Console.WriteLine(hcon.nombre + "" + mensaje);
                    foreach (conexion c in list)
                    {
                        try
                        {
                            c.streamw.WriteLine(hcon.nombre + "" + mensaje);//se escribe el mensaje que se envia
                            c.streamw.Flush();
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                    list.Remove(hcon);//si se cierra el usuario se borrra los mensajes
                    Console.WriteLine(con.nombre + " se a Desconectado.");
                    break;
                }
            } while (true);
        }
    }
}



