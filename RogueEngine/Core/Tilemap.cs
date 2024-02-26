using System.Collections;

namespace RogueEngine.Core
{
    public abstract class Tilemap : IEnumerable
    {
        //Tile[,] Map;
        // int indexer


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
            throw new NotImplementedException();
        }
    }


}
