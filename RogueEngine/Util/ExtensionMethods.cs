

namespace RogueEngine.Util
{
    public static class ExtensionMethods
    {
        public static bool IsValid(this Array arr)
        {
            if(arr == null || arr.Length == 0) 
                return false;
            
            return true;
        }


        public static bool IsInBounds<T>(this T[,] matrix, int x, int y)
        {
            if (x < 0 || x >= matrix.GetLength(0))
                return false;
            
            if(y < 0 || y >= matrix.GetLength(1))
                return false;

            return true;
        }

       

        public static string LowerCaseTrim(this string str)
        {
            string res = str.ToLower();
            string output = "";
            foreach(char c in res)
            {
                if(c != ' ')
                {
                    output += c;
                }
            }
            
            return output;
        }

        public static int ToInt(this bool boolean)
        {
            return boolean ? 1 : 0;
        }

        public static int WordCount(this string str)
        {
            int count = 0;
            count = str.Split(new char[] { ' ', ',', '.', '?' }).Length;

            return count;
        }

        public static Path FindPathTo(this List<Path> paths, IPosition position)
        {
            foreach(Path path in paths)
            {
                for(int i = 0; i < path.Count; i++)
                {
                    if (path[i] == position)
                    {
                        Path newPath = (Path)path.Clone();
                        PathMaker.CutPathAfter(newPath, i);
                        return newPath;
                    }
                }
            }

            return null;
        }

       

    }
}
