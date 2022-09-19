using Microsoft.AspNetCore.Mvc;
using MM.RequestResponseMiddleware.TestAPI.Models;

namespace MM.RequestResponseMiddleware.TestAPI.Controllers
{
    public class TestController : Controller
    {
        private readonly ILogger<TestController> logger;

        public TestController(ILogger<TestController> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{id}")]
        public IActionResult GetUserID(int id)
        {
            logger.LogInformation("Hello from GetUserID");

            var user = new UserLoginResponseModel()
            {
                Success = true,
                UserEmail = "test@testemail"
            };

            return Ok(user);
        }

        [HttpPost]
        [Route("loginonly")]
        public IActionResult LoginOnly([FromBody] UserLoginRequestModel model)
        {

            logger.LogInformation("Hello from loginonly");

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLoginRequestModel model)
        {

            logger.LogInformation("Hello from login");

            var user = new UserLoginResponseModel()
            {
                Success = true,
                UserEmail = "test@testemail"
            };

            return Ok(user);
        }
    }
}
