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

            return model.Select(p => new DocumentViewModel
            {
                Id = p.Id,
                UserName = p.UserName,
                ScanDate = p.ScanDate,
                ImageNumbers = p.Images.Count
            }).ToList();
        }

        [OutputCache(Duration = int.MaxValue, VaryByParam = "id")]
        public async Task<DocumentDetailsViewModel> Get(int id)
        {
            var model = await _DocumentService.Find(p => p.Id == id, j => j.Images);

            return model.Select(p => new DocumentDetailsViewModel
            {
                UserName = p.UserName,
                ScanDate = p.ScanDate,
                Urls = p.Images.OrderBy(q => q.PageNumber).Select(f => f.Url).ToList()
            }).Single();
        }
    }
}
