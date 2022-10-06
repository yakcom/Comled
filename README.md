<a href="https://github.com/yakcom/Vkontakte.Bot/releases/">
<p align="center"><img  width="200" src="https://github.com/yakcom/Comled/blob/master/.github/Led.png"/></p>
<h1 align="center">Comled</h1></a>
<h3 align="center">A simple library for controlling a addressable led via a com port</h3><br>
<a href="https://www.nuget.org/packages/Vkontakte.Bot"><img src="https://readme-typing-svg.herokuapp.com?font=Fira+Code&size=25&pause=100000&duration=3000&color=4392E7&center=true&vCenter=true&width=1000&lines=Download+NuGet+Release" alt="Typing SVG" /></a>
<a href="https://minhaskamal.github.io/DownGit/#/home?url=https://github.com/yakcom/Comled/blob/master/Arduino/Arduino.ino"><img src="https://readme-typing-svg.herokuapp.com?font=Fira+Code&size=25&pause=100000&duration=3000&color=00979c&center=true&vCenter=true&width=1000&lines=Download+Arduino+Sketch" alt="Typing SVG" /></a>

# Using
## Arduino part
<br><h2>1. Download arduino sketch and open in <a href="https://github.com/yakcom/Comled/blob/master/.github/ArduinoLoad.png">Arduino IDE</a></h2>
<a href="https://minhaskamal.github.io/DownGit/#/home?url=https://github.com/yakcom/Comled/blob/master/Arduino/Arduino.ino"><img src="https://github.com/yakcom/Comled/blob/master/.github/ArduinoLoad.png" /></a><br><br>
<h2>2. Сhange the arduino sketch settings to your own</h2>

```c++
//----------------------
#define LEN 80  // Number of leds
#define PIN 5   // Connected pin
#define SPD 250000  // Baud rate
//----------------------
```
<br><h2>3. Upload arduino sketch to your microcontroller </h2>
<img src="https://github.com/yakcom/Comled/blob/master/.github/Upload.png" />
<h3><a href="https://create.arduino.cc/projecthub/yeshvanth_muniraj/getting-started-with-arduino-bcb879">How to upload a sketch</a></h3>
<h3><img width="20" src="https://github.com/yakcom/Comled/blob/master/.github/Warning.png" /> If a compilation error occurs, please make sure your arduino ide has the <a href="https://github.com/FastLED/FastLED">FastLED</a> library installed.</h3>
<h3><a href="https://docs.arduino.cc/software/ide-v1/tutorials/installing-libraries">How to install library</a></h3><br><br><br>

# Using
## Desktop part
```c#
using Comled;
```
## Create Led Object
```c#
Led Myled = new Led(a, b, c);
```
> a - Serial port number

> b - Number of leds

> c- Serial port baud rate
<br>

## Connet with Led strip
```c#
Myled.Connect();
```
<br>

## Set Color on led
```c#
Myled.Set(0, Color.Yellow);
```
### or
```c#
Myled.Set(0, "FFFF00");
```
<br>

## Led strip drawing
```c#
Myled.Show();
```
<br>

# Examples
## Simple Example
### Set the first led red
```c#
Led Myled = new Led(6, 80, 250000);
Myled.Connect();
Myled.Set(0, Color.Red);
Myled.Show();
```
<br>

## Full Console Example
### Fill all led strip yellow
```c#
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
                Myled.Set(i, Color.Yellow);
            Myled.Show();
        }
    }
}
```
