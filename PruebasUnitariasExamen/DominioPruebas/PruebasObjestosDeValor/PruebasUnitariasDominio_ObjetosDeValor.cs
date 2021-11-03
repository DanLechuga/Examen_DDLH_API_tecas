using API_Dominio.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasUnitariasExamen.DominioPruebas
{
   
    public class PruebasUnitariasDominio_ObjetosDeValor
    {
        [Fact]
        public void CrearPasswordSinCaracteres_Exception()
        {
            Assert.Throws<Exception>(() => {
                Password password = Password.Crear(string.Empty);
            });
            
        }
        [Fact]
        public void CrearPasswordCon9Caracteres_Exception()
        {
            Assert.Throws<Exception>(() => {
                string NueveCaracteres = "apsoedifb";
                Password password = Password.Crear(NueveCaracteres);
            
            });
        }
        [Fact]
        public void CrearPaswordSinMayuscula_Excepction()
        {
            Assert.Throws<Exception>(() => {
                string contraseniaSinMayuscula = "dskajhjhgd";
                Password password = Password.Crear(contraseniaSinMayuscula);
            });

        }
        [Fact]
        public void CrearPasswordCon10CaracteresYUnaMayuscula_Password()
        {
            string ContraseniaCorrecta = "Pydbabahsdñ";
            Assert.NotNull(Password.Crear(ContraseniaCorrecta));
        }                                                  
        

    }
}
