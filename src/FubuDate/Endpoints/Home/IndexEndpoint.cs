namespace FubuDate.Endpoints.Home
{
    public class IndexEndpoint
    {
        public HomeIndexViewModel Get(HomeIndexRequest request)
        {
            return new HomeIndexViewModel();
        }
    }
}