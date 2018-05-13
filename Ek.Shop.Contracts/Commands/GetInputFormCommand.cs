namespace Ek.Shop.Contracts.Commands
{
    public class GetInputFormCommand : ICommand
    {
        public GetInputFormCommand()
        { }

        public GetInputFormCommand(string inputFormName)
        {
            InputFormName = inputFormName;
        }

        public string InputFormName { get; set; }
    }
}
