using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Json
{
    public abstract class JsonValue
    {
        public string render()
		{
			var sb = new StringBuilder();
            render(sb);
            return sb.ToString();
		}

		/// <summary>
		/// this is to be called by render(), as an optimization tech, 
		/// to make sure only one instance of StringBuilder is used across nested or successive elements
		/// </summary>
		public abstract void render(StringBuilder sb);

		/// <summary>
		/// overrides the default behavior to get the text forming this element
		/// </summary>
		public override string ToString()
		{
			return this.render();
		}

    }
}
