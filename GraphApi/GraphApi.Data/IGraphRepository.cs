using GraphApi.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApi.Data
{
    public interface IGraphRepository
    {
        Task<bool> SaveSession(List<GraphData> data);
        List<GraphData> GetSession(string SessionId);
    }
}
