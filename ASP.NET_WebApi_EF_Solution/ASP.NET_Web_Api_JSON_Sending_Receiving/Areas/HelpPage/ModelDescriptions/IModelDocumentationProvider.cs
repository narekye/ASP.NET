using System;
using System.Reflection;

namespace ASP.NET_Web_Api_JSON_Sending_Receiving.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}