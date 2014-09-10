using System;
using DI.Dominio.Entidades;
using DI.Dominio.Servicos.Documentos.Validadores;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DI.Testes.Dominio.Servicos.Validacoes
{
    [TestClass]
    public class ValidaXmlCteTeste
    {
        [TestMethod]
        public void ValidaXmlCte()
        {
            var doc = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<CTe>
    <Numero>123</Numero>
    <Valor>12345,67</Valor>
</CTe>
";

            ValidadorDeXml valida = new ValidadorDeXmlCte();
            valida.Validar(doc);
            Assert.IsTrue(valida.AplicarQuando(TipoDocumento.CTe));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidaXmlCteDocNulo()
        {
            ValidadorDeXml valida = new ValidadorDeXmlCte();
            valida.Validar(null);
            Assert.IsTrue(valida.AplicarQuando(TipoDocumento.CTe));
        }

        [TestMethod]
        public void ValidaXmlCteEstrutura()
        {
            var doc = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<CTe>
    <Numero>123</Numero>
    <Valor>12345,67</Valor>
</CTe>
";

            var valida = new ValidadorDeXmlCte();
            valida.ValidarEstruturaDoXml(doc);
            Assert.IsTrue(valida.AplicarQuando(TipoDocumento.CTe));
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidaXmlCteEstruturaInvalido()
        {
            var doc = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<NFCxxe>
    <Numero>123</Numero>
    <Valor>12345,67</Valor>
</NFCxxe>
";

            var valida = new ValidadorDeXmlCte();
            valida.ValidarEstruturaDoXml(doc);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidaConteudoXmlCteEstruturaInvalido()
        {
            var doc = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<NFCxxe>
</NFCxxe>
";

            var valida = new ValidadorDeXmlCte();
            valida.ValidarConteudoDoXml(doc);
        }
    }
}
