namespace RogueEngine
{
    public class Game<T> where T : IRenderer
    {

        public T Renderer { get; set; }

        public static void Foo()
        {
            Console.WriteLine("Hello World");
        }
    }
}