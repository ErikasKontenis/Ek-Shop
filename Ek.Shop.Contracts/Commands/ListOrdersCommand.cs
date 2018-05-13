using Ek.Shop.Contracts.Abstractions;

namespace Ek.Shop.Contracts.Commands
{
    public class ListOrdersCommand : PagingCommand
    {
        public ListOrdersCommand()
        { }

        public ListOrdersCommand(int? userId, int pageIndex = 0, int pageSize = 0, string search = null, string sorting = null)
            : base(pageIndex, pageSize, search, sorting)
        {
            UserId = userId;
        }

        public string BillingEmail { get; set; }

        public string BillingLastName { get; set; }

        public string BillingName { get; set; }

        public int? Id { get; set; }

        public int? UserId { get; set; }
    }
}
