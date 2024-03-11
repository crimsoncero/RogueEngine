

namespace RogueEngine.Movements
{
    public class Movement
    {
        private List<Path> _paths;

        public Movement(ICollection<Path> paths)
        {
            _paths = paths.ToList();
        }
    }
}
