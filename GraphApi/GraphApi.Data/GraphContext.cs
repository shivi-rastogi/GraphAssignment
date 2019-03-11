using GraphApi.Data.Entity;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace GraphApi.Data
{
    public interface IGraphContext 
    {
         DbSet<GraphData> GraphSessions { get;  }
         Task<int> SaveChangesAsync();

    }
    public class GraphContext : DbContext, IGraphContext
    {
        public DbSet<GraphData> GraphSessions { get; set; }
        public GraphContext():base("DefaultConnection")
        {

        }
    }
}
