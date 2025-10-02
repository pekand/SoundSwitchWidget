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
            Program.formSoundSwitchWidget.Hide();
            Application.Run(Program.formSoundSwitchWidget);
        }
    }
}