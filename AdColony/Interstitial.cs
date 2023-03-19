using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interstitial : MonoBehaviour
{
    string ZoneID = "vz88ed915fe44a4f9980";
    string AppId = "app5ee73cd9908c4750b0";

    // Start is called before the first frame update
    void Start()
    {
   
    }
     
    public void SHowintermore()
    {
        if (Application.platform == RuntimePlatform.Android ||
 Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Debug.Log("Init start");
            string[] zoneIds = new string[] { "vz6aa785f1dd9546fab8", "vz6aa785f1dd9546fab8" };
            AdColony.Ads.Configure(AppId, null, zoneIds);

            AdColony.InterstitialAd _ad = null;

            AdColony.Ads.OnRequestInterstitial += (AdColony.InterstitialAd ad) =>
            {
                Debug.Log("Requested");
                _ad = ad;
                AdColony.Ads.ShowAd(_ad);
            };

            AdColony.Ads.OnExpiring += (AdColony.InterstitialAd ad) =>
            {
                print("expiring");
                AdColony.Ads.RequestInterstitialAd(ZoneID, null);
            };
            AdColony.Ads.RequestInterstitialAd(ZoneID, null);
        }
    }
}