namespace RogueEngine.Commands
{
    public abstract class Command
    {
        /// <summary>
        /// The command keyword, not case sensitive, no spaces allowed.
        /// </summary>
        public string ComSyntext { get; init; }
        public string ComHelp { get; set; }

        public abstract bool TryExecute(string[] input, Tilemap tilemap);

    }
}