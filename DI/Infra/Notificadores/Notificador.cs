namespace DI.Infra.Notificaoes
{
    using Dominio.Servicos;

    public interface Notificador : EstrategiaPorTipoDeDocumento
    {
        void Enviar(string conteudo);
    }
}