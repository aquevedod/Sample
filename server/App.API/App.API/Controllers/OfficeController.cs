using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using App.API.Data;
using App.API.Models;
using App.API.Services;
using App.API.Utilities;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.API.Controllers
{
    [ApiController]
    [Route("offices")]
    public class OfficeController : ControllerBase
    {
        private readonly SampleAppContext context;

        public OfficeController(SampleAppContext context)
        {
            //When testing, populate the context var
            if (context == null)
            {
                //todo
            }
            this.context = context;
        }

        [HttpGet]
        [Route("getOffices")]
        public IEnumerable<Office> GetOffices(string searchPattern)
        {
            //This variable is made for be the request response, not the collection
            //This is for include a message in case of error. Same for UserController
            //With this message error is easier to frontend dev to identify why the service is returning an error.
            Response _response = new Response();
            List<Office> offices = new List<Office>();
            try
            {
                offices = context.Query<Office>($@"select * from Offices where lower(Address) like lower('%{searchPattern}%')").ToList();

                if (offices != null && offices.Count > 0)
                {
                    _response.Code = HttpStatusCode.OK;
                    _response.Entities = offices;
                }
                else
                {
                    _response.Code = HttpStatusCode.NoContent;
                }
            }
            catch (Exception ex)
            {
                //log the error here and/or send to frontend into Response.Message and Response.Code (an error 500 maybe)
            }

            return offices;
        }   
    }
}
