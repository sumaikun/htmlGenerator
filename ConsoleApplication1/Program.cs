using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1.Documentos;
//Clases propias



namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<String, int> hashMap = new Dictionary<String, int>();
            
            String param;
            String stype;
            int type = 0;
            int count = 1;
            string objectName;
            ArrayList Robjects = new ArrayList();

            Console.WriteLine("Nombre del objeto");
            objectName = Console.ReadLine();

            Console.WriteLine("Ingrese los parametros para crear archivos, escriba exit para salir");
            do
            {
                Console.WriteLine("Parametro "+count);
                param = Console.ReadLine();

                if(param != "exit")
                {
                    do
                    {
                        Console.WriteLine("Tipo de parametro " + count + " 'para string: (1), number o int: (2), secret: (3), email: (4), date: (5), file: (6), textarea: (7), foreing: (8)'");
                        stype = Console.ReadLine();
                        if(stype == "8")
                        {
                            Console.WriteLine("Escriba el nombre del objeto al que se relaciona");
                            Robjects.Add(Console.ReadLine().Trim());
                        }
                    } while (!Int32.TryParse(stype, out type));
                    hashMap[param] = type;
                }                
                count++; 
            } while (param != "exit");

            Console.WriteLine("Parametros y tipos");

            foreach (var kvp in hashMap.ToArray())
            {
                Console.WriteLine(kvp.Key + " " + kvp.Value);
            }

            Html front = new Html("Seguimiento",objectName,Robjects);
                        
            front.insert_data(hashMap);
            front.read_file();

            BDtext bd = new BDtext("Consultorio");
            bd.insert_data(hashMap);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }
}

//Código para duplicar archivo en rutas distintas
//string sourceFile = System.IO.Path.Combine(sourcePath, templateName);
//string destFile = System.IO.Path.Combine(targetPath, fileName);
//System.IO.File.Copy(sourceFile, destFile, true);