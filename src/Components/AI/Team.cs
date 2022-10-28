using Chloride.RA2.IniExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chloride.RA2.MapExt.Components.AI
{
    public class Team : IniSection
    {
        public Team(string name, IEnumerable<IniEntry> source) : base(name, source)
        {
            foreach (var i in _def_no)
            {
                if (!(bool)this[i])
                    Remove(i);
            }
            if (this[_def_yes].IsNull || (bool)this[_def_yes])
                Remove(_def_yes);
        }

        public static Team Create(string name, IEnumerable<IniEntry> source)
        {
            if (!source.Any())
                source = _default.Select(i => new IniEntry(i.Key, i.Value));
            return new(name, source);
        }

        private static Dictionary<string, IniValue> _default = new()
        {
            ["Max"] = "5",
            ["Name"] = "New Teamtype",
            ["Group"] = "-1",
            ["House"] = "<none>",
            ["Script"] = "<none>",
            ["TaskForce"] = "<none>",
            ["Priority"] = "5",
            ["Waypoint"] = "A",
            ["TechLevel"] = "0",
            ["VeteranLevel"] = "1",
            ["MindControlDecision"] = "0"
        };

        private static string[] _def_no =
        {
            "Full", "Whiner", "Droppod", "Suicide", "Loadable",
            "Prebuild", "Annoyance", "IonImmune", "Recruiter",
            "Reinforce", "Aggressive", "Autocreate", "GuardSlower",
            "OnTransOnly", "AvoidThreats", "LooseRecruit",
            "IsBaseDefense", "UseTransportOrigin",
            "OnlyTargetHouseEnemy", "TransportsReturnOnUnload"
        };

        private static string _def_yes = "AreTeamMembersRecruitable";

        // I JUST DON'T WANNA REBUILD AGAIN AND AGAIN AS API TRANSLATION WAS SO PAINFUL
    }
}
