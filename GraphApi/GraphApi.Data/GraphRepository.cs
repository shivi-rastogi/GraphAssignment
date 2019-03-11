using GraphApi.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphApi.Data
{
    public class GraphRepository : IGraphRepository
    {
       
        private IGraphContext _ctx;
        public GraphRepository(IGraphContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> SaveSession(List<GraphData> data)
        {
            try
            {
                foreach (GraphData gd in data)
                    _ctx.GraphSessions.Add(gd);

                await _ctx.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<GraphData> GetSession(string SessionId)
        {
            Random r = new Random();
            
            try
            {
                var data = _ctx.GraphSessions.Where(d => d.SessionID == SessionId).ToList();
                List<GraphData> gdList = new List<GraphData>(data.Count());
                foreach (var q in data)
                {
                    GraphData gd = new GraphData();
                    gd.SessionID = q.SessionID;
                    gd.Color = q.Color;
                    gd.height = r.Next(0, 20);
                    gd.Name = q.Name;
                    gdList.Add(gd);
                }
                return gdList;
                 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
