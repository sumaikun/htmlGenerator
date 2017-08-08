using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1.Constructores;
using ConsoleApplication1.Procesador;
using System.Collections;

namespace ConsoleApplication1.Documentos
{
        public class Html
    {
        string templateName;
        string fileName ;
        string sourcePath ;
        string targetPath;
        string Objectname;
        ArrayList Fobjects;

        public Html(String projectName, String Obname, ArrayList Robjects)
	    {
            this.Fobjects = Robjects;
            this.Objectname = Obname;
            this.templateName = "test.html";            
            this.fileName = projectName+".html";
            this.sourcePath = @"C:\Users\jtorres\Documents\Documentos_app";
            this.targetPath = @"C:\Users\jtorres\Documents\Documentos_app\" + projectName;
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }
        }

        public void insert_data(Dictionary<string, int> hashMap)
        {
            String html = " ";

            FormConstructor form = new FormConstructor(this.sourcePath,this.targetPath+"/"+this.fileName, this.Objectname, this.Fobjects);
            TableConstructor table = new TableConstructor(this.sourcePath, this.targetPath + "/" + this.fileName, this.Objectname, this.Fobjects);
            JsConstructor js = new JsConstructor(this.sourcePath, this.targetPath + "/" + this.fileName, this.Objectname);

            html = form.generate_form(hashMap);
            html += table.generate_table(hashMap);
            html += js.generateJs(hashMap);

            write_file(html);
        }

        public void read_file()
        {
            Textprocessor processor = new Textprocessor();
            Console.WriteLine("documento final");
            String writepath = this.targetPath + "/" + this.fileName;
            processor.read_this(writepath);            
        }

        public void write_file(String data)
        {
            Textprocessor processor = new Textprocessor();
            String writepath = this.targetPath + "/" + this.fileName;
            Console.WriteLine("destino "+writepath);
            String readpath = this.sourcePath + "/" + this.templateName;
            String flag = "<!--[/Content]-->";
            processor.write_this(writepath, readpath, data, flag);
        }
        
       
    }
}
