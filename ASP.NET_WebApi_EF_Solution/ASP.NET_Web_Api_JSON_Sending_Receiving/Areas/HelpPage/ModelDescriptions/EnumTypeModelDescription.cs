using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ASP.NET_Web_Api_JSON_Sending_Receiving.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}