using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagrada.IdentityServer.Module.Configuration
{
    public class AdminSection : ConfigurationSection
    {
        [ConfigurationProperty("defaultDomain", DefaultValue = "", IsRequired = false)]
        public string Domain
        {
            get { return (string)this["defaultDomain"]; }
            set { this["defaultDomain"] = value; }
        }

        [ConfigurationProperty("users", IsDefaultCollection = true, IsRequired = true)]
        [ConfigurationCollection(typeof(ParametersCollection), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
        public ParametersCollection Users
        {
            get
            {
                return (ParametersCollection)base["users"];
            }
        }

    }

    public class ParametersCollection : ConfigurationElementCollection
    {
        public ParametersCollection()
        {
        }

        public UserElement this[int index]
        {
            get { return (UserElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(UserElement filter)
        {
            BaseAdd(filter);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new UserElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((UserElement)element).Name;
        }

        public void Remove(UserElement filter)
        {
            BaseRemove(filter.Name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }
    }

    public class UserElement : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "admin", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
        public String Name
        {
            get
            {
                return (String)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

    }
}
