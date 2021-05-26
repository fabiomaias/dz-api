namespace DotzInc.Application.Responses
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int MaxResults { get; set; }

        public PagedResponse(T data, int pageNumber, int maxResults)
        {
            this.PageNumber = pageNumber;
            this.MaxResults = maxResults;
            this.Data = data;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
        }
    }
}
