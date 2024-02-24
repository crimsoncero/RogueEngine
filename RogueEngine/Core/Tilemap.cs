using System.Collections;

namespace RogueEngine.Core
{
    public  class Tilemap : IEnumerable
    {
        //Tile[,] Map;
        // int indexer
        public Tilemap() { }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class TilemapEnum : IEnumerator
    {
        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }
    }


}
