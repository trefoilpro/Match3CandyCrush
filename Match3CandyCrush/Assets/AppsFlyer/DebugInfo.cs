using System.Collections;
using System.Collections.Generic;
using AppsFlyerSDK;
using UnityEngine;

public class DebugInfo : MonoBehaviour, IAppsFlyerConversionData
{
    public void onConversionDataSuccess(string conversionData)
    {
        Debug.Log(conversionData);
    }

    public void onConversionDataFail(string error)
    {
        throw new System.NotImplementedException();
    }

    public void onAppOpenAttribution(string attributionData)
    {
        throw new System.NotImplementedException();
    }

    public void onAppOpenAttributionFailure(string error)
    {
        throw new System.NotImplementedException();
    }
}
