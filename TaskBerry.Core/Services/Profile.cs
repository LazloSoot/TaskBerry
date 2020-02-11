using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using TaskBerry.Core.Helpers;

namespace TaskBerry.Core.Services
{
    [Serializable]
    public class Profiles
    {
        public List<Profile> Values { get; }
        [XmlIgnore]
        public Profile Current => Values.First(x => x.Id.Equals(Properties.Settings.Default.SelectedProfileId));

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Profiles: [");
            foreach (var profile in Values)
            {
                stringBuilder.AppendLine(profile.ToString());
            }
            stringBuilder.Append("]");

            return stringBuilder.ToString();
        }
    }

    [Serializable]
    public class Profile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ConfigSwitcherData ConfigSwitcherSettings { get; set; }
        public MsBuildData MsBuildSettings { get; set; }
        public VpnData VpnSettings { get; set; }
        public SqliteData SqliteSettings { get; set; }

        public Profile(string name)
        {
            Id = new Guid();
            Name = name;
        }

        // TODO: Create Profile manager to handle it
        public void SetAsSelected()
        {
            Properties.Settings.Default.SelectedProfileId = Id;
            Properties.Settings.Default.Save();
        }

        public override string ToString()
        {
            return this.GetAllPropertiesStringValues();
        }
    }
}
