using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Json
{
    class JsonBoolean : JsonValue
    {
        public bool value;
        public JsonBoolean(bool value)
        {
            this.value = value;
        }

        public override string Render()
        {
            return value ? "true" : "false";
        }

    }
}
