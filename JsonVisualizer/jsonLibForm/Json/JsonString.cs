using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Json
{
    class JsonString : JsonValue
    {
        public string value;
        public JsonString(string value)
        {
            this.value = value;
        }

        public override string Render()
        {
            return string.Format("\"{0}\"", value.Replace("\"","\\\""));
        }

    }
}
