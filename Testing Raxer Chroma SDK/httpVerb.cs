using System;
using System.Collections.Generic;
using System.Text;

namespace Testing_Raxer_Chroma_SDK
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public class httpVerbObject
    {
        public httpVerb HttpVerb { get; set; }
        public string DisplayedString { get; set; }

        public httpVerbObject(httpVerb HttpVerb, string DisplayedString)
        {
            this.HttpVerb = HttpVerb;
            this.DisplayedString = DisplayedString;
        }
    }
}
