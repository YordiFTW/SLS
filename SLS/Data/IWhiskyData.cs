using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLS
{
    public interface IWhiskyData
    {
        IEnumerable<Whisky> GetWhiskiesByName(string name);
        Whisky GetById(int id);
        Whisky Update(Whisky updatedWhisky);
        Whisky Add(Whisky newWhisky);
        Whisky Delete(int id);

        Whisky ReverseDelete(int id);

        int GetCountOfWhisky();
        int Commit();
    }
}
