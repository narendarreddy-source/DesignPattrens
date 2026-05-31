using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Structural
{
    public class Flyweight
    {
        public Flyweight() {

            var sandlewood = TreeFactory.GetTreeType("SandleWood","Green","Smooth");
            var tree1 = new Tree(10, 20, sandlewood);
            var tree2 = new Tree(20, 10, sandlewood);
        }
    }

    //Intrinsic shared data
    public class TreeType
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Texture { get; set; }
        public TreeType(string name,string color,string texture) {
            this.Name = name;
            this.Color = color;
            this.Texture = texture;
        }
    }


    //FlyWeight Factory
    public class TreeFactory
    {
        private static readonly Dictionary<string, TreeType> _types = new Dictionary<string, TreeType>();
        public static TreeType GetTreeType(string name, string color, string textture)
        {
            string key = $"{name}--{color}--{textture}";

            if(!_types.ContainsKey(key))
                _types[key] = new TreeType(name, color, textture);
            return _types[key];
        }
    }


    //Tree with extrinsic data
    public class Tree
    {
        public int X { get; }
        public int Y { get; }
        public TreeType TreeType { get; }

        public Tree(int x, int y, TreeType treeType)
        {
            X = x;
            Y = y;
            TreeType = treeType;
        }
    }
}
