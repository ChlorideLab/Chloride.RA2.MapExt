using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chloride.RA2.IniExt;

namespace Chloride.RA2.MapExt.Components.AI
{
    public class TaskForce : IniSection
    {
        public TaskForce(string name, IEnumerable<IniEntry> source) : base(name, source)
        {
        }

        // so C# doesn't allow customizing Constructor calling orders = =
        public static TaskForce Create(string name, IEnumerable<IniEntry> source)
        {
            if (!source.Any())
                source = new IniEntry[] { new("Name", "New Taskforce") };
            return new(name, source);
        }

        public IniValue this[int index]
        {
            get => base[index.ToString()];
            set => base[index.ToString()] = value;
        }

        public override string ToString() => $"Taskforce {Name}";
    }
}
