using Services.UIService.Implementation.UIUnits;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace View.UI.Screens
{
    public class CompleteLevelScreen : UIScreen
    {
        [SerializeField] private Button buttonRestart;

        private void Start()
        {
            buttonRestart.onClick.AddListener( () => SceneManager.LoadScene("MainScene"));
        }
    }
}