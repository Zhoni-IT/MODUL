using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MODULS.MODUL10.LAB
{
    public abstract class Component {
        protected string _name;
        public Component(string name)
        {
            _name = name;
        }
        public abstract void Display(int depth);

        public virtual void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(Component component)
        {
            throw new NotImplementedException();
        }

        public virtual Component GetChild(int index)
        {
            throw new NotImplementedException();
        }

    }
    public class File : Component
    {
        public File(string name) : base(name)
        {
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + " File: " + _name);
        }
    }
    public class Directory : Component
    {
        private List<Component> _children = new List<Component>();

        public Directory(string name) : base(name)
        {
        }

        public override void Add(Component component)
        {
            _children.Add(component);
        }

        public override void Remove(Component component)
        {
            _children.Remove(component);
        }

        public override Component GetChild(int index)
        {
            return _children[index];
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + " Directory: " + _name);
            foreach (var component in _children)
            {
                component.Display(depth + 2);
            }
        }
    }

    internal class Program2
    {
        /*static void Main(string[] args)
        {
            Directory root = new Directory("Root");
            File file1 = new File("File1.txt");
            File file2 = new File("File2.txt");

            Directory subDir = new Directory("SubDirectory");
            File subFile1 = new File("SubFile1.txt");

            root.Add(file1);
            root.Add(file2);
            subDir.Add(subFile1);
            root.Add(subDir);

            root.Display(1);
        }*/

    }
}
