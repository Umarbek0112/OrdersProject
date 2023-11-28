

namespace OrdersProject.Service.Exceptions
{
    public class OrdersProjectException : Exception
    {
        public int Code { get; set; }
        public OrdersProjectException(int code, string message) : base(message)
        {
            this.Code = code;
        }
    }
}
