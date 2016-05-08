using KeesingTechnologies.Assignment.Common.DDD;
using KeesingTechnologies.Assignment.Common.Exceptions;
using KeesingTechnologies.Assignment.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeesingTechnologies.Assignment.Core.Document
{
    public class Image : EntityBase
    {
        public Image()
        {

        }

        string _Url;
        public string Url
        {
            get
            {
                return _Url;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new RequiredException("Url is requierd");
                }

                if (UrlValidation.IsValid(value) == false)
                {
                    throw new InvalidFormatException("Url format is not valid");
                }

                _Url = value;
            }
        }

        int _PageNumber;
        public int PageNumber
        {
            get
            {
                return _PageNumber;
            }
            set
            {
                // 
                if (value <= 0)
                {
                    throw new InvalidValueException("Negetive value is not allowed for Page Numbers");
                }

                // Page number should be Euniqe 
                _PageNumber = value;
            }
        }

        public Document Document { get; set; }

        protected override void Validate()
        {
        }
    }
}
