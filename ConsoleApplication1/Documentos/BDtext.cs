using System;
using ConsoleApplication1.Procesador;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1.Documentos
{
        public class BDtext
    {
        String ProjectName;
        string targetPath;
        string fileName;
        string sourcePath;
        String templateName;

        public BDtext(String Pname)
	    {
            this.ProjectName = Pname;
            this.targetPath = @"C:\Users\jtorres\Documents\Documentos_app"+"/"+Pname;
            this.fileName = Pname + ".sql";
            this.templateName = "test.sql";
            this.sourcePath = @"C:\Users\jtorres\Documents\Documentos_app";
        }

        public void insert_data(Dictionary<String,int> hashMap)
        {
            Textprocessor processor = new Textprocessor();
            String writepath = this.targetPath + "/" + this.fileName;
            String readpath = this.sourcePath + "/" + this.templateName;
            String flag = "--Data";
            String sql = "";
            foreach (var data in hashMap.ToArray())
            {
                
            }

            

            processor.write_this(writepath, readpath, sql, flag);
        }
    }
}
