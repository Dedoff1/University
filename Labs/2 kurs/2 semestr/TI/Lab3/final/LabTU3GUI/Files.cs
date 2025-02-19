using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTU3GUI
{
    public class Files
    {
        public byte[] readFile(string path)
        {
            try
            {
                byte[] arr = File.ReadAllBytes(path);
                return arr;
            }
            catch
            {
                return null;
            }
        }

        public void writeFile(string filePath, byte[] text)
        {   using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                fs.Write(text, 0, text.Length);
            }
        }


    }
}
