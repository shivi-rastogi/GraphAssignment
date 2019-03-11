using GraphApi.Data;
using System.Web.Http;

namespace GraphApi.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        IGraphRepository _repo;
        public BaseApiController(IGraphRepository repo)
        {
            _repo = repo;
        }
        protected IGraphRepository graphRepository
        {
            get
            {
                return _repo;
            }
        }
    }
}