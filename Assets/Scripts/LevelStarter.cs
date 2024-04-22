using UnityEngine;
using View.UI.Screens;

public class LevelStarter : MonoBehaviour
{
    private void Start()
    {
        SceneContext.I.TileService.CreateTiles();
        SceneContext.I.PlayerService.CreatePlayer();
        SceneContext.I.UIService.ShowScreen<GameplayHUDScreen>();


        Camera.main.GetComponent<CameraBrain>().SetTarget(SceneContext.I.PlayerService.PlayerView.gameObject);
    }
}