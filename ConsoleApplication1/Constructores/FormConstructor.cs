using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Procesador;
using static System.Net.WebRequestMethods;
using System.Collections;

namespace ConsoleApplication1.Constructores
{
    class FormConstructor
    {
        
        string sourcePath;
        string targetPath;
        String name;
        ArrayList list;

        public FormConstructor(String source, String target, String Objectname, ArrayList Fobjects)
        {          
            this.sourcePath = source;
            this.targetPath = target;
            this.name = Objectname;
            this.list = Fobjects;
        }

        public String generate_form (Dictionary<String,int> hashMap)
        {
            String template = "modaltest.html";
            Textprocessor processor = new Textprocessor();   
            String readpath = this.sourcePath + "/" + template;

            String html = " ";
            string[] lines = System.IO.File.ReadAllLines(readpath);

            for (int i = 0; i < lines.Length; i++)
            {
                html += lines[i];
                html += Environment.NewLine;
                if (lines[i].Trim() == "<!--[/modaltitle]-->")
                {
                    html += "Nuevo "+name;

                }
                if (lines[i].Trim() == "<!--[/forminfo]-->")
                {
                    int Counter = -1;                   
                    foreach (var data in hashMap.ToArray())
                    {
                        html += " <div class='form - group'>"+ Environment.NewLine;
                        html += "<label class='form-control'>"+data.Key+"</label>" + Environment.NewLine;
                        if(data.Value == 8)
                        {
                            Counter++;
                        }
                        html += type_html(data.Value,data.Key,Counter)+ Environment.NewLine;
                        html += "</div>"+Environment.NewLine;
                    }

                }                
            }
            return html;            
        }

        public String type_html(int type, String data, int Counter)
        {
            
            String html = " ";
            switch (type)
            {
                case 1:
                    html += "<input  class='form-control' id='"+data+"' required='required' name='"+data+"' type='text'>";
                    break;
                case 2:
                    html += "<input  class='form-control' id='"+data+"' required='required' name='"+data+"' type='number'>";
                    break;
                case 3:
                    html += "<input  class='form-control' id='"+data+"' required='required' name='"+data+"' type='password'>";
                    break;
                case 4:
                    html += "<input  class='form-control' id='"+data+"' required='required' name='"+data+"' type='email'>";
                    break;
                case 5:
                    html += "<input  class='form-control' id='"+data+"' required='required' name='"+data+"' type='date'>";
                    break;
                case 6:
                    html += "<input  class='form-control' id='"+data+"' required='required' name='"+data+"' type='file'>";
                    break;
                case 7:
                    html += "<textarea  class='form-control' id='"+data+"' required='required' name='"+data+"' type='file'></textarea>";
                    break;
                case 8:
                    html += "<select  class='form-control' id='"+data+"' required='required' name='"+data+ "'><option>Selecciona</option>"+ Environment.NewLine;
                    html += "@foreach("+list[Counter]+"s as "+ list[Counter] + ")"+ Environment.NewLine;
                    html += "<option val='{{"+list[Counter]+ "->id}}'>{{"+list[Counter]+"->nombre}}</option>";
                    html += "@endforeach";
                    html += "</select>";                    
                break;
            }

            return html;
        }

    }
}
