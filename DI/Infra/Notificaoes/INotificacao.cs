namespace DI.Infra.Notificaoes
{
    using Dominio.Entidades;

    public interface INotificacao
    {
        void Enviar(string conteudo);
        bool EnviarQuando(TipoDocumento tipo);
    }
}