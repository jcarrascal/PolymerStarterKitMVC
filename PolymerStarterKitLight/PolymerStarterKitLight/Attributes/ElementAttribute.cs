using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolymerStarterKitLight.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class ElementAttribute : Attribute
    {
    }
}