namespace SoftUniLogger
{
    using System;

    public class XmlLayout : ILayout
    {
        public string Format
         => "<log>" + Environment.NewLine +
            "   <date>{0}</date>" + Environment.NewLine +
            "   <message>{1}</message>" + Environment.NewLine +
            "   <level>{2}</level>" + Environment.NewLine +
            "</log>";
    }
}
