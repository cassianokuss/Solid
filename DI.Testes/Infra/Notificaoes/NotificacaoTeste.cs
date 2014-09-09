using DI.Dominio.Entidades;
using DI.Infra.Notificaoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DI.Testes.Infra.Notificaoes
{
    [TestClass]
    public class NotificacaoTeste
    {
        [TestMethod]
        public void NotificarPorEmailNFe()
        {
            Notificacao notificacao = new Email();
            notificacao.Enviar("Teste");
            Assert.IsTrue(notificacao.AplicarQuando(TipoDocumento.NFe));
        }

        [TestMethod]
        public void NotificarPorEmailNFCe()
        {
            Notificacao notificacao = new Email();
            notificacao.Enviar("Teste");
            Assert.IsTrue(notificacao.AplicarQuando(TipoDocumento.NFCe));
        }

        [TestMethod]
        public void NotificarPorSms()
        {
            Notificacao notificacao = new Sms();
            notificacao.Enviar("Teste");
            Assert.IsTrue(notificacao.AplicarQuando(TipoDocumento.CTe));
        }
    }
}
