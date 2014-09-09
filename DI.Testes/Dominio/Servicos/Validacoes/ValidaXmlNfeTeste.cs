using System;
using DI.Dominio.Entidades;
using DI.Dominio.Servicos.Documentos.Validacoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DI.Testes.Dominio.Servicos.Validacoes
{
    [TestClass]
    public class ValidaXmlNfeTeste
    {
        [TestMethod]
        public void ValidaXmlNfe()
        {
            var doc = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<NFe>
    <Numero>123</Numero>
    <Valor>12345,67</Valor>
</NFe>
";

            ValidadorDeXml valida = new ValidadorDeXmlNfe();
            valida.Validar(doc);
            Assert.IsTrue(valida.AplicarQuando(TipoDocumento.NFe));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidaXmlNfeInvalido()
        {
            var doc = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<NFxxxe>
    <Numero>123</Numero>
    <Valor>12345,67</Valor>
</NFxxxe>
";

            ValidadorDeXml valida = new ValidadorDeXmlNfe();
            valida.Validar(doc);
        }

        [TestMethod]
        public void ValidaXmlNfeEstrutura()
        {
            var doc = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<NFe>
    <Numero>123</Numero>
    <Valor>12345,67</Valor>
</NFe>
";

            var valida = new ValidadorDeXmlNfe();
            valida.ValidarEstruturaDoXml(doc);
            Assert.IsTrue(valida.AplicarQuando(TipoDocumento.NFe));
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidaXmlNfeEstruturaInvalido()
        {
            var doc = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<NFCxxe>
    <Numero>123</Numero>
    <Valor>12345,67</Valor>
</NFCxxe>
";

            var valida = new ValidadorDeXmlNfe();
            valida.ValidarEstruturaDoXml(doc);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidaConteudoXmlNfeEstruturaInvalido()
        {
            var doc = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<NFCxxe>
</NFCxxe>
";

            var valida = new ValidadorDeXmlNfe();
            valida.ValidarConteudoDoXml(doc);
        }
    }
}
