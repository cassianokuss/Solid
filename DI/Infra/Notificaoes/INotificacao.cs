namespace DI.Infra.Notificaoes
{
    using Dominio.Servicos;

    public interface INotificacao : EstrategiaPorTipoDeDocumento
    {
        void Enviar(string conteudo);
    }
}