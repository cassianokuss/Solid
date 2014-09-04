namespace DI.Infra.Notificaoes
{
    using Dominio.Servicos;

    public interface INotificacao : IEstrategiaTipoDocumento
    {
        void Enviar(string conteudo);
    }
}