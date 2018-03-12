using System.Collections.Generic;

namespace TddTotalAmount
{
    public interface IRespository<T>
    {
        List<T> GetAll();
    }
}