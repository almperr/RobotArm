//Names: Alexander Perr and Zach Snyder
//Class: ECET 499 Advanced Object-Oriented Programming
//Date: 4/30/2018
//Discription: This is C# code that sends integer values to the Arduino via Bluetooth. This creates the GUI, does Bluetooth ops, and logic //behind controls

using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Bluetooth;
using System.Linq;

namespace RobotArm_Lab10.Droid
{
    [Activity(Label = "RobotArm_Lab10", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
	//initialize Bluetooth
        BluetoothConnection myConnection = new BluetoothConnection();
        
	//Variable declaration, links variables to button object classes created in Xamirin for the GUI
	protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Get our buttons from the layout resource
            Button buttonConnect = FindViewById<Button>(Resource.Id.button1);
            Button buttonDisconnect = FindViewById<Button>(Resource.Id.button2);
            Button motor1On = FindViewById<Button>(Resource.Id.button3);
            Button motor2On = FindViewById<Button>(Resource.Id.button4);
            Button motor3On = FindViewById<Button>(Resource.Id.button5);
            Button motor4On = FindViewById<Button>(Resource.Id.button6);
            Button motor5On = FindViewById<Button>(Resource.Id.button7);
            Button Forward  =  FindViewById<Button>(Resource.Id.button8);
            Button Backward = FindViewById<Button>(Resource.Id.button9);

            TextView connected = FindViewById<TextView>(Resource.Id.textView1);

            BluetoothSocket _socket = null;
	    
	    //action if Bluetooth connect button is pressed
            buttonConnect.Click += delegate
            {
                /* Call BluetoothConnection class methods and start the discovery of
                Bluetooth devices.
                For this to work when running, Phone must already be paired with
                Bluetooth module HC-05…*/

                myConnection = new BluetoothConnection();
                myConnection.getAdapter();
                myConnection.thisAdapter.StartDiscovery();
		
		//search for Bluetooth
                try
                {
                    myConnection.getDevice();
                    myConnection.thisDevice.SetPairingConfirmation(false);

                    myConnection.thisDevice.SetPairingConfirmation(true);
                    myConnection.thisDevice.CreateBond();
                }
                catch (Exception deviceEX)
                {
                    // Can add message lateron
                }
		
		//Bluetooth found, cancel discovery
                myConnection.thisAdapter.CancelDiscovery();
		
		//assign found device connection information to socket reference variable
                _socket = myConnection.thisDevice.CreateInsecureRfcommSocketToServiceRecord(Java.Util.UUID.FromString("00001101-0000-1000-8000			-00805f9b34fb"));
                
		// connection established, create bonded socket
		myConnection.thisSocket = _socket;

                try
                {

                    myConnection.thisSocket.Connect();
                    connected.Text = "Connected!";
                    buttonDisconnect.Enabled = true;
                    buttonConnect.Enabled = false;
                }
                catch (Exception CloseEX)
                {
                    // ADD MESSAGE LATER
                }
		
            };
            
	    // disconnect button pressed, disconnects from HC-05 Bluetooth Module 
            buttonDisconnect.Click += delegate
            {

                try
                {
                    buttonConnect.Enabled = true;
                    myConnection.thisSocket.OutputStream.WriteByte(187);
                    myConnection.thisSocket.OutputStream.Close();
                    myConnection.thisSocket.Close();
                    myConnection.thisDevice.Dispose();
                    myConnection = new BluetoothConnection();
                    _socket = null;
                    connected.Text = "Disconnected!";
                }
                catch { }

            };
	    
	    //controls claw 
            motor1On.Click += delegate
            {

                try
                {
                    // Send a 1 from this event to serial output.
                    myConnection.thisSocket.OutputStream.WriteByte(1);
                    myConnection.thisSocket.OutputStream.Close();
                }
                catch (Exception outPutEX)
                {
                }

            };
	    
	    //controls wrist
            motor2On.Click += delegate
            {

                
                try
                {

                    myConnection.thisSocket.OutputStream.WriteByte(2);
                    myConnection.thisSocket.OutputStream.Close();
                }
                catch (Exception outPutEX)
                {
                }

            };
	    
	    //controls elbow 
            motor3On.Click += delegate
            {
                try
                {
                    
                    myConnection.thisSocket.OutputStream.WriteByte(3);
                    myConnection.thisSocket.OutputStream.Close();
                }
                catch (Exception outPutEX)
                {
                }

            };
	    
	    //controls shoulder
            motor4On.Click += delegate
            {
                try
                {

                    myConnection.thisSocket.OutputStream.WriteByte(4);
                    myConnection.thisSocket.OutputStream.Close();
                }
                catch (Exception outPutEX)
                {
                }

            };
	    
            //rotates whole arm
            motor5On.Click += delegate
            {
                try
                {

                    myConnection.thisSocket.OutputStream.WriteByte(5);
                    myConnection.thisSocket.OutputStream.Close();
                }
                catch (Exception outPutEX)
                {
                }

            };
	    
	    //forward motor direction select button
            Forward.Click += delegate
            {

                try
                {
                   
                    myConnection.thisSocket.OutputStream.WriteByte(6);
                    myConnection.thisSocket.OutputStream.Close();
                }
                catch (Exception outPutEX)
                {
                }

            };
	    
	    //backwar motor direction select button
            Backward.Click += delegate
            {
                try
                {
                    myConnection.thisSocket.OutputSteam.WriteByte(7);
                }
                catch (Exception outPutEX)
                {

                }
            };

	    //logic for controlling a set of two motors
            (motor5On.Click & motor4On.Click) += delegate
            {
                try
                {
                    myConnection.thisSocket.OutputStream.WriteByte(8);
                }
                catch(Exeption outPutEX)
                {

                }
            };

        }
    }

    public class BluetoothConnection
    {
        public void getAdapter()
        {
            this.thisAdapter = BluetoothAdapter.DefaultAdapter;
        }

        public void getDevice()
        {
            this.thisDevice = (from bd in this.thisAdapter.BondedDevices
                               where bd.Name == "HC-05"
                               select bd).FirstOrDefault();
        }

        public BluetoothAdapter thisAdapter { get; set; }
        public BluetoothDevice thisDevice { get; set; }
        public BluetoothSocket thisSocket { get; set; }
    }
}


