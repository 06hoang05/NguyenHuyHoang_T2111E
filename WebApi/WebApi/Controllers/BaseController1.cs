namespace WebApi.Controllers
{
    public class BaseController<T>
    {
        private DemoDbFirstContext dbContext;
        private ILogger<AuthController> logger;
        private IConfiguration config;

        public BaseController(DemoDbFirstContext dbContext, ILogger<AuthController> logger, IConfiguration config)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.config = config;
        }
    }
}