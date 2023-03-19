using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewarded : MonoBehaviour
{
    string ZoneID = "vz4f754a78010142cc97";
    string AppId = "app5ee73cd9908c4750b0";

    // Start is called before the first frame update
    void Start()
    {
   
    }
     
    public void Showrewarded()
    {
        if (Application.platform == RuntimePlatform.Android ||
 Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Debug.Log("Init start");
            string[] zoneIds = new string[] { "vz347fb741a6ed4de189", "vz347fb741a6ed4de189" };
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