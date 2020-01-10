using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Infrastructure.Interfaces
{
   public interface IPresenter
    {
        void StartWatching(string pathFile);
        void Stop();
    }
}
