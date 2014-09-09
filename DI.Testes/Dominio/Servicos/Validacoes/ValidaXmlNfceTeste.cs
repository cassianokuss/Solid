using System;
using DI.Dominio.Entidades;
using DI.Dominio.Servicos.Documentos.Validacoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DI.Testes.Dominio.Servicos.Validacoes
{
    [TestClass]
    public class ValidaXmlNfceTeste
    {
        [TestMethod]
        public void ValidaXmlNfce()
        {
            var doc = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<NFCe>
    <Numero>123</Numero>
    <Valor>12345,67</Valor>
</NFCe>
";

            ValidadorDeXml valida = new ValidadorDeXmlNfce();
            valida.Validar(doc);
            Assert.IsTrue(valida.AplicavelQuando(TipoDocumento.NFCe));
        }

        [TestMethod]
        public void ValidaXmlNfceEstrutura()
        {
            var doc = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<NFCe>
    <Numero>123</Numero>
    <Valor>12345,67</Valor>
</NFCe>
";

            var valida = new ValidadorDeXmlNfce();
            valida.ValidarEstruturaDoXml(doc);
            Assert.IsTrue(valida.AplicavelQuando(TipoDocumento.NFCe));
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidaXmlNfceEstruturaInvalido()
        {
            var doc = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<NFCxxe>
    <Numero>123</Numero>
    <Valor>12345,67</Valor>
</NFCxxe>
";

            var valida = new ValidadorDeXmlNfce();
            valida.ValidarEstruturaDoXml(doc);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidaConteudoXmlNfceEstruturaInvalido()
        {
            var doc = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<NFCxxe>
</NFCxxe>
";

            var valida = new ValidadorDeXmlNfce();
            valida.ValidarConteudoDoXml(doc);
        }
    }
}
