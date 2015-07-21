using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Retro.Domain.Entities;
using Retro.Domain.Persistence;
using Retro.Web.App_Start;
using Retro.Web.Models;
using Retro.Web.Security;

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
        public IList<RetrospectiveLocation> Get() {
            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var identityUser = manager.FindById(HttpContext.Current.User.Identity.GetUserId());
            return identityUser.Retrospectives;
            //IEnumerable<Retrospective> result = repository.Get();
            //return Mapper.Map<IEnumerable<Retrospective>, IEnumerable<RetrospectiveModel>>(result);
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

            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var identityUser = manager.FindById(HttpContext.Current.User.Identity.GetUserId());

            if (identityUser.Retrospectives == null) {
                identityUser.Retrospectives = new List<RetrospectiveLocation>();
            }

            identityUser.Retrospectives.Add(new RetrospectiveLocation()
                                                   {
                                                       Description = value.Description,
                                                       CreatedOn = DateTime.UtcNow,
                                                       Id = result.Resource.Id
                                                   });
            identityUser.PhoneNumberConfirmed = true;
            await manager.UpdateAsync(identityUser);

            return new {id = result.Resource.Id};
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put(string id, RetrospectiveModel value) {}

        // DELETE api/<controller>/5
        public void Delete(string id) {}
    }
}