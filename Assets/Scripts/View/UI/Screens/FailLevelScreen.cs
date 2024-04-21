using Services.UIService.Implementation.UIUnits;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace View.UI.Screens
{
    public class FailLevelScreen : UIScreen
    {
        [SerializeField] private Button buttonADS;
        [SerializeField] private Button buttonRestart;

        private void Start()
        {
            buttonADS.onClick.AddListener(OnButtonAdsClick);
            buttonRestart.onClick.AddListener(OnButtonRestartClick);
        }

        private void OnButtonAdsClick()
        {
            SceneContext.I.AdsService.ShowRewardedAds(() =>
            {
                SceneContext.I.UIService.ShowScreen<GameplayHUDScreen>();
                SceneContext.I.PlayerService.RespawnPlayer();
            });
        }

        private void OnButtonRestartClick()
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}