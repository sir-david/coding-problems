using System;

namespace PollyPhrases
{
    class Program
    {
        static void Main(string[] args)
        {

            MatchWordValidator matchWord = new MatchWordValidator();
            Console.WriteLine(String.Join(", ", matchWord.matchWord("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Polly")));
            Console.WriteLine(String.Join(", ", matchWord.matchWord("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "polly")));
            Console.WriteLine(String.Join(", ", matchWord.matchWord("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "ll")));
            Console.WriteLine(String.Join(", ", matchWord.matchWord("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Ll")));
            Console.WriteLine(String.Join(", ", matchWord.matchWord("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "X")));
            Console.WriteLine(String.Join(", ", matchWord.matchWord("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Polx")));
        }
    }
}
