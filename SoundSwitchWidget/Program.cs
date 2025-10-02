namespace SoundSwitchWidget
{
    internal static class Program
    {
        public static FormSoundSwitchWidget formSoundSwitchWidget = null;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Program.formSoundSwitchWidget = new FormSoundSwitchWidget();
            Application.Run(Program.formSoundSwitchWidget);
        }
    }
}