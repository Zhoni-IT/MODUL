using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULS.MODUL10.DOM
{
    public abstract class FileSystemComponent
    {
        public string Name { get; }

        public FileSystemComponent(string name)
        {
            Name = name;
        }

        public abstract void Display(int indentationLevel = 0);

        public abstract int GetSize();
    }

    public class File : FileSystemComponent
    {
        private int Size;

        public File(string name, int size) : base(name)
        {
            Size = size;
        }

        public override void Display(int indentationLevel = 0)
        {
            Console.WriteLine($"{new string(' ', indentationLevel * 2)}File: {Name}, Size: {Size}KB");
        }

        public override int GetSize()
        {
            return Size;
        }
    }

    public class Directory : FileSystemComponent
    {
        private List<FileSystemComponent> _components = new List<FileSystemComponent>();

        public Directory(string name) : base(name) { }

        public void AddComponent(FileSystemComponent component)
        {
            if (!_components.Contains(component))
            {
                _components.Add(component);
            }
            else
            {
                Console.WriteLine($"Компонент {component.Name} уже существует в папке {Name}.");
            }
        }

        public void RemoveComponent(FileSystemComponent component)
        {
            if (_components.Contains(component))
            {
                _components.Remove(component);
            }
            else
            {
                Console.WriteLine($"Компонент {component.Name} не найден в папке {Name}.");
            }
        }

        public override void Display(int indentationLevel = 0)
        {
            Console.WriteLine($"{new string(' ', indentationLevel * 2)}Directory: {Name}");
            foreach (var component in _components)
            {
                component.Display(indentationLevel + 1);
            }
        }

        public override int GetSize()
        {
            int totalSize = 0;
            foreach (var component in _components)
            {
                totalSize += component.GetSize();
            }
            return totalSize;
        }
    }
    internal class Program2
    {
        /*public static void Main()
        {
            var file1 = new File("File1.txt", 120);
            var file2 = new File("File2.jpg", 340);
            var file3 = new File("File3.mp3", 780);

            var rootDirectory = new Directory("Root");
            var subDirectory1 = new Directory("Documents");
            var subDirectory2 = new Directory("Media");

            rootDirectory.AddComponent(file1);

            subDirectory1.AddComponent(file2);
            subDirectory2.AddComponent(file3);

            rootDirectory.AddComponent(subDirectory1);
            rootDirectory.AddComponent(subDirectory2);

            Console.WriteLine("Содержимое файловой системы:");
            rootDirectory.Display();
            Console.WriteLine($"\nОбщий размер файловой системы: {rootDirectory.GetSize()}KB\n");

            subDirectory2.AddComponent(file3);
            Console.WriteLine("\nСодержимое после добавления существующего файла:");
            rootDirectory.Display();
            Console.WriteLine($"\nОбщий размер файловой системы: {rootDirectory.GetSize()}KB\n");

            rootDirectory.RemoveComponent(file3);
            Console.WriteLine("\nСодержимое после удаления файла:");
            rootDirectory.Display();
            Console.WriteLine($"\nОбщий размер после удаления файла: {rootDirectory.GetSize()}KB\n");
        }*/
    }
}
