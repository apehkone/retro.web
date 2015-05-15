using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Retro.Domain.Entities;
using Retro.Domain.Persistence;
using Retro.Web.Models;

namespace Retro.Web.api
{
    [RoutePrefix("api/retro")]
    public class RetrospectiveController : ApiController
    {
        readonly IDocumentRepository<Retrospective> repository;

        public RetrospectiveController(IDocumentRepository<Retrospective> repository) {
            this.repository = repository;
        }

        // GET api/<controller>
        [Route("")]
        public IEnumerable<RetrospectiveModel> Get() {
            IEnumerable<Retrospective> result = repository.Get();
            return Mapper.Map<IEnumerable<Retrospective>, IEnumerable<RetrospectiveModel>>(result);
        }


        // GET api/<controller>/5
        [Route("{id:guid}")]
        public RetrospectiveModel Get(string id) {
            Retrospective result = repository.Get(r => r.Id == id).FirstOrDefault();
            return Mapper.Map<Retrospective, RetrospectiveModel>(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<object> Post(RetrospectiveModel value) {
            Retrospective retro = RetrospectiveFactory.Create(value.Description, value.SelectedTemplate);
            ResourceResponse<Document> result = await repository.Save(retro);
            return new {id = result.Resource.Id};
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put(string id, RetrospectiveModel value) {}

        // DELETE api/<controller>/5
        public void Delete(string id) {}
    }
}