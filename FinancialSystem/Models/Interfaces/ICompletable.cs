using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialSystem.Models.Interfaces
{
    public interface ICompletable
    {
        ICompletionModel GetCompletion(bool split=false);
    }
}
