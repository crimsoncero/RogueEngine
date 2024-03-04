

namespace RogueEngine.Util
{
    public static class Extensions
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


    }
}
