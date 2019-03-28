using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Generic
{
    public class ComboParameter
    {
        public string EntitySingular { get; set; }
        public string EntityPlural { get; set; }
        public string EntityCamelPlural { get; set; }
        public string EntityCamelSingular { get; set; }
        public string FieldNameValue { get; set; }
        public string FieldNameDisplay { get; set; }

        public ComboParameter(string _EntityNameSingular, string _FieldNameValue, string _FieldNameDisplay)
        {
            string camell = "";
            var lower = _EntityNameSingular;
            camell = lower + "s";
            var capital = camell.Substring(0, 1).ToUpper() + camell.Substring(1);
            var capitalSingular = lower.Substring(0, 1).ToUpper() + lower.Substring(1);

            EntityCamelPlural = camell;
            EntityPlural = capital;
            EntitySingular = capitalSingular;
            EntityCamelSingular = lower;

            this.FieldNameDisplay = _FieldNameDisplay;
            this.FieldNameValue = _FieldNameValue;
        }

        public override string ToString()
        {
            return this.EntitySingular + " | " + this.FieldNameValue + " | " + this.FieldNameDisplay;
        }
    }
}
