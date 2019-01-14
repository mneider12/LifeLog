namespace LifeLog.Console
{
    public class BaseMenu : IMenu
    {
        public BaseMenu(string[] prompts, SelectionAction[] actions)
        {
            this.prompts = prompts;
            this.actions = actions;
        }

        public void Run()
        {
            int selection = GetSelection(prompts);
            actions[selection]();
        }

        private static int GetSelection(string[] prompts)
        {
            string input;
            int selection;
            do
            {
                DisplayMenu(prompts);
                input = System.Console.ReadLine();

            } while (!int.TryParse(input, out selection) || selection < 1 || selection > prompts.Length);

            return selection - 1;   // return index to prompts
        }

        private static void DisplayMenu(string[] prompts)
        {
            for (int index = 0; index < prompts.Length; index++)
            {
                System.Console.WriteLine("{0} {1}", index + 1, prompts[index]);
            }
        }

        private string[] prompts;
        private SelectionAction[] actions;

        public delegate void SelectionAction();
    }
}
