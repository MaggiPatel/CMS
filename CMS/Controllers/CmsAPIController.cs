using CMS.Models;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMS.Controllers
{
    [RoutePrefix("Api/CmsAPI")]
    public class CmsAPIController : ApiController
    {
        [HttpGet]
        [Route("GetAllStandards")]
        public HttpResponseMessage GetStandards()
        {
            try
            {
                using (CMSEntities _db = new CMSEntities())
                {
                    var StandardList = _db.Standards.Where(x => !x.IsDeleted).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, StandardList);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetStandard/{standardId}")]
        public HttpResponseMessage GetStandardById(int standardId)
        {
            try
            {
                using (CMSEntities _db = new CMSEntities())
                {
                    var Standard = _db.Standards.Where(x => !x.IsDeleted && x.ID == standardId).ToList();
                    if (Standard != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, Standard);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddStandard")]
        public HttpResponseMessage AddStandard(StandardDetail standard)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    using (CMSEntities _db = new CMSEntities())
                    {
                        Standard std = new Standard();
                        std.Name = standard.Name;
                        std.DateCreated = DateTime.UtcNow;
                        std.IsDeleted = false;
                        _db.Standards.Add(std);
                        _db.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, std);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
