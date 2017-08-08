using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Procesador;

namespace ConsoleApplication1.Constructores
{
    class JsConstructor
    {
        string sourcePath;
        string targetPath;
        String name;

        public JsConstructor(String source, String target, String Objectname)
        {
            this.sourcePath = source;
            this.targetPath = target;
            this.name = Objectname;
        }

        public String generateJs(Dictionary<String, int> hashMap)
        {
            String html = "";
            String template = "jcrud.js";
            Textprocessor processor = new Textprocessor();
            String readpath = this.sourcePath + "/" + template;
            string[] lines = System.IO.File.ReadAllLines(readpath);
            html += "<script>" + Environment.NewLine;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Trim() == "/*info_url*/")
                {
                    html += "'info_"+this.name+"/id'";
                }
                if (lines[i].Trim() == "//ParamsJsedit")
                {
                    html += "$('input[name='id']').empty();" + Environment.NewLine;
                    html += "$('input[name='id']').val(id);" + Environment.NewLine;

                    foreach (var data in hashMap.ToArray())
                    {
                        if(data.Value!=7)
                        {
                            html += "$('input[name='"+data.Key+"']').empty();"+Environment.NewLine;
                            html += "$('input[name='"+data.Key+"']').val(res."+data.Key+");"+ Environment.NewLine;
                        }
                        else
                        {
                            html += "$('input[name='"+data.Key+"']').empty();" + Environment.NewLine;
                            html += "$('input[name='"+data.Key+"']').append(res." + data.Key + ");" + Environment.NewLine;
                        }
                    }

                }
                if (lines[i].Trim() == "//ParamsJssave"|| lines[i].Trim() == "//ParamsJscreate")
                {
                    html += " var id = $('input[name='id']').val();" + Environment.NewLine;
                    foreach (var data in hashMap.ToArray())
                    {                                                
                        html += " var "+data.Key+" = $('input[name='"+data.Key+"']').val();" + Environment.NewLine;                        
                    }
                }
                if (lines[i].Trim() == "//Posdata")
                {
                    foreach (var data in hashMap.ToArray())
                    {
                        html += data.Key+":"+ data.Key+ Environment.NewLine;
                    }
                }
                if (lines[i].Trim() == "/*updateajax_url*/")
                {
                    html += "'update_"+ this.name +"/+id'";
                }
                if (lines[i].Trim() == "/*createajax_url*/")
                {
                    html += "'create_" + this.name + "/+id'";
                }
                if (lines[i].Trim() == "/*deleteajax_url*/")
                {
                    html += "'delete_" + this.name + "/+id'";
                }
                else { html += lines[i];}
                
                html += Environment.NewLine;
            }
            html += "</script>";
            return html;
        }
    }
}
