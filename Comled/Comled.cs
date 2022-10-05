using System.IO.Ports;
using System.Drawing;
using System.Text;

namespace Comled
{
    public class Led
    {
        private Color[] Leds;
        private byte[] Data;
        private SerialPort SerialPort;

        /// <summary>
        /// Led serial port number 
        /// </summary>
        public int Comport { private set; get; }
        /// <summary>
        /// Number of Leds
        /// </summary>
        public int Length { private set; get; }
        /// <summary>
        /// Led serial port baud rate
        /// </summary>
        public int Speed { private set; get; }


        /// <summary>
        /// Cleate led strip object
        /// </summary>
        /// <param name="Comport">Led serial port number </param>
        /// <param name="Length">Number of Leds</param>
        /// <param name="Speed">Led serial port baud rate</param>
        public Led(int Comport,int Length,int Speed)
        {
            Leds = new Color[Length];
            Data = new byte[Length * 3 + 6];

            this.Comport = Comport;
            this.Length = Length;
            this.Speed = Speed;

            Data = Encoding.ASCII.GetBytes("comled").Concat(Data).ToArray();
            SerialPort = new SerialPort($"COM{Comport}", Speed);
        }


        /// <summary>
        /// Connect to led strip
        /// </summary>
        public void Connect()
        {
            try { SerialPort.Open(); }
            catch { throw new Exception($"COM{Comport} is not available !"); }
        }

        /// <summary>
        /// Disconnect from led strip
        /// </summary>
        public void Disconnect()
        {
            SerialPort.Close();
        }


        /// <summary>
        /// Set led color
        /// </summary>
        /// <param name="index">Led number</param>
        /// <param name="Color">Led Color</param>
        public void Set(int index,Color Color)
        {
            Leds[index] = Color;
        }

        /// <summary>
        /// Set led color via hex
        /// </summary>
        /// <param name="Index">Led number</param>
        /// <param name="Hex">Led hex color string</param>
        public void Set(int Index, string Hex)
        {
            if (!Hex.Contains("#")) Hex = $"#{Hex}";
            try { Leds[Index] = ColorTranslator.FromHtml(Hex); }catch{throw new Exception($"Сan't convert {Hex} to color !"); }
        }


        /// <summary>
        /// Draw the created led
        /// </summary>
        public void Show()
        {
            if (SerialPort.IsOpen)
            {
                for (int i = 0, j = 6; i < Length; i++, j += 3)
                {
                    Data[j] = Leds[i].R;
                    Data[j + 1] = Leds[i].G;
                    Data[j + 2] = Leds[i].B;
                }
                SerialPort.Write(Data, 0, Data.Length);
            }
            else
            {
               throw new Exception($"COM{Comport} is not open !");
            }
        }
    }
}