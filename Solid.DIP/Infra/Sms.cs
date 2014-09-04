namespace Solid.DIP.Infra
{
    using System;
    using Dominio.Entidades;

    public class Sms : Notificacao
    {
        public void Enviar(string conteudo)
        {
            Console.WriteLine("Enviando SMS: " + conteudo);
        }
    }
}