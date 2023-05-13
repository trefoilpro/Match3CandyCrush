using System.Collections;
using System.Collections.Generic;
using AppsFlyerSDK;
using UnityEngine;

public class AppsFlyerScript : MonoBehaviour
{
    void OnEnable()
    {
        AppsFlyer.setGCMProjectNumber("YOUR_GCM_PROJECT_NUMBER");
        AppsFlyer.init("YOUR_DEV_KEY", "YOUR_APP_ID");
        AppsFlyer.setIsDebug(true);
        AppsFlyer.loadConversionData("OnConversionDataSuccess", "OnConversionDataFail");
    }

    void OnDisable()
    {
        AppsFlyer.stopSDK();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            AppsFlyer.onAppPaused();
        }
        else
        {
            AppsFlyer.onAppResumed();
        }
    }

    void OnConversionDataSuccess(Dictionary<string, object> conversionData)
    {
        Debug.Log("Successful conversion data received: " + conversionData.ToString());
    }
}
