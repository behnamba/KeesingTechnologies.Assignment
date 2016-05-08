using KeesingTechnologies.Assignment.Data.Base;
using KeesingTechnologies.Assignment.Service;
using KeesingTechnologies.Assignment.Service.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeesingTechnologies.Assignment.Web.Helper
{
    public class Bootstraper
    {
        static IKernel _kernel = new StandardKernel();

        public Bootstraper()
        {

        }

        public static void InitialDependencyMappings()
        {
            _kernel.Bind<IUnitOfWork>().To<Data.EntityFramework.AssignmentDataContext>();
            _kernel.Bind<IDocumentService>().To<DocumentService>();
        }

        public static IDocumentService IDocumentService
        {
            get
            {
                return _kernel.Get<IDocumentService>();
            }
        }
    }
}