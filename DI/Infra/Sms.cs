namespace DI.Infra
{
    using System;
    using Dominio.Entidades;

    public class Sms : INotificacao
    {
        public void Enviar(string conteudo)
        {
            Console.WriteLine("Enviando SMS: " + conteudo);
        }
    }
}