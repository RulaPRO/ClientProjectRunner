using System;

namespace Services
{
    public class AdsService
    {
        public void ShowRewardedAds(Action onAdRewarded)
        {
            onAdRewarded?.Invoke();
        }
    }
}