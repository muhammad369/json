using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Json
{
    class JsonArray : JsonValue
    {
        List<JsonValue> values = new List<JsonValue>();

        public JsonArray()
        {}

        public JsonArray(params JsonValue[] values)
        {
            this.values.AddRange(values);
        }

        public JsonArray add(params JsonValue[] values)
        {
            this.values.AddRange(values);
			return this;
        }

		public JsonArray add(JsonValue value)
        {
            this.values.Add(value);
			return this;
        }

		public JsonArray add(double value)
        {
            this.values.Add(new JsonNumber(value));
			return this;
        }

		public JsonArray add(string value)
        {
            if(value!=null)
            {
                this.values.Add(new JsonString(value));
            }
            else
            {
                this.values.Add(new JsonNull());
            }
			return this;
        }

		public JsonArray add(bool value)
        {
            this.values.Add(new JsonBoolean( value));
			return this;
        }

		public JsonArray addAll(double[] arr)
		{
			foreach (double item in arr)
			{
				add(item);
			}
			return this;
		}

		public JsonArray addAll(string[] arr)
		{
			foreach (string item in arr)
			{
				add(item);
			}
			return this;
		}

		public JsonArray addAll(bool[] arr)
		{
			foreach (bool item in arr)
			{
				add(item);
			}
			return this;
		}

        public int Length { get { return values.Count; } }

        public JsonValue[] getValues()
        {
            return values.ToArray();
        }

        public JsonValue getValue(int index)
        {
            return values.ElementAt(index);
        }

		public string getString(int index)
		{
			JsonString tmp = (JsonString)getValue(index);
			return tmp.value;
		}

		public double getDouble(int index)
		{
			JsonNumber tmp = (JsonNumber)getValue(index);
			return tmp.value;
		}

		public int getInt(int index)
		{
			JsonNumber tmp = (JsonNumber)getValue(index);
			return (int)tmp.value;
		}

		public bool getBool(int index)
		{
			JsonBoolean tmp = (JsonBoolean)getValue(index);
			return tmp.value;
		}

		public JsonObject getObject(int index)
		{
			return (JsonObject)getValue(index);
		}

		public JsonArray getArray(int index)
		{
			return (JsonArray)getValue(index);
		}

        public override string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (JsonValue item in this.values)
            {
                sb.AppendFormat("{0},",item.Render());
            }
            sb.Remove(sb.Length - 1, 1);//remove the last comma
            return sb.Append("]").ToString();
        }

    }
}
