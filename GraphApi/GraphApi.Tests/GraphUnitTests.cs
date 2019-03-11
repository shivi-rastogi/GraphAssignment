using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using GraphApi.Controllers;
using GraphApi.Data;
using GraphApi.Data.Entity;
using GraphApi.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GraphApi.Tests
{
    [TestClass]
    public class GraphUnitTests
    {
        private ExceptionManager _logger= new ExceptionManager();
        
        [TestMethod]
        public async Task TestGetGrapData()
        {
            string sessionid = Guid.NewGuid().ToString();
            var context = new UnitTestContext();
            GraphRepository graphRepository = new GraphRepository(context);
            context.GraphSessions.Add(GetTestGraphData(sessionid));           
            var controller = new GraphController(graphRepository, _logger);
            var result = await controller.Get(sessionid) as OkNegotiatedContentResult<List<GraphData>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(sessionid, result.Content[0].SessionID);
        }
        [TestMethod]
        public async Task TestPostGraphData()
        {

            var context = new UnitTestContext();
            GraphRepository graphRepository = new GraphRepository(context);
            var controller = new GraphController(graphRepository, _logger);
            var controllerContext = Create("Graphfile.txt");
            controller.ControllerContext = controllerContext;

            var result =
                await controller.Post() as CreatedAtRouteNegotiatedContentResult<List<GraphData>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(context.GraphSessions.Local.Count, result.Content.Count);           
        }
     

        public static HttpControllerContext Create(string fileName)
        {

            var request = new HttpRequestMessage(HttpMethod.Post, "");
            var content = new MultipartFormDataContent();
            const int lengthStream = 1900;
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            var contentString = System.IO.File.ReadAllText(filePath);
            ByteArrayContent contentBytes = new ByteArrayContent(Encoding.UTF8.GetBytes(contentString));

            contentBytes.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };
            contentBytes.Headers.Add("Content-Type", "text/plain");
            contentBytes.Headers.Add("Content-Length", lengthStream.ToString());
            content.Add(contentBytes);
            request.Content = content;

            return new HttpControllerContext(new HttpConfiguration(), new HttpRouteData(new HttpRoute("")), request);
        }
        GraphData GetTestGraphData(string sessionid)
        {
            return new GraphData() { SessionID = sessionid, Name = "A", Color = "Yellow",height=10 };
        }
    }
}
