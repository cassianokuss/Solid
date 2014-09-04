namespace DI.Infra
{
    using System;
    using Dominio.Entidades;

    public class Email : INotificacao
    {
        public void Enviar(string conteudo)
        {
            Console.WriteLine("Enviando email: " + conteudo);
        }
    }
}