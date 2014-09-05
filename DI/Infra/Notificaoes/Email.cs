﻿namespace DI.Infra.Notificaoes
{
    using System;
    using Dominio.Entidades;

    public class Email : INotificacao
    {
        public void Enviar(string conteudo)
        {
            Console.WriteLine("Enviando email: " + conteudo);
        }

        public bool AplicavelQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.NFe || tipo == TipoDocumento.NFCe;
        }
    }
}