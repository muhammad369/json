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

            JsonValue v = JsonParser.parse( textBox1.Text );

            treeView1.Nodes.Clear();
            addToTheTree(v, treeView1.Nodes );
            
            //
            textBox1.Text = v.render(0);
        }

        void addToTheTree(JsonValue jv, TreeNodeCollection currentNodeCol)
        {
            if (jv is JsonObject)
            {
                JsonObject jo = (JsonObject)jv;
                TreeNode n = new TreeNode("{" + jo.Length + "}");
                n.Tag = jo;
                n.ContextMenuStrip = contextMenuStrip1;
                currentNodeCol.Add(n);
                foreach (NameValue nv in jo.getNameVlaues())
                {
                    addToTheTree(nv, n.Nodes);
                }
            }
            else if(jv is JsonArray)
            {
                JsonArray ja = (JsonArray)jv;
                TreeNode n = new TreeNode("[" + ja.Length + "]");
                n.Tag = ja;
                n.ContextMenuStrip = contextMenuStrip1;
                currentNodeCol.Add(n);
                foreach (JsonValue v in ja.getValues())
                {
                    addToTheTree(v, n.Nodes);
                }
            }
            else // string , number ,boolean ,null
            {
                TreeNode n = new TreeNode(jv.ToString());
                n.Tag = jv;
                n.ContextMenuStrip = contextMenuStrip1;
                currentNodeCol.Add(n);
            }
        }

        void addToTheTree(NameValue nv, TreeNodeCollection currentNodeCol)
        {
            if (nv.value is JsonObject)
            {
                JsonObject jo = (JsonObject)nv.value;
                TreeNode n = new TreeNode(nv.name+" : {"+ jo.Length +"}");
                n.Tag = nv;
                n.ContextMenuStrip = contextMenuStrip1;
                currentNodeCol.Add(n);
                foreach (NameValue nv1 in jo.getNameVlaues())
                {
                    addToTheTree(nv1, n.Nodes);
                }
            }
            else if (nv.value is JsonArray)
            {
                JsonArray ja = (JsonArray)nv.value;
                TreeNode n = new TreeNode( nv.name+" : ["+ ja.Length +"]");
                n.Tag = nv;
                n.ContextMenuStrip = contextMenuStrip1;
                currentNodeCol.Add(n);
                foreach (JsonValue v in ja.getValues())
                {
                    addToTheTree(v, n.Nodes);
                }
            }
            else // string , number ,boolean ,null
            {
                TreeNode n = new TreeNode(nv.name+" : "+ nv.value.ToString());
                n.Tag = nv;
                n.ContextMenuStrip = contextMenuStrip1;
                currentNodeCol.Add(n);
            }
        }

        

        //============================

        private void copy_name_menu_item_Click(object sender, EventArgs e)
        {
            var item= treeView1.SelectedNode.Tag;

            copyName(item);
        }


        private void copy_value_menu_item_Click(object sender, EventArgs e)
        {
            var item = treeView1.SelectedNode.Tag;

            copyValue(item);
        }


        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var item = e.Node.Tag;
            copyName(item);
        }



        void copyName(object o)
        {
            try
            {
                if (o is NameValue)
                {
                    Clipboard.SetText((o as NameValue).name);
                }
                else
                {
                    Clipboard.SetText(" ");
                }
            }
            catch { }
        }

        void copyValue(object o)
        {
            try
            {
                if (o is NameValue)
                {
                    Clipboard.SetText((o as NameValue).value.render(0));
                }
                else if (o is JsonValue)
                {
                    Clipboard.SetText((o as JsonValue).render(0));
                }
                else
                {
                    Clipboard.SetText(" ");
                }
            }
            catch { }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
        }

       

    }
}
