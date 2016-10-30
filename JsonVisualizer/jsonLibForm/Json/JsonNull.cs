using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Json
{
    class JsonNull : JsonValue
    {

       
		public override void render(StringBuilder sb)
		{
			sb.Append("null");
		}
	}
}
