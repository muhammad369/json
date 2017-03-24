﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selim.Json
{
    class JsonNumber : JsonValue
    {
        public double value;
        public JsonNumber(double value)
        {
            this.value = value;
        }


		public override void render(StringBuilder sb, int? indents)
		{
			sb.Append(value.ToString());
		}
	}
}
