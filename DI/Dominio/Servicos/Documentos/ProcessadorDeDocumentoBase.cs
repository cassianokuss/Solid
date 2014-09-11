namespace DI.Dominio.Servicos.Documentos
{
    using Entidades;
    using Repositorios;
    using Fabricas;

    public abstract class ProcessadorDeDocumentoBase<T> : ProcessadorDeDocumento
    {
        private readonly TipoDocumento _tipoDeDocumento;

        public Repositorio<T> Repositorio { get; set; }
        public FabricaDeValidadorDeXml ValidaXmlFactory { get; set; }
        public FabricaDeNotificador NotificacaoFactory { get; set; }

        protected ProcessadorDeDocumentoBase(TipoDocumento tipoDeDocumento)
        {
            _tipoDeDocumento = tipoDeDocumento;
        }

        public virtual bool AplicarQuando(TipoDocumento tipo)
        {
            return tipo == _tipoDeDocumento;
        }

        public abstract void Processar(string conteudo);

        protected virtual void Validar(string conteudo)
        {
            ValidaXmlFactory.ObterValidador(_tipoDeDocumento).Validar(conteudo);
        }

        protected virtual void Notificar(string conteudo)
        {
            NotificacaoFactory.ObterNotificador(_tipoDeDocumento).Enviar(conteudo);
        }

        protected virtual void Armazenar(T entidade)
        {
            Repositorio.Armazenar(entidade);
        }
    }
}