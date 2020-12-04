**# Include Firebase in Xamarin.Android**

**# Create project and include apps**

- After create Android project you want to create a Firebase project and include any app android.
[Create Project Firebase](https://console.firebase.google.com/u/0/)

**#Step 1: Create Xamarin.Form Project**

After create xamarin.form project in visual studio include the next nuggets:
|Description|Nuggets  |
|--|--|
|To receive messages from FCM   | Xamarin.Firebase.Messaging 60.1142.1 |
|--|--|
| Because Firebase Cloud Messaging depends on Google play services  | Xamarin.GooglePlayServices.Base 60.1142.1|


**#Step2:  Register App**

In firebase console you'll need register app with the package name project. 
- In visual studio right-click Properties>Package name. Example: **com.companyname.seed**

Note: this package name also serves as the application ID that is associated with the Api key

**#Step3:  Download configuration file**

From firebase console download the file 'google-services.json'
- Switch visual studio and include file in the app like a picture below:

**![](https://lh6.googleusercontent.com/UTeM-083dF5amOR7K_nqHNMeuMUvMgYS9AQCiVQAYFrt3fDexIJEw0Ny4ki8z07L3fAJkkZl0f_iALa0MEfUwbUFbQudE2xoJwxjbVjcVlpZHS9kXIHgeHrqjRKkFVydyCwbPS0)**
- Select google-services.json in the solution explorer windows and in the properties pane, set the build action to GoogleServices.Json

**![](https://lh5.googleusercontent.com/-DitpzMaixPSdBy3MgyuaBzAfeunssueSMsYMpbjKcwn2W9G6w6ctH7TV8jA6Px2rhP-g2ueaAfZOnquDjwYgl-sqwrFY8ktPiSoYjg1Swx2xZOvcEt5D5lY2Vekos2TWrxUSJQ)**

Note:  
- When google-services.json is added to the project (and the GoogleServicesJson build action is set), the build process extracts the client ID and Api key and then adds these credentials to the merged/generated AndroidManifest.xml  
This merge process automatically adds any permissions and other FCM element that are needed for connection to FCM servers

**#Step4:  Declare the receiver in the Android Manifest**
- Edit **AndroidManifest.xml** and insert the following <receiver>  elements into the  <application> section
		    
		<receiver
		  android:name="com.google.firebase.iid.FirebaseInstanceIdInternalReceiver"
			android:exported="false" />
		<receiver
			android:name="com.google.firebase.iid.FirebaseInstanceIdReceiver"
			android:exported="true"
			android:permission="com.google.android.c2dm.permission.SEND">
			<intent-filter>
				<action android:name="com.google.android.c2dm.intent.RECEIVE" />
				<action android:name="com.google.android.c2dm.intent.REGISTRATION" />
				<category android:name="${applicationId}" />
			</intent-filter>
		</receiver>

Note: 
This XML dos the following:
-   Declares a FirebaseInstanceIDReceiver implementation that provides a unique identifier for each app instance. This receiver also authenticates and authorizes actions
-   Declare an internal FirebaseInstanceIdInternalReceiver implementation that is used to start services sucerely
-   the appID is stored in the google-services.json file that was added to the project. Xamarin bindings will replace the token ${applicationId} with the app Id.
-   The FirebaseInstanceIdReceiver is a WakefulBroadcastReceiver that receives FirebaseInstanceId and FirebaseMessaging events and delivers them to the class that you derive from FirebaseInstanceIdService.

**#Step5:  Implement the Firebase instance ID Service**

The work of registering the application with FCM is handled by the custom FirebaseInstanceIdService service that you provide

Firebase InstanceIdService performs the following steps:
-   Uses the Instance ID API to generate security tokens that authorize the client app to access FCM and the app server. In return, the app gets back a registration token from FCM.
-   Forwards the registration token to the app server if the app server requires ir.

Add a new file called 'MyFirebaseIIDService.cs' and replace its template code with the following:

    using System;
	using Android.App;
	using Firebase.Iid;
	using Android.Util;

	namespace Seed.Droid
	{
	    [Service]
	    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
	    public class MyFirebaseIIDService : FirebaseInstanceIdService
	    {
	        const string TAG = "MyFirebaseIIDService";
	        public override void OnTokenRefresh()
	        {
	            var refreshedToken = FirebaseInstanceId.Instance.Token;
	            Log.Debug(TAG, "Refreshed token: " + refreshedToken);
	            SendRegistrationToServer(refreshedToken);
	        }
	        void SendRegistrationToServer(string token)
	        {
	            // Add custom implementation, as needed.
	        }
	    }
	}
Note:
-   This service implements an OnTokenRefresh method that is invoked when the registration token is initially created or changed. When OnTokenRefresh runs, it retrieves the latest token from the FirebaseInstanceId.Instance.Token property (which is updated asynchronously by FCM)
-   OnTokenRefresh is invoked infrequently: is is used to update the token under the following circumstances:
    -   When the app is installed or unistalled
    -   When the user deletes app data
    -   When the app erases the instance ID
    -   When the security of the token has been compromised.
  -   According to Google's [Instance ID](https://developers.google.com/instance-id/guides/android-implementation) documentation, the FCM Instance ID service will request that the app refresh its token periodically (typically, every 6 months). 
-   OnTokenRefresh also calls SendRegistrationToAppServer to associate the user's registration token with the server-side account
- **Notice that OnTokenRefres() logged in console Token, this will use in the next step.**

**#Step6:  Send a message**

To send a message sing into the firebase and **Increase>Cloud Messaging > new Notification > Send test message** and in “Add an FCM Registration Token” add the token previously generated and shown in Output debug console
