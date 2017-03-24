using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selim.Json
{
    public abstract class JsonValue
    {

        public static string indentation = "   ";
        public string render(int? indent= null)
		{
			var sb = new StringBuilder();
            render(sb, indent);
            return sb.ToString();
		}


		/// <summary>
		/// this is to be called by render(), as an optimization tech, 
		/// to make sure only one instance of StringBuilder is used across nested or successive elements
		/// </summary>
		//public abstract void render(StringBuilder sb);

        public abstract void render(StringBuilder sb, int? indents= null);

		/// <summary>
		/// overrides the default behavior to get the text forming this element
		/// </summary>
		public override string ToString()
		{
			return this.render();
		}


        protected void appendMany(StringBuilder sb, string s,int times)
        {
            for (int i = 0; i < times; i++)
            {
                sb.Append(s);
            }
        }

    }
}
