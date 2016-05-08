using KeesingTechnologies.Assignment.Core.Document;
using KeesingTechnologies.Assignment.Service.Interfaces;
using KeesingTechnologies.Assignment.Web.Helper;
using KeesingTechnologies.Assignment.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace KeesingTechnologies.Assignment.Web.Controllers
{
    public class DocumentController : ApiController
    {
        IDocumentService _DocumentService;

        public DocumentController()
        {   
            _DocumentService = Bootstraper.IDocumentService;
        }

        public async Task<List<DocumentViewModel>> Get()
        {
            var model = await _DocumentService.GetAllInclude(p => p.Images);

            var responce = model.Select(p => new DocumentViewModel
            {
                Id = p.Id,
                UserName = p.UserName,
                ScanDate = p.ScanDate,
                ImageCount = p.Images.Count
            }).ToList();

            if (responce == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return responce;
        }

        [OutputCache(Duration = int.MaxValue, VaryByParam = "id")]
        public async Task<DocumentDetailsViewModel> Get(int id)
        {
            var model = await _DocumentService.Find(p => p.Id == id, j => j.Images);

            var responce = model.Select(p => new DocumentDetailsViewModel
            {
                UserName = p.UserName,
                ScanDate = p.ScanDate,
                Images = p.Images.Select(f => new ImageViewModel
                {
                    Url = f.Url,
                    PageNumber = f.PageNumber
                }).OrderBy(q => q.PageNumber)
                .ToList()
            }).SingleOrDefault();

            if (responce == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return responce;
        }

        public bool Post(DocumentDetailsViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                _DocumentService.Add(model.ToDocument());
                _DocumentService.Save();
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.ExpectationFailed);
            }

            //
            return true;
        }
    }
}
