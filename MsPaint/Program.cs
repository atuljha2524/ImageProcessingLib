using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsPaint
{
    class Program
    {
        static void Main(string[] args)
        {
            //ImageProcessingLib.ImageProcessor obj = new ImageProcessingLib.ImageProcessor();
            //Console.WriteLine(obj.Process("testContent"));
            try
            {
                Console.WriteLine("Enter Image Processor Version - Options 1.0.0.0 or 2.0.0.0 ");
                string versionNumber = Console.ReadLine();

                //String Interpollation
                string dllPath = $@"C:\Users\320105541\source\repos\ImageProcessingLib\ImageProcessingLib\bin\Debug\{versionNumber}\ImageProcessingLib.dll";

                //Load assembly Dynamically
                System.Reflection.Assembly _dllRef = System.Reflection.Assembly.LoadFile(dllPath);

                //search for class by name ImageProcessor
                System.Type _classRef = _dllRef.GetType("ImageProcessingLib.ImageProcessor");

                //Instantiate Class
                Object obj = System.Activator.CreateInstance(_classRef);

                System.Reflection.MethodInfo _methodRef = _classRef.GetMethod("Process");

                //Invoke Dynamically
                object result = _methodRef.Invoke(obj, new object[] {"test Image"});

                Console.WriteLine(result.ToString());
            }
            catch (Exception ex) {
                    Console.WriteLine(ex.Message);
            }
        }
    }
}
