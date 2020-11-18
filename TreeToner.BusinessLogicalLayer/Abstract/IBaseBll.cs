using System.Collections.Generic;

namespace TreeToner.BusinessLogicalLayer.Abstract
{
    public interface IBaseBll<T>
    {

        int Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
       
        List<T> GetAll();
    }
}
