using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShoreApiMsTest.Mocks.Contracts
{
    public interface IEntityBuilder<T>
    {
        public T Reset();
        public T Build();
    }
}
