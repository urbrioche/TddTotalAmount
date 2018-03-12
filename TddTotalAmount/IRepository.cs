using System.Collections.Generic;

namespace TddTotalAmount
{
    public interface IRepository<T>
    {
        List<T> GetAll();
    }
}