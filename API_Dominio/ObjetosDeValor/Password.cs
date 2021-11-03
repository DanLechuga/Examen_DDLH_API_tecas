using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Dominio.ObjetosDeValor
{
    public  class Password
    {
        public bool EsValida { get; set; }
        public string Contrasenia { get; set; }
        public static string[] Abecedario { get { return "A,B,C,D,E,F,G,H,I,J,K,L,M,Ñ,N,O,P,Q,R,S,T,V,W,X,Y,Z".Split(','); } }       
        protected Password (string contrasenia)
        {
            try
            {
                if (string.IsNullOrEmpty(contrasenia)) throw new Exception("No se pueden utilizar valores vacios");
                if (contrasenia.Length < 10) throw new Exception("La contraseña debe contener 10 carcateres como minimo");
                bool resultAbecedario = false;
                for (int i = 0; i < Abecedario.Length; i++)
                {
                    if (!contrasenia.Contains(Abecedario[i]))
                        resultAbecedario = true;
                    else {
                        resultAbecedario = false; 
                        break;
                    }
                }
                if (resultAbecedario) throw new Exception("Contraseña sin Mayusculas");
                this.Contrasenia = contrasenia;
                this.EsValida = true;
            }
            catch(Exception ex) 
            {
                this.Contrasenia = "";
                this.EsValida = false;
                throw ex;
            }
            
        }

        public static Password Crear(string password)
        {
            return new Password(password);
        }
    }
}
