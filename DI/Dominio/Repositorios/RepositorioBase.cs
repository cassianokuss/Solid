namespace DI.Dominio.Repositorios
{
    using System;

    public class RepositorioBase<T> : Repositorio<T>
    {
        public void Armazenar(T entidade)
        {
            Console.WriteLine(typeof(T).Name + " armazenada!");
        }
    }
}