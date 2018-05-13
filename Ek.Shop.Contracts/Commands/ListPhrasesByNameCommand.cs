using System.Collections.Generic;
using System.Linq;

namespace Ek.Shop.Contracts.Commands
{
    public class ListPhrasesByNameCommand : ICommand
    {
        public ListPhrasesByNameCommand()
        { }

        public ListPhrasesByNameCommand(IEnumerable<string> names)
            : this(names.ToList())
        { }

        public ListPhrasesByNameCommand(List<string> names)
        {
            Names = names;
        }

        public List<string> Names { get; set; }
    }
}
