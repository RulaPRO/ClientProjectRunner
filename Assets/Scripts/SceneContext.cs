using GameConfig;
using Services;
using Services.Player;
using Services.Tiles;
using Services.UIService.Implementation;
using Services.UIService.Interfaces;
using UnityEngine;

public class SceneContext
{
    private static SceneContext i;
    public static SceneContext I => i ??= new SceneContext();

    public PlayerService PlayerService { get; }
    public TileService TileService { get; }
    public IUIService UIService { get; }
    public AdsService AdsService { get; }
    public Config Config { get; }

    private SceneContext()
    {
        Config = Resources.Load<Config>("Config");

        PlayerService = new PlayerService();
        TileService = new TileService();
        UIService = new UIService();
        AdsService = new AdsService();
    }
}