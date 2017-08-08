using System;
using System.IO;

namespace ConsoleApplication1.Procesador
{
        public class Textprocessor
    {
	    public Textprocessor()
	    {

	    }

        public void write_this(String writepath, String readpath, String data, String flag)
        {
            //StreamReader reader = new StreamReader(@"C:\Users\jtorres\Documents\Documentos_app\" + templateName);

            StreamWriter File = new StreamWriter(writepath);
            
            string[] lines = System.IO.File.ReadAllLines(readpath);

            for (int i = 0; i < lines.Length; i++)
            {                
                File.WriteLine(lines[i]);
                if (lines[i].Trim() == flag)
                {
                    File.WriteLine(data);

                }

            }
            File.Close();
        }

        public void read_this(String path)
        {
            StreamReader readerf = new StreamReader(path);
            while (!readerf.EndOfStream)
            {
                Console.WriteLine(readerf.ReadLine());
            }

            readerf.Close();
        }
    }
}
