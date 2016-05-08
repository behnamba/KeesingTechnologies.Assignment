using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using KeesingTechnologies.Assignment.Web.Helper;
using KeesingTechnologies.Assignment.Core.Document;

namespace KeesingTechnologies.Assignment.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // IOC Initilization
            Bootstraper.InitialDependencyMappings();

            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            GenerateData();           
        }

        // TODO: jsut temprory 
        void GenerateData()
        {
            var context = new Data.EntityFramework.AssignmentDataContext();
            // if db is empty add some test data 
            if (context.Documents.Count() == 0)
            {
                Document d1 = new Document
                {
                    UserName = "perhentian islands",
                    ScanDate = DateTime.Now.AddDays(-7),
                    Images = new List<Image>
                {
                    new Image
                    {
                        PageNumber = 1,
                        Url = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSC_qGDYpdLmG93QMk4b0XCdrKB97B22AevyFJk1unzCue3d-tfgw"
                    },
                    new Image
                    {
                        PageNumber = 2 ,
                        Url = "http://travels.kilroy.net/media/6701098/perhentian-islands-beach.jpg"
                    },
                    new Image
                    {
                        PageNumber = 3 ,
                        Url = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTeKHwW1nJnBEFzpsu5eOHt5PqegelRR-TOcTg5s7njgO-rXw9r"
                    }
                }
                };
                context.Documents.Add(d1);

                Document d2 = new Document
                {
                    UserName = "amsterdam",
                    ScanDate = DateTime.Now,
                    Images = new List<Image>
                {
                    new Image
                    {
                        PageNumber = 1,
                        Url = "http://www.winhotels.com/includes/sliders/homepage-slider-engels_files/images1/enjoyamsterdam.jpg"
                    },
                    new Image
                    {
                        PageNumber = 2 ,
                        Url = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQNUuN3B9X5kYNL3BbsS8fsjKJDoIu0rZNfdt3Z_ZKFXUSfqECi"
                    },
                    new Image
                    {
                        PageNumber = 3 ,
                        Url = "https://media.timeout.com/images/102892843/617/347/image.jpg"
                    }
                }
                };
                context.Documents.Add(d2);
                context.SaveChanges();
            }
        }
    }
}