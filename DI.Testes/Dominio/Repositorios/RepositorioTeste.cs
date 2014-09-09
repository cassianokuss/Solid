using System;
using DI.Dominio.Entidades;
using DI.Dominio.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DI.Testes.Dominio.Repositorios
{
    [TestClass]
    public class RepositorioTeste
    {
        [TestMethod]
        public void ArmazenarDocumento()
        {
            Repositorio<DocumentoXml> repositorio = new RepositorioBase<DocumentoXml>();
            repositorio.Armazenar(new DocumentoXml());
            Assert.IsTrue(true);
        }
    }
}
