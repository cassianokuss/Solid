namespace DI.Infra.Notificaoes
{
    using Dominio.Servicos;

    public interface Notificacao : EstrategiaPorTipoDeDocumento
    {
        void Enviar(string conteudo);
    }
}