#include <FastLED.h>

//----------------------
#define LEN 82
#define PIN 5
//----------------------
#define SPD 250000
#define KEY "comled"     
//----------------------

CRGB LED[LEN];

void setup()
{
  Serial.begin(SPD);
  FastLED.addLeds<WS2812, PIN, GRB>(LED, LEN);
}
void loop() 
{
  for (byte i = 0; i < String(KEY).length(); ++i) 
  {
    x: while (!Serial.available()){}
    if (String(KEY)[i] == Serial.read()) continue;
    i = 0;goto x;
  }
  memset(LED, 0, LEN * sizeof(struct CRGB));
  for (int i = 0; i < LEN; i++) 
  {
    while (!Serial.available()) {}
    LED[i].r = Serial.read();
    while (!Serial.available()) {}
    LED[i].g = Serial.read();
    while (!Serial.available()) {}
    LED[i].b = Serial.read();
  }
  FastLED.show();
}
