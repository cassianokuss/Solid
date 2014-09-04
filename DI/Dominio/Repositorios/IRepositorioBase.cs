namespace DI.Dominio.Repositorios
{
    public interface IRepositorioBase<T>
    {
        void Armazenar(T entidade);
    }
}