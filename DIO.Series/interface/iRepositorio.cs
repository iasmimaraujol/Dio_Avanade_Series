using System.Collections.Generic;
namespace DIO.Series{
    public interface iRepositorio<T>{//tipo genérico
        List<T> Lista(); 
        T RetornaPorId(int id);
        void Insere(T entidade);  
        void Exclui(int id);  
        void Atualiza(int id, T entidade);
        int ProximoId();    
    }
}