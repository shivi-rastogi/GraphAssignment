using GraphApi.Data;
using GraphApi.Data.Entity;
using System.Data.Entity;
using System.Threading.Tasks;

namespace GraphApi.Tests
{
    public class UnitTestContext:IGraphContext
    {
        public DbSet<GraphData> GraphSessions { get; set; }
        public UnitTestContext()
        {
            GraphSessions = new UnitTestDBSet<GraphData>();
        }

        Task<int> IGraphContext.SaveChangesAsync()
        {
            return Task.FromResult(0);
        }
    }
}
