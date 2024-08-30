using System.Text;
using System.Text.RegularExpressions;

public class Viewer
{
    public static void Show(string text)
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();

        Console.WriteLine(" MODO DE VISUALIZAÇÃO");
        Console.WriteLine("--------------------");
        Replace(text);
        Console.WriteLine("--------------------");
        Console.WriteLine("CONTEÚDO: ");
        Console.WriteLine(text);

        Console.ReadKey();
    }

    public static void Replace(string text)
    {
        var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
        var words = text.Split(' ');

        for(var i = 0; i < words.Length; i++)
        {
            if(strong.IsMatch(words[i]))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(
                    words[i].Substring(
                        words[i].IndexOf('>') + 1,
                        (
                            (words[i].LastIndexOf('<') - 1) - 
                            words[i].IndexOf('>')
                        )
                    )
                );
                Console.Write(" ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(words[i]);
                Console.Write(" ");
            }
        }
    }

    public static void Open()
    {
        Console.Clear();
        Console.WriteLine("Qual caminho do arquivo?");
        string path = Console.ReadLine()!;

        using(var file = new StreamReader(path, Encoding.UTF8))
        {
            string content = file.ReadToEnd();
            Viewer.Show(content);
        }

        Console.WriteLine("");
        Console.ReadLine();

        Menu.Show();
    }
}