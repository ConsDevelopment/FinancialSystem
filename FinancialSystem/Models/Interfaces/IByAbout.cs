using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialSystem.Models.Interfaces {
    public interface IForModel {
        long ModelId { get; }
        string ModelType { get; }
        bool Is<T>();
		string ToPrettyString();
    }
    public interface IByAbout {
        IForModel GetBy();
        IForModel GetAbout();
    }
}
