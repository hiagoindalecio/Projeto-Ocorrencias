using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleOcorrencia.classes
{
    class clsDados
    {
        public static string IpCnx;
        public static string PortCnx;
        public static string NameDb;
        public static string LoginCnx;
        public static string SenhaCnx;
        public static string diretorio;

        public static string BuscarDados()
        {
            string ds_msg = "";
            try
            {
                string text = System.IO.File.ReadAllText(@diretorio); //PEGA DADOS DO CONEXAO.TXT -> ip:;database_name:;port:;login:;password:
                var array = text.Split(';', ':');
                int count = 0;
                while (count < array.Length)
                {
                    if(Equals(array[count], "ip"))
                        IpCnx = array[count+1];
                    else if (Equals(array[count], "database_name"))
                        NameDb = array[count+1];
                    else if (Equals(array[count], "port"))
                        PortCnx = array[count+1];
                    else if (Equals(array[count], "login"))
                        LoginCnx = array[count+1];
                    else if (Equals(array[count], "password"))
                        SenhaCnx = array[count+1];
                    count++;
                }
                if(!Equals(IpCnx, "") && !Equals(NameDb, "") && !Equals(PortCnx, "") &&!Equals(LoginCnx, "") && !Equals(SenhaCnx, ""))
                {
                    ds_msg = "Dados encontrados!";
                }
                else
                {
                    ds_msg = "Os dados de conexão não foram encontrados!";
                }
            }
            catch
            {
                ds_msg = "Os dados de conexão não foram encontrados!";
            }
            return ds_msg;
        }

        public static string PegarDiretorioAtual()
        {
            string diretorio = Environment.CurrentDirectory;
            return diretorio;
        }

        public static void PegarDiretorioInterno()
        {
            diretorio = "CAMINHO INTERNO";
        }

        public static void PegarDiretorioExterno()
        {
            diretorio = "CAMINHO EXTERNO";
        }
    }
}
