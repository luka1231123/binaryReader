using System.Text;

namespace BinaryPress;
//110010100 = 404 (not found)
class Program
{
    static void Main(string[] args)
    {
        bool loopy = true;
        while (loopy)
        {
            Console.WriteLine("write a path to acess and read: ");
            Console.Write("~ ");
            string path = Console.ReadLine();
            double Binary = 0;

            if(path != null)
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
                {
                    Binary = Convert.ToDouble(reader.Read());
                    if(Binary == -1)
                    {
                        using (var stream = File.Open(path, FileMode.Create))
                        {
                            using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                            {
                                writer.Write(110010100);
                            }
                        }
                    }
                    Binary = Convert.ToDouble(reader.Read());
                    Console.WriteLine("Double Value : " + (Binary-46));
                    
                }
            }
            else
            {
                loopy = false;
            }
        }
    }
}