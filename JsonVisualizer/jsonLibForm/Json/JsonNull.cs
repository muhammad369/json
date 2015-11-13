using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Json
{
    class JsonNull : JsonValue
    {

        public override string Render()
        {
            return "null";
        }
    }
}
