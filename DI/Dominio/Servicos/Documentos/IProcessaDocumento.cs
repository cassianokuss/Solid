﻿namespace DI.Dominio.Servicos.Documento
{
    using Entidades;

    public interface IProcessaDocumento
    {
        void Processar(string conteudo);
        bool ProcessarQuando(TipoDocumento tipo);
    }
}