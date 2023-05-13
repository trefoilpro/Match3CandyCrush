using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using AppsFlyerSDK;
using UnityEngine.UI;

// This class is intended to be used the the AppsFlyerObject.prefab

public class AppsFlyerObjectScript : MonoBehaviour , IAppsFlyerConversionData
{

    public Text First;
    public Text Sec;
    public Text Thr;
    // These fields are set from the editor so do not modify!
    //******************************//
    public string devKey;
    public string appID;
    public string UWPAppID;
    public string macOSAppID;
    public bool isDebug;
    public bool getConversionData;
    //******************************//


    void Start()
    {
        // These fields are set from the editor so do not modify!
        //******************************//
        AppsFlyer.setIsDebug(isDebug);
        Test(First);
#if UNITY_WSA_10_0 && !UNITY_EDITOR
        AppsFlyer.initSDK(devKey, UWPAppID, getConversionData ? this : null);
#elif UNITY_STANDALONE_OSX && !UNITY_EDITOR
    AppsFlyer.initSDK(devKey, macOSAppID, getConversionData ? this : null);
#else
        AppsFlyer.initSDK(devKey, appID, getConversionData ? this : null);
#endif
        //******************************/
      
       // AppsFlyer.startSDK();
       
        Test(Sec);

        AppsFlyer.startSDK();
      
        Test(Thr);
    }

    private static void Test(Text text)
    {
        string appsFlyerUID = AppsFlyer.getAppsFlyerId();
        if (!string.IsNullOrEmpty(appsFlyerUID))
        {
            text.text = "AppsFlyer UID: " + appsFlyerUID;
            Debug.Log("AppsFlyer UID: " + appsFlyerUID);
        }
        else
        {
            text.text = "Failed to get AppsFlyer UID";
            Debug.LogWarning("Failed to get AppsFlyer UID");
        }
    }


    void Update()
    {

    }

    // Mark AppsFlyer CallBacks
    public void onConversionDataSuccess(string conversionData)
    {
        AppsFlyer.AFLog("didReceiveConversionData", conversionData);
        Dictionary<string, object> conversionDataDictionary = AppsFlyer.CallbackStringToDictionary(conversionData);

        // add deferred deeplink logic here
    }

    public void onConversionDataFail(string error)
    {
        AppsFlyer.AFLog("didReceiveConversionDataWithError", error);
    }

    public void onAppOpenAttribution(string attributionData)
    {
        AppsFlyer.AFLog("onAppOpenAttribution", attributionData);
        Dictionary<string, object> attributionDataDictionary = AppsFlyer.CallbackStringToDictionary(attributionData);
        // add direct deeplink logic here
    }

    public void onAppOpenAttributionFailure(string error)
    {
        AppsFlyer.AFLog("onAppOpenAttributionFailure", error);
    }

}
