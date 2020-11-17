using Microsoft.AspNetCore.Mvc;
using numsortAPI.Interfaces;

namespace numsortAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApiController : ControllerBase
    {
        private ISort _sort;
        private IStorage _storage;

        public ApiController(ISort sort, IStorage storage)
        {
            _sort = sort;
            _storage = storage;
        }

        //call the endpoint with: /api/sortarray?num=7.3&num=1.4&num=5.5
        [Route("sortarray")]
        [HttpGet("/api/sortarray")]
        public ActionResult<double[]> GetSortedArray([FromQuery(Name = "num")] double[] array)
        {
            double[] sortedArray = _sort.SortMyArray(array);

            _storage.SaveMyArray(sortedArray);

            return Ok(sortedArray);
        }

        //call the endpoint with: /api/loadarray?id=0
        [Route("loadarray")]
        [HttpGet("/api/loadarray")]
        public ActionResult<double[]> GetStoredArray([FromQuery(Name = "id")] int id)
        {
            double[] retrievedArray = _storage.LoadStoredArrayById(id);

            return Ok(retrievedArray);
        }
    }
}


