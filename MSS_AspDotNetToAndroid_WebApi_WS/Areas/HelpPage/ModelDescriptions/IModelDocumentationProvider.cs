using System;
using System.Reflection;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}