using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectorService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollectorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private IStorageService storageService;
        public DataController(IStorageService storageService)
        {
            this.storageService = storageService;
        }

        // GET: api/data
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return storageService.getItems();
        }
    }
}