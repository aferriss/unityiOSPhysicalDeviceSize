using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class devicePhysicalSize : MonoBehaviour {

	// size returned is in meters
	public static float width;
	public static float height;
	public static Vector2 physicalSize;
	private Dictionary<string, int> DeviceNamesByCode;
	private string model;

	private const int UnknownDevice         = 0;
	private const int Simulator             = 1;								 
	private const int iPhone4               = 3;
	private const int iPhone4S              = 4;
	private const int iPhone5               = 5;
	private const int iPhone5C              = 6;
	private const int iPhone5S              = 7;
	private const int iPhone6               = 8;
	private const int iPhone6Plus           = 9;
	private const int iPhone6S              = 10;
	private const int iPhone6SPlus          = 11;
	private const int iPhone7               = 12;
	private const int iPhone7Plus           = 13;
	private const int iPhone8               = 14;
	private const int iPhone8Plus           = 15;
	private const int iPhoneX               = 16;
	private const int iPhoneSE              = 17;								 
	private const int iPad1                 = 18;
	private const int iPad2                 = 19;
	private const int iPadMini              = 20;
	private const int iPad3                 = 21;
	private const int iPad4                 = 22;
	private const int iPadAir               = 23;
	private const int iPadMini2             = 24;
	private const int iPadAir2              = 25;
	private const int iPadMini3             = 26;
	private const int iPadMini4             = 27;
	private const int iPadPro12Dot9Inch     = 28;
	private const int iPadPro9Dot7Inch      = 29;
	private const int iPad5                 = 30;
	private const int iPadPro12Dot9Inch2Gen = 31;
	private const int iPadPro10Dot5Inch     = 32;								 
	private const int iPodTouch1Gen         = 33;
	private const int iPodTouch2Gen         = 34;
	private const int iPodTouch3Gen         = 35;
	private const int iPodTouch4Gen         = 36;
	private const int iPodTouch5Gen         = 37;
	private const int iPodTouch6Gen 		 = 38;

	// iPhone/iPod touch
	private float kiPhone3_5InchScreenWidth = 0.0493f;
	private float kiPhone4_0InchScreenWidth = 0.0499f;
	private float kiPhone4_7InchScreenWidth = 0.0585f;
	private float kiPhone5_5InchScreenWidth = 0.0685f;
	private float kiPhone5_8InchScreenWidth = 0.070866f;
	private float kiPhone3_5InchScreenHeight = 0.0740f;
	private float kiPhone4_0InchScreenHeight = 0.0885f;
	private float kiPhone4_7InchScreenHeight = 0.1041f;
	private float kiPhone5_5InchScreenHeight = 0.1218f;
	private float kiPhone5_8InchScreenHeight = 0.14351f;

	// iPad
	private float kiPad7_9InchScreenWidth = 0.1204f;
	private float kiPad9_7InchScreenWidth = 0.1478f;
	private float kiPad10_5InchScreenWidth = 0.16f;
	private float kiPad12_9InchScreenWidth = 0.1965f;
	private float kiPad7_9InchScreenHeight = 0.1605f;
	private float kiPad9_7InchScreenHeight = 0.1971f;
	private float kiPad10_5InchScreenHeight = 0.2134f;
	private float kiPad12_9InchScreenHeight = 0.2622f;


	// Use this for initialization
	void Start () {
		model = SystemInfo.deviceModel;

		DeviceNamesByCode = new Dictionary<string, int>
		{
			{ "iPhone3,1"  , iPhone4 },
			{ "iPhone3,2"  , iPhone4 },
			{ "iPhone3,3"  , iPhone4 },
			{ "iPhone4,1"  , iPhone4S },
			{ "iPhone4,2"  , iPhone4S },
			{ "iPhone4,3"  , iPhone4S },
			{ "iPhone5,1"  , iPhone5 },
			{ "iPhone5,2"  , iPhone5 },
			{ "iPhone5,3"  , iPhone5C },
			{ "iPhone5,4"  , iPhone5C },
			{ "iPhone6,1"  , iPhone5S },
			{ "iPhone6,2"  , iPhone5S },
			{ "iPhone7,2"  , iPhone6 },
			{ "iPhone7,1"  , iPhone6Plus },
			{ "iPhone8,1"  , iPhone6S },
			{ "iPhone8,2"  , iPhone6SPlus },
			{ "iPhone8,4"  , iPhoneSE },
			{ "iPhone9,1"  , iPhone7 },
			{ "iPhone9,3"  , iPhone7 },
			{ "iPhone9,2"  , iPhone7Plus },
			{ "iPhone9,4"  , iPhone7Plus },
			{ "iPhone10,1" , iPhone8 },
			{ "iPhone10,4" , iPhone8 },
			{ "iPhone10,2" , iPhone8Plus },
			{ "iPhone10,5" , iPhone8Plus },
			{ "iPhone10,3" , iPhoneX },
			{ "iPhone10,6" , iPhoneX },
			{ "i386"       , Simulator },
			{ "x86_64"     , Simulator },

			{ "iPad1,1"  , iPad1 },
			{ "iPad2,1"  , iPad2 },
			{ "iPad2,2"  , iPad2 },
			{ "iPad2,3"  , iPad2 },
			{ "iPad2,4"  , iPad2 },
			{ "iPad2,5"  , iPadMini },
			{ "iPad2,6"  , iPadMini },
			{ "iPad2,7"  , iPadMini },
			{ "iPad3,1"  , iPad3 },
			{ "iPad3,2"  , iPad3 },
			{ "iPad3,3"  , iPad3 },
			{ "iPad3,4"  , iPad4 },
			{ "iPad3,5"  , iPad4 },
			{ "iPad3,6"  , iPad4 },
			{ "iPad4,1"  , iPadAir },
			{ "iPad4,2"  , iPadAir },
			{ "iPad4,3"  , iPadAir },
			{ "iPad4,4"  , iPadMini2 },
			{ "iPad4,5"  , iPadMini2 },
			{ "iPad4,6"  , iPadMini2 },
			{ "iPad4,7"  , iPadMini3 },
			{ "iPad4,8"  , iPadMini3 },
			{ "iPad4,9"  , iPadMini3 },
			{ "iPad5,1"  , iPadMini4 },
			{ "iPad5,2"  , iPadMini4 },
			{ "iPad5,3"  , iPadAir2 },
			{ "iPad5,4"  , iPadAir2 },
			{ "iPad6,3"  , iPadPro9Dot7Inch },
			{ "iPad6,4"  , iPadPro9Dot7Inch },
			{ "iPad6,7"  , iPadPro12Dot9Inch },
			{ "iPad6,8"  , iPadPro12Dot9Inch },
			{ "iPad6,11" , iPad5 },
			{ "iPad6,12" , iPad5 },
			{ "iPad7,1"  , iPadPro12Dot9Inch2Gen },
			{ "iPad7,2"  , iPadPro12Dot9Inch2Gen },
			{ "iPad7,3"  , iPadPro10Dot5Inch },
			{ "iPad7,4"  , iPadPro10Dot5Inch },

			{ "iPod1,1" , iPodTouch1Gen },
			{ "iPod2,1" , iPodTouch2Gen },
			{ "iPod3,1" , iPodTouch3Gen },
			{ "iPod4,1" , iPodTouch4Gen },
			{ "iPod5,1" , iPodTouch5Gen },
			{ "iPod7,1" , iPodTouch6Gen }
		};

//		Debug.Log (SystemInfo.deviceModel);
		getPhysicalSize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void getPhysicalSize(){
		int deviceCode;
		if (DeviceNamesByCode.ContainsKey (model)) {
			deviceCode = DeviceNamesByCode [model];
		
		switch ( deviceCode ) {
			case iPhone4S:
				width = kiPhone3_5InchScreenWidth;
				height = kiPhone3_5InchScreenHeight;
				break;

			case iPhone5:
			case iPhone5S:
			case iPhone5C:
			case iPhoneSE:
			case iPodTouch5Gen:
			case iPodTouch6Gen:
				width = kiPhone4_0InchScreenWidth;
				height = kiPhone4_0InchScreenHeight;
				break;

			case iPhone6:
			case iPhone6S:
			case iPhone7:
			case iPhone8:
				width = kiPhone4_7InchScreenWidth;
				height = kiPhone4_7InchScreenHeight;
				break;

			case iPhone6Plus:
			case iPhone6SPlus:
			case iPhone7Plus:
			case iPhone8Plus:
				width = kiPhone5_5InchScreenWidth;
				height = kiPhone5_5InchScreenHeight;
				break;

			case iPhoneX:
				width = kiPhone5_8InchScreenWidth;
				height = kiPhone5_8InchScreenHeight;
				break;

			case iPad2:
			case iPad3:
			case iPad4:
			case iPadAir:
			case iPadAir2:
			case iPadPro9Dot7Inch:
			case iPad5:
				width = kiPad9_7InchScreenWidth;
				height = kiPad9_7InchScreenHeight;
				break;

			case iPadMini:
			case iPadMini2:
			case iPadMini3:
			case iPadMini4:
				width = kiPad7_9InchScreenWidth;
				height = kiPad7_9InchScreenHeight;
				break;

			case iPadPro10Dot5Inch:
				width = kiPad10_5InchScreenWidth;
				height = kiPad10_5InchScreenHeight;
				break;

			case iPadPro12Dot9Inch:
			case iPadPro12Dot9Inch2Gen:
				width = kiPad12_9InchScreenWidth;
				height = kiPad12_9InchScreenHeight;
				break;

			default:
				// need to put something here that makes a more intelligent guess
				// magic numbers for iPhone SE screen size
				width = 0.1291f;
				height = 0.2295f;
				break;
			}
		} else {
			Debug.Log ("Device Keycode not found");
			// magic numbers for iPhone SE screen size
			width = 0.1291f;
			height = 0.2295f;
		}
			
		physicalSize = new Vector2 (width, height);
	}


}
