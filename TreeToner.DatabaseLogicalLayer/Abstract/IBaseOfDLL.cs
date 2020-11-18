using System.Collections.Generic;

namespace TreeToner.DatabaseLogicalLayer
{
    public interface IBaseOfDLL<T>
    {
        bool Add(T Entity);
        bool Update(T Entity);
        bool Delete(T Entity);

        
        List<T> GetAll();

    }

  
}
