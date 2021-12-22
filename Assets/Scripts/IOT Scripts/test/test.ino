#include <SoftwareSerial.h>
#include <SerialCommand.h>

SerialCommand sCmd;
int ledJump = 2;
int ledDash = 3;

void setup() {
  // put your setup code here, to run once:
  pinMode(ledJump, OUTPUT); // Intialisation de la broche numéro 2 (numérique).
  pinMode(ledDash, OUTPUT); // Intialisation de la broche numéro 2 (numérique).
  Serial.begin(38400);
  while (!Serial);
  sCmd.addCommand("DoubleJumpLedOn", turnOnLedJump);
  sCmd.addCommand("DoubleJumpLedOff", turnOffLedJump);
  sCmd.addCommand("DashLedOn", turnOnLedDash);
  sCmd.addCommand("DashLedOff", turnOffLedDash);

}

void loop() {
  // put your main code here, to run repeatedly:
  if (Serial.available() > 0)
    sCmd.readSerial();

  
}

void turnOnLedJump (const char *command) {
  digitalWrite(ledJump, HIGH);   // Etat logique haut 1 (5 volts)
}

void turnOffLedJump (const char *command) {
  digitalWrite(ledJump, LOW);   // Etat logique haut 1 (5 volts)
}

void turnOnLedDash (const char *command) {
  digitalWrite(ledDash, HIGH);   // Etat logique haut 1 (5 volts)
}

void turnOffLedDash (const char *command) {
  digitalWrite(ledDash, LOW);   // Etat logique haut 1 (5 volts)
}
