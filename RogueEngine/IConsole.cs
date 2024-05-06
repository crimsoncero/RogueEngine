
namespace RogueEngine
{
    public interface IConsole
    {
        void WriteError(string errorText);
        void WriteTurn(string turnText);
        void WriteHelp(string helpText);
        void Clear();


    }
}
