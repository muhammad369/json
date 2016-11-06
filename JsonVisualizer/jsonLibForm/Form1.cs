using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Selim.Json;
using System.Diagnostics;

namespace JsonVisualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            JsonValue v = new JsonParser().Parse( textBox1.Text );


            treeView1.Nodes.Clear();
            addToTheTree(v, treeView1.Nodes );
        }

        void addToTheTree(JsonValue jv, TreeNodeCollection currentNodeCol)
        {
            if (jv is JsonObject)
            {
                JsonObject jo = (JsonObject)jv;
                TreeNode n=new TreeNode("{}");
                currentNodeCol.Add(n);
                foreach (NameValue nv in jo.getNameVlaues())
                {
                    addToTheTree(nv, n.Nodes);
                }
            }
            else if(jv is JsonArray)
            {
                JsonArray ja = (JsonArray)jv;
                TreeNode n = new TreeNode("[]");
                currentNodeCol.Add(n);
                foreach (JsonValue v in ja.getValues())
                {
                    addToTheTree(v, n.Nodes);
                }
            }
            else // string , number ,boolean ,null
            {
                currentNodeCol.Add(jv.ToString());
            }
        }

        void addToTheTree(NameValue nv, TreeNodeCollection currentNodeCol)
        {
            if (nv.value is JsonObject)
            {
                JsonObject jo = (JsonObject)nv.value;
                TreeNode n = new TreeNode(nv.name+" : {}");
                currentNodeCol.Add(n);
                foreach (NameValue nv1 in jo.getNameVlaues())
                {
                    addToTheTree(nv1, n.Nodes);
                }
            }
            else if (nv.value is JsonArray)
            {
                JsonArray ja = (JsonArray)nv.value;
                TreeNode n = new TreeNode(nv.name+" : []");
                currentNodeCol.Add(n);
                foreach (JsonValue v in ja.getValues())
                {
                    addToTheTree(v, n.Nodes);
                }
            }
            else // string , number ,boolean ,null
            {
                currentNodeCol.Add(nv.name+" : "+ nv.value.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://eg.linkedin.com/pub/mohamed-selim/41/a36/b20");
        }

       

    }
}
