using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Procesador;
using System.Collections;

namespace ConsoleApplication1.Constructores
{
    class TableConstructor
    {
        string sourcePath;
        string targetPath;
        String name;
        ArrayList list;

        public TableConstructor(String source, String target, String Objectname, ArrayList Fobjects)
        {
            this.sourcePath = source;
            this.targetPath = target;
            this.name = Objectname;
            this.list = Fobjects;
        }

        public String generate_table(Dictionary<String, int> hashMap)
        {
            String html = " ";
            String template = "tabletest.html";
            Textprocessor processor = new Textprocessor();
            String readpath = this.sourcePath + "/" + template;            
            string[] lines = System.IO.File.ReadAllLines(readpath);
            for (int i = 0; i < lines.Length; i++)
            {
                html += lines[i];
                html += Environment.NewLine;
                if (lines[i].Trim() == "<!--[/tabletitle]-->")
                {
                    html += this.name;

                }
                if (lines[i].Trim() == "<!--[/tableheaders]-->")
                {
                    foreach (var data in hashMap.ToArray())
                    {
                        html += "<th>"+data.Key+"</th>" + Environment.NewLine;
                    }
                    html += "<th>Opciones</th>" + Environment.NewLine;
                }
                if (lines[i].Trim() == "<!--[/tablebody]-->")
                {
                    html += "<tr>" + Environment.NewLine;
                    int Counter = -1;
                    foreach (var data in hashMap.ToArray())
                    {
                        if (data.Value == 8)
                        {
                            Counter++;
                        }
                        html += type_td(this.name,data.Value,Counter) + Environment.NewLine; 
                    }
                    html += "<tr>" + Environment.NewLine;
                }
            }
            return html;
        }

        public String type_td(String data, int type, int Counter)
        {
            String html = "";
            if(type==1 || type == 2 || type == 4 || type == 7)
            {
                html += "<td id='tdtext{ {$"+data+"->id} }' contenteditable='true' onclick='big_text_edit(this)' onblur='big_text_edit_over(this)'> {{"+data+"->nombre}} </td>" + Environment.NewLine;
            }
            else
            {
                html += "<td> <input type='hidden' name ='td{{$"+data+"->id}}' value='{{$"+data+"->"+list[Counter]+"->id}}'> <span id='paramtext{{$"+data+"->id}}'>{{$"+data+"->"+list[Counter]+ "->nombre}}</span> <a href='#' onclick='changue({{$"+data+"->id}})' title='cambiar'><i class='fa fa-pencil' aria-hidden='true'></i></a> </td>" + Environment.NewLine;
            }

            html += "<td> <button  title='guardar' onclick='save_register({{$"+data+"->id}})'><i class='fa fa-floppy - o' aria-hidden='true'></i> </button> <button title='eliminar' onclick='delete_register({ {$"+data+"->id} })'><i class='fa fa-trash' aria-hidden='true'></i></button> </td>" + Environment.NewLine;

            return html;              
        }
    }
}
