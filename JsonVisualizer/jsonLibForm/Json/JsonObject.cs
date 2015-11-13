using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Json
{
    class JsonObject : JsonValue
    {

        List<NameValue> nameValues = new List<NameValue>();

        public JsonObject(){}

        public JsonObject(params NameValue[] pairs)
        {
            this.nameValues.AddRange(pairs);
        }

		public JsonObject add(params NameValue[] pairs)
        {
            this.nameValues.AddRange(pairs);
			return this;
        }

		public JsonObject add(NameValue pair)
        {
            this.nameValues.Add(pair);
			return this;
        }

		public JsonObject add(string name, JsonValue value)
        {
            this.nameValues.Add( new NameValue(name, value) );
			return this;
        }

		public JsonObject add(string name, string value)
        {
            if (value != null)
            {
                this.nameValues.Add(new NameValue(name, new JsonString(value)));
            }
            else
            {
                this.nameValues.Add(new NameValue(name, new JsonNull()));
            }
			return this;
        }

		public JsonObject add(string name, double value)
        {
            this.nameValues.Add(new NameValue(name, new JsonNumber(value)));
			return this;
        }

		public JsonObject add(string name, bool value)
        {
            this.nameValues.Add(new NameValue(name, new JsonBoolean(value)));
			return this;
        }

        public int Length { get { return nameValues.Count; } }

        public NameValue[] getNameVlaues()
        {
            return nameValues.ToArray();
        }

        public JsonValue getValue(int index)
        {
            return nameValues.ElementAt(index).value;
        }

        public JsonValue getValue(string name)
        {
            return nameValues.First(nv => nv.name == name).value;
        }

        public string getString(string name)
        {
            JsonString tmp = (JsonString)getValue(name);
            return tmp.value;
        }

        public double getDouble(string name)
        {
            JsonNumber tmp = (JsonNumber)getValue(name);
            return tmp.value;
        }

        public int getInt(string name)
        {
            JsonNumber tmp = (JsonNumber)getValue(name);
            return (int)tmp.value;
        }

        public bool getBool(string name)
        {
            JsonBoolean tmp = (JsonBoolean)getValue(name);
            return tmp.value;
        }

		public JsonObject getObject(string name)
		{
			return (JsonObject)getValue(name);
		}

		public JsonArray getArray(string name)
		{
			return (JsonArray)getValue(name);
		}

        public override string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            foreach (NameValue item in this.nameValues)
            {
                sb.AppendFormat("{0},", item.render());
            }
            sb.Remove(sb.Length - 1, 1);//remove the last comma
            return sb.Append("}").ToString();
        }

    }


    struct NameValue
    {
        public string name;
        public JsonValue value;

        public NameValue(string name, JsonValue value)
        {
            this.name = name;
            this.value = value;
        }

        public NameValue(string name, string value)
        {
            this.name = name;
            if (value != null)
            {
                this.value = new JsonString(value);
            }
            else
            {
                this.value = new JsonNull();
            }
        }

        public NameValue(string name, bool value)
        {
            this.name = name;
            this.value = new JsonBoolean(value);
        }

        public NameValue(string name, double value)
        {
            this.name = name;
            this.value = new JsonNumber(value);
        }

        public string render()
        {
            StringBuilder sb = new StringBuilder();
            return sb.AppendFormat("\"{0}\":{1}", name, value.Render()).ToString();
            
        }

    }
}
