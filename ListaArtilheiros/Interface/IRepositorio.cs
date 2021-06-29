using System.Collections.Generic;

namespace ListaArtilheiros.Interface
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T RetornaPorId(int id);
         void Insere(T entidade);
         void Atualiza(int id, T entidade);
         void Exclui(int Id);
         int proximoId();
    }
}