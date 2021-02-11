using System.Collections.Generic;

namespace Series
{
    public interface IRepositorio<T>
    {
        List<T> Listar();
        T Recuperar(int id);
        void Inserir(T entidade);
        void Excluir(int id);
        void Atualizar(T entidade);
        int ProximoId();
    }
}