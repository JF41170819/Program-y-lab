using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.IO;
using System.Xml.Serialization;
namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            //                             ARCHIVLO XML

            using(StreamWriter sw=new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+@"\persona.xml",false))
            {

                List<Persona> lista = new List<Persona>();

              
                  Persona per=new Persona("Lucas","Carreño");
                Persona per_2 = new Persona("Queto sama", "CEO");
                Alumno alum = new Alumno("Pancho", "Sama", 1);
                lista.Add(alum);
                lista.Add(per);
                lista.Add(per_2);
                XmlSerializer xmls = new XmlSerializer(typeof(List<Persona>));
                xmls.Serialize(sw, lista);

                /*
              XmlSerializer xmls = new XmlSerializer(typeof(Persona));
              xmls.Serialize(sw, per);
              xmls.Serialize(sw, per_2);
              */
            
            }

            using (StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\persona.xml"))
            {

                List<Persona> lista = new List<Persona>();

                XmlSerializer xmls = new XmlSerializer(typeof(List<Persona>));
                lista=(List<Persona>)xmls.Deserialize(sr);
                foreach (Persona i in lista)
                {
                    Console.WriteLine(i.ToString());
                    Console.ReadLine();
                }
                Console.Read();
                /*
                Persona miper;
                XmlSerializer xmls = new XmlSerializer(typeof(Persona));
                miper=(Persona)xmls.Deserialize(

                Console.WriteLine(miper.ToString()) ;
                Console.Read();
                 */
            }




            //                             ARCHIVO TEXTO


           /*
            
             Persona per_1 = new Persona("Santiago", "Bonazi");
            using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\personas.txt", true))
            //using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory+@"\personas.txt", true))
            {
                sw.WriteLine(per_1.ToString());
            }

            using (StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\personas.txt"))
            //using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory+@"\personas.txt"))
            {
                while (sr.EndOfStream == false)
                {

                    Console.WriteLine(sr.ReadLine());
                    Console.ReadLine();
                    //System.Threading.Thread.Sleep(2000);
                }
            }
            
            */
            

           
            
           
        }
    }
}
