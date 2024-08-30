using System.Text;
using Microsoft.VisualBasic;

public static class Editor
{
    public static void Show()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("MODO EDITOR");
        Console.WriteLine("-----------");
        Start();
    }

    public static void Start()
    {
        var file = new StringBuilder();

        do
        {
            file.Append(Console.ReadLine());
            file.Append(Environment.NewLine);
        }while(Console.ReadKey().Key != ConsoleKey.Escape);

        Console.WriteLine("-----------");
        Viewer.Show(file.ToString());
        Console.WriteLine(" Deseja salvar o arquivo? [S / N]");

        var save = char.Parse(Console.ReadLine()!.ToLower());

        if(save == 's')
        {
            Save(file);
        }
        else
        {
            Console.WriteLine("Arquivo não foi salvo!");
            Console.ReadKey();
            Menu.Show();
        }   

    }

    public static void Save(StringBuilder file)
    {
        Console.Clear();
        Console.WriteLine("Qual caminho que você deseja salvar o arquivo?");

        var path = Console.ReadLine()!;

        using (StreamWriter saveFile = new StreamWriter(path))
        {
            saveFile.Write(file);
        }

        Console.WriteLine($"Arquivo salvo com sucesso no caminho: [{path}]");
        Console.ReadKey();
        Menu.Show();
    }
}