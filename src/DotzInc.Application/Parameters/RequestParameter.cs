namespace DotzInc.Application.Parameters
{
    public class RequestParameter
    {
        public int PageNumber { get; set; }
        public int MaxResults { get; set; }
        public RequestParameter()
        {
            this.PageNumber = 1;
            this.MaxResults = 10;
        }
        public RequestParameter(int pageNumber, int maxResults)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.MaxResults = maxResults > 10 ? 10 : maxResults;
        }
    }
}
