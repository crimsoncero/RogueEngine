namespace RogueEngine.Commands
{
    public abstract class Command
    {
        public string ComSyntext { get; init; }
        public string ComHelp { get; set; }

        public abstract bool TryExecute(string[] input, Game game);

    }
}