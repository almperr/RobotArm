//Names: Alexander Perr and Zach Snyder
//Class: ECET 499
//Date: 4/30/2018
//Discription: This program sends characters via Bluetooth corresponding with each of the buttons to the Arduino. 

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
        
	//Variable declaration, links variables to button object classes created in Xamirin for GUI
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
	    
	    //action for if Bluetooth connect button is pressed
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
		
		//could put "searching" text here
                catch (Exception deviceEX)
                {
                    // Can add message lateron
                }
		
		//if no Bluetooth found, cancel discovery
                myConnection.thisAdapter.CancelDiscovery();

                _socket = myConnection.thisDevice.CreateInsecureRfcommSocketToServiceRecord(Java.Util.UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));
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

            motor1On.Click += delegate
            {

                try
                {
                    // Send a 1 from this event.
                    myConnection.thisSocket.OutputStream.WriteByte(1);
                    myConnection.thisSocket.OutputStream.Close();
                }
                catch (Exception outPutEX)
                {
                }

            };

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


