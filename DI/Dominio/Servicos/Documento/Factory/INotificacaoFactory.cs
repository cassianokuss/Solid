namespace DI.Dominio.Servicos.Documento.Factory
{
    using Entidades;

    public interface INotificacaoFactory
    {
        INotificacao ObterNotificacao(TipoDocumento tipo);
    }
}
