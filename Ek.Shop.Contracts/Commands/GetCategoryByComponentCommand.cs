namespace Ek.Shop.Contracts.Commands
{
    public class GetCategoryByComponentCommand : ICommand
    {
        public GetCategoryByComponentCommand()
        { }

        public GetCategoryByComponentCommand(string component, int languageId)
        {
            Component = component;
            LanguageId = languageId;
        }

        public string Component { get; set; }

        public int LanguageId { get; set; }
    }
}
