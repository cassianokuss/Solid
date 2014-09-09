namespace DI.Dominio.Servicos.Documentos
{
    using Factorys;
    using Validacoes;
    using Infra.Notificaoes;
    using Entidades;
    using Repositorios;

    public class ProcessadorDeCte : ProcessadorDeDocumento
    {
        private readonly ValidadorDeXml _validacao;
        private readonly Repositorio<Cte> _ctes;
        private readonly Notificador _notificacao;

        public ProcessadorDeCte(Repositorio<Cte> ctes, FabricaDeValidadorDeXml validaXmlFactory, FabricaDeNotificador notificacaoFactory)
        {
            _validacao = validaXmlFactory.ObterValidador(TipoDocumento.CTe);
            _ctes = ctes;
            _notificacao = notificacaoFactory.ObterNotificacao(TipoDocumento.CTe);
        }

        public void Processar(string conteudo)
        {
            _validacao.Validar(conteudo);
            var cte = new Cte()
                {
                    PropriedadesDoCTe = conteudo
                };

            _ctes.Armazenar(cte);
            _notificacao.Enviar("Cte enviado! " + conteudo);
        }

        public bool AplicarQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.CTe;
        }
    }
}