
# RobotArm
This repository contains code for the Android app and Arduino used to control the robot arm. This was a lab project for Advanced Object-Oriented Programming, created by Alex Perr and Zach Snyder 

<img src="images/rc.PNG" style="width:50%">

## Hardware setup
An Arduino Uno is connected, via pins, to 3 H-Bridge modules (Adafruit TB6612). The H-Bridge modules are then connected to each of the 5 motors. 
The H-Bridge allows the motors to be bi-directional and to relay power from an external source to the motors. A HC-05 Bluetooth Reciever/Transmitter module is connected to the Arduino serial port Rx/Tx. The HC-05 module is connected to the Arduinos auxillary power. A battery pack with 2 AA batteries is connected to all 3 H-Bridge modules. There are 2 sets of pins programmed for each motor: One for clockwise and one for counter clockwise motion.  

<img src="images/setup.PNG" style="width:100%">

## Files
- AndroidApp
- Arduino 
