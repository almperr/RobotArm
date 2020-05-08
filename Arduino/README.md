# RobotArm-Arduino
This is used to program an Arduino to receive data from the HC-05 Bluetooth receiver module and then activate different TB6612 drive modules based on the input received. Inputs are from the Android phone, which is connected to the Bluetooth receiver. These 
 drive modules are connected to the different motors in the robot arm which drive the claw, the wrist, the elbow, and shoulder 
 of the arm.  

## Files

RobotArm_ECET_499_Lab10/RobotArm_ECET_499_Lab10.ino
  - Contains logic for receiving data and processing different inputs from Android Phone
  - Sends output to the various H-Bridge chipsets to drive the motors 
