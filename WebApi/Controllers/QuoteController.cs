using Microsoft.AspNetCore.Mvc;
using Service;
using Domain;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteController : ControllerBase
    {
        private QuoteService quoteService;

        public QuoteController(QuoteService quoteService)
        {
            this.quoteService= quoteService;
        }

        [HttpGet("GetQuote")]
        public List<Quote> GetQuote()
        {
            return quoteService.GetQuote();
        }

        [HttpGet("GetQuoteByCategoryId")]
        public List<Quote> GetQuotesByCategoryId(int Id)
        {
            return quoteService.GetQuoteByCategoryId(Id);
        }

        [HttpPost("InsertQuote")]
        public int InsertQuote(Quote quote)
        {
            return quoteService.InsertQuote(quote);
        }

        [HttpPut("UpdateQuote")]
        public int UpdateQuote(Quote quote, int Id)
        {
            return quoteService.UpdateQuote(quote,Id);
        }

        [HttpDelete("DeleteQuote")]
        public int DeleteQuote(int Id)
        {
            return quoteService.DeleteQuote(Id);
        }
    }
}
