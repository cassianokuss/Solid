namespace DI.Dominio.Servicos.Documentos
{
    using Factorys;
    using Validacoes;
    using Infra.Notificaoes;
    using Entidades;
    using Repositorios;

    public class ProcessadorDeCte : ProcessadorDeDocumento
    {
        private readonly ValidadorDeXml _validador;
        private readonly Repositorio<Cte> _ctes;
        private readonly Notificador _notificador;

        public ProcessadorDeCte(Repositorio<Cte> ctes, FabricaDeValidadorDeXml validaXmlFactory, FabricaDeNotificador notificacaoFactory)
        {
            _validador = validaXmlFactory.ObterValidador(TipoDocumento.CTe);
            _ctes = ctes;
            _notificador = notificacaoFactory.ObterNotificador(TipoDocumento.CTe);
        }

        public void Processar(string conteudo)
        {
            _validador.Validar(conteudo);
            var cte = new Cte()
                {
                    PropriedadesDoCTe = conteudo
                };

            _ctes.Armazenar(cte);
            _notificador.Enviar("Cte enviado! " + conteudo);
        }

        public bool AplicarQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.CTe;
        }
    }
}