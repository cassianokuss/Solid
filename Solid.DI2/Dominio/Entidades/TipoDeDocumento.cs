namespace Solid.DI2.Dominio.Entidades
{
    public class TipoDeDocumento
    {
        public TipoDoc TipoDoc { get; set; }
        public int Versao { get; set; }
    }

    public enum TipoDoc
    {
        NFe,
        NFCe,
        CTe
    }
}