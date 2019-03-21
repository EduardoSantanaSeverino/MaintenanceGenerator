using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG
{
    public class ComboParameter
    {
        public String EntitySingular { get; set; }
        public  String EntityPlural { get; set; }
        public  String EntityCamelPlural { get; set; }
        public  String EntityCamelSingular{ get; set; }
        public  String FieldNameValue { get; set; }
        public  String FieldNameDisplay { get; set; }

        public ComboParameter(String _EntityNameSingular, String _FieldNameValue, String _FieldNameDisplay)
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
