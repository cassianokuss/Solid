namespace DI.Infra.Notificaoes
{
    using System;
    using Dominio.Entidades;

    public class Sms : INotificacao
    {
        public void Enviar(string conteudo)
        {
            Console.WriteLine("Enviando SMS: " + conteudo);
        }

        public bool AplicavelQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.CTe;
        }
    }
}