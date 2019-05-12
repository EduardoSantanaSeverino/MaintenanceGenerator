using MG.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG
{
    public class TripleValue<T, X, Y, Z>
    {
        public TripleValue(T _key, X _value, Y _valueAlt, Z _valueAppened, List<string> l)
        {
            this.Type = _key;
            this.Name = _value;
            this.MaxLenght = _valueAlt;
            this.MaxLenghtJustInt = _valueAppened;
            this.ShowOnList = l;
            AddDefaultFields();
        }
        public T Type { get; set; }
        public X Name { get; set; }
        public Y MaxLenght { get; set; }
        public Z MaxLenghtJustInt { get; set; }
        public List<string> ShowOnList { get; set; }
        public override string ToString()
        {
            return "Key:" + this.Type.ToString() + ", Value: " + this.Name + ", ValueAlt: " + this.MaxLenght + ", ValueAppened: " + this.MaxLenghtJustInt;
        }

        private void AddDefaultFields()
        {
            AddItem(new List<string>()
            {
                "IsDeleted",
                "DeleterUserId",
                "DeletionTime",
                "LastModificationTime",
                "LastModifierUserId",
                "CreationTime",
                "CreatorUserId",
                "IsActive"
            }, "ThisFieldIsHidden");


            AddItem(new List<string>()
            {
                "Name",
                "Description",
                "Title",
            }, FileTypes.List.ToString());

        }

        private void AddItem(List<string> l, string title)
        {
            string str = this.Name.ToString();
            if (l.Contains(str))
            {
                this.ShowOnList.Add(title);
            }
        }
    }
}
