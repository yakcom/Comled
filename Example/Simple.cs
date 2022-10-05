using System.Drawing;
using Comled;

namespace Example
{
    internal class Simple
    {
        static void Main(string[] args)
        {

            Led Myled = new Led(6, 80, 250000);
            Myled.Connect();
            for(int i=0;i<Myled.Length;i++)
                Myled.Set(i, Color.Black);
            Myled.Show();

        }
    }
}