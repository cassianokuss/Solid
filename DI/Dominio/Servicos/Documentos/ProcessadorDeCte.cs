namespace DI.Dominio.Servicos.Documentos
{
    using Entidades;
    using Repositorios;
    using Fabricas;

    public class ProcessadorDeCte : ProcessadorDeDocumento
    {
        public Repositorio<Cte> Ctes { get; set; }
        public FabricaDeValidadorDeXml ValidaXmlFactory { get; set; }
        public FabricaDeNotificador NotificacaoFactory { get; set; }

        public void Processar(string conteudo)
        {
            Validar(conteudo);
            Armazenar(conteudo);
            Notificar(conteudo);
        }

        public bool AplicarQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.CTe;
        }

        private void Validar(string conteudo)
        {
            ValidaXmlFactory.ObterValidador(TipoDocumento.CTe).Validar(conteudo);
        }

        private void Armazenar(string conteudo)
        {
            var cte = new Cte()
            {
                PropriedadesDoCTe = conteudo
            };

            Ctes.Armazenar(cte);
        }

        private void Notificar(string conteudo)
        {
            NotificacaoFactory.ObterNotificador(TipoDocumento.CTe).Enviar("Cte enviado! " + conteudo);
        }
    }
}