namespace Ek.Shop.Contracts.Commands
{
    public class GetSystemSettingCommand : ICommand
    {
        public GetSystemSettingCommand()
        { }

        public GetSystemSettingCommand(string systemSetting)
        {
            SystemSetting = systemSetting;
        }

        public string SystemSetting { get; set; }
    }
}
