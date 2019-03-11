using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using GraphApi.Data;
using GraphApi.Data.Entity;
using GraphApi.Logger;

namespace GraphApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class GraphController : BaseApiController
    {
        private IExceptionManager _logger;
        public GraphController(IGraphRepository repo, IExceptionManager logger) : base(repo)
        {
            _logger = logger;
        }

        // GET: Graph
        [ResponseType(typeof(List<GraphData>))]
        public async Task<IHttpActionResult> Get(string SessionId)
        {
            try
            {
                return Ok(await Task.FromResult(graphRepository.GetSession(SessionId)));
            }
            catch(Exception ex)
            {
                _logger.Log(ex.Message);
                return InternalServerError(ex);
            }
        }

        // POST: Graph
        public async Task<IHttpActionResult> Post()
        {             
            List<GraphData> resp = new List<GraphData>();
            string fileContent = string.Empty;
            string SessionId = Guid.NewGuid().ToString();
            try
            {
                if (Request.Content.IsMimeMultipartContent())
                {                   
                    var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                    HttpContent file = filesReadToProvider.Contents.Count > 0 ? filesReadToProvider.Contents[0] : null;
                    var fileBytes = await file.ReadAsByteArrayAsync();
                    fileContent = System.Text.Encoding.UTF8.GetString(fileBytes);

                    foreach (string row in fileContent.Split(new char[] { '#' }, System.StringSplitOptions.RemoveEmptyEntries))
                    {
                        string[] values = row.Split(':');
                        resp.Add(new GraphData
                        {
                            SessionID = SessionId,
                            Name = values[0],
                            Color = values[1],
                            height = int.Parse(values[2])
                        });
                    }

                    bool isSuccess = await graphRepository.SaveSession(resp);

                    if (isSuccess)
                        return CreatedAtRoute("DefaultApi", new { id = SessionId }, resp);
                    else
                        return InternalServerError(new Exception("Some error occured while saving data"));
                }
                else
                {
                    return InternalServerError();
                }

                
            }            
            catch (Exception ex)
            {
                _logger.Log(ex.Message);
                return InternalServerError(ex);
            }
        }

       

    }
}