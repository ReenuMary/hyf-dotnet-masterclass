using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Week3HwConverterApi.Controllers
{
    [Route("api/[controller]")]
    public class MilesToKmConverterController : Controller
    {
        private IMilesConverter milesConverter;
        public MilesToKmConverterController(IMilesConverter milesConverter)
        {
            this.milesConverter = milesConverter;
        }

        // GET api/values/5
        [HttpGet("{miles}")]
        public IDistance Get(int miles)
        {
            return milesConverter.ConvertMilesToKm(miles);
        }

    }
}

