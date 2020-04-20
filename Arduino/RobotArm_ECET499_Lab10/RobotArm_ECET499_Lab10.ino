/*
 Name:		RobotArm_ECET499_Lab10.ino
 Created:	4/20/2018 4:00:03 PM
 Author:	Zach Snyder and Alex Perr
 Purpose: This is used to program an Arduino to receive data from a Bluetooth receiver module and then activate different drive
 modules based on the input received. Inputs are from the Android phone, which is connected to the Bluetooth receiver. These 
 drive modules are connected to the different motors in the robot arm which drive the claw, the wrist, the elbow, and shoulder 
 of the arm.  
*/




//motor A connected between A01 and A02
//motor B connected between B01 and B02

unsigned int ForwardBackward = 0;

unsigned int received = 180;

void setup() {
	
	Serial.begin(9600);

	pinMode(13, OUTPUT);

	pinMode(2, OUTPUT);
	pinMode(3, OUTPUT);

	pinMode(4, OUTPUT);
	pinMode(5, OUTPUT);

	pinMode(6, OUTPUT);
	pinMode(7, OUTPUT);

	pinMode(8, OUTPUT);
	pinMode(9, OUTPUT);

	pinMode(10, OUTPUT);
	pinMode(11, OUTPUT);

	digitalWrite(13, HIGH);
}

void loop() 
{
	if (Serial.available())
	{
		received = Serial.read();

		if (received == 187)
		{
			Serial.write(received);
			delay(250);

			digitalWrite(13, LOW);
			delay(100);
			Serial.println("RESTARTED");
			digitalWrite(13, HIGH);
		}
		else if (received == 6)
		{
			ForwardBackward = 1;
		}
		else if (received == 7)
		{
			ForwardBackward = 0;
		}


		if (ForwardBackward == 1)
		{

			switch (received)
			{
			case (1):
				digitalWrite(2, LOW);
				digitalWrite(3, HIGH);
				Serial.println("1");
				delay(200);
				digitalWrite(2, LOW);
				digitalWrite(3, LOW);
				break;
			case (2):
				digitalWrite(4, HIGH);
				digitalWrite(5, LOW);
				Serial.println("2");
				delay(200);
				digitalWrite(4, LOW);
				digitalWrite(5, LOW);
				break;
			case (3):
				digitalWrite(6, LOW);
				digitalWrite(7, HIGH);
				Serial.println("JOINT 3 CLOCK");
				delay(200);
				digitalWrite(6, LOW);
				digitalWrite(7, LOW);
				break;
			case (4):
				digitalWrite(8, HIGH);
				digitalWrite(9, LOW);
				Serial.println("JOINT 4 CLOCK");
				delay(200);
				digitalWrite(8, LOW);
				digitalWrite(9, LOW);
				break;
			case (5):
				digitalWrite(10, HIGH);
				digitalWrite(11, LOW);
				Serial.println("JOINT 4 CLOCK");
				delay(200);
				digitalWrite(10, LOW);
				digitalWrite(11, LOW);
				break;
			}

		}

		if (ForwardBackward == 0)
		{
			switch (received)
			{
			case (1):
				digitalWrite(2, HIGH);
				digitalWrite(3, LOW);
				Serial.println("JOINT 1 ANTICLOCK");
				delay(200);
				digitalWrite(2, LOW);
				digitalWrite(3, LOW);
				break;
			case (2):
				digitalWrite(4, LOW);
				digitalWrite(5, HIGH);
				Serial.println("JOINT 2 CLOCK");
				delay(200);
				digitalWrite(4, LOW);
				digitalWrite(5, LOW);
				break;
			case (3):
				digitalWrite(6, HIGH);
				digitalWrite(7, LOW);
				Serial.println("JOINT 3 CLOCK");
				delay(200);
				digitalWrite(6, LOW);
				digitalWrite(7, LOW);
				break;
			case (4):
				digitalWrite(8, LOW);
				digitalWrite(9, HIGH);
				Serial.println("JOINT 4 CLOCK");
				delay(200);
				digitalWrite(8, LOW);
				digitalWrite(9, LOW);
				break;
			case (5):
				digitalWrite(10, LOW);
				digitalWrite(11, HIGH);
				Serial.println("JOINT 4 CLOCK");
				delay(200);
				digitalWrite(10, LOW);
				digitalWrite(11, LOW);
				break;
			}
			}

		}
	}


