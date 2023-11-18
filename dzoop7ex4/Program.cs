using System;

namespace DecoratorExample
{
    abstract class Tree
    {
        public abstract void Display();
    }

    class ChristmasTree : Tree
    {
        public override void Display()
        {
            Console.WriteLine("Christmas Tree");
        }
    }

    abstract class TreeDecorator : Tree
    {
        protected Tree tree;

        public TreeDecorator(Tree tree)
        {
            this.tree = tree;
        }

        public override void Display()
        {
            if (tree != null)
            {
                tree.Display();
            }
        }
    }
    class DecoratedTree : TreeDecorator
    {
        public DecoratedTree(Tree tree) : base(tree) { }

        public override void Display()
        {
            base.Display();
            AddDecorations();
        }

        private void AddDecorations()
        {
            Console.WriteLine("Decorated with ornaments");
        }
    }

    class LightedTree : TreeDecorator
    {
        public LightedTree(Tree tree) : base(tree) { }

        public override void Display()
        {
            base.Display();
            AddLights();
        }

        private void AddLights()
        {
            Console.WriteLine("Decorated with lights");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ChristmasTree tree = new ChristmasTree();
            DecoratedTree decoratedTree = new DecoratedTree(tree);
            LightedTree lightedTree = new LightedTree(decoratedTree);
            lightedTree.Display();
            Console.Read();
        }
    }
}
