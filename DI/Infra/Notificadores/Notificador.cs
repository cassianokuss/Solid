namespace DI.Infra.Notificadores
{
    using Dominio.Servicos;

    public interface Notificador : EstrategiaPorTipoDeDocumento
    {
        void Enviar(string conteudo);
    }
}