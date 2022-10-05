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
            Myled.Set(0, Color.Red);
            Myled.Show();

        }
    }
}