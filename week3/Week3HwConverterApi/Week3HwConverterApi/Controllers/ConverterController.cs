using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Week3HwConverterApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ConverterController : Controller
    {
        private IConverter converter;

        public ConverterController(IConverter converter)
        {
            this.converter = converter;
        }

        // GET: api/values
       
        [HttpGet("{gallons}")]
        public double Get(int gallons)
        {
            return converter.ConvertGallonsToLiter(gallons);
        }

       [HttpPost]
       public ActionResult<IEnumerable<ConversionModel>> Conversion(ConversionModel conversionModel)
        {
            return Ok(converter.ConvertValues(conversionModel));
        }

    }
}

