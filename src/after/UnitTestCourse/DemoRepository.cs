using Microsoft.Extensions.Logging;

namespace UnitTestCourse
{
    public  class DemoRepository
    {
        readonly ILogger<DemoRepository> _logger;

        public DemoRepository(ILogger<DemoRepository> logger)
        {
            _logger = logger;
        }

        public void GetAll()
        {
            _logger.LogInformation("GetAll methed has been called");
        }
    }
}
