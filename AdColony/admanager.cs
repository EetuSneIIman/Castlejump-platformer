using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class admanager : MonoBehaviour
{
    string ZoneIds = "vz4608de0f1b2644f984";
    string AppId = "app5ee73cd9908c4750b0";

    public string sceneName;
    public GameObject TestText;
    
    void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        sceneName = currentScene.name;

        if (sceneName == "Menu")
        {
            ShowAd();
            TestText.SetActive(true);
        }
        else
        {
            HideAd();
            TestText.SetActive(false);
        }
    }
    
    void Start()
    {
    //    if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
  //      {
            string[] zoneIds = new string[] { ZoneIds, ZoneIds };
            AdColony.Ads.Configure(AppId, null, zoneIds);
            AdColony.Ads.RequestAdView(ZoneIds, AdColony.AdSize.Banner, AdColony.AdPosition.Bottom, null);
     //   };
        
    }

    public void ShowAd()
    {
        AdColony.AdColonyAdView adView;
        AdColony.Ads.OnAdViewLoaded += (AdColony.AdColonyAdView ad) =>
        {
            adView = ad;
            adView.ShowAdView();
            
        };
    }

    public void HideAd()
    {
        AdColony.AdColonyAdView adView;
        AdColony.Ads.OnAdViewLoaded += (AdColony.AdColonyAdView ad) =>
        {
            adView = ad;
            adView.DestroyAdView();
        };
        
    }
}
