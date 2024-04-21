using System;
using System.Collections.Generic;
using Factories;
using Services.UIService.Implementation.UIUnits;
using Services.UIService.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.UIService.Implementation
{
    public class UIService : IUIService, IDisposable
    {
        private const string ROOT_CANVAS_PREFAB_PATH = "UI/RootCanvas";

        private readonly Dictionary<Type, UIScreen> createdScreens = new Dictionary<Type, UIScreen>();

        private readonly UIFactory uiFactory = new UIFactory();

        private UIScreen activeScreen;

        public RootCanvas RootCanvas { get; }

        public UIService()
        {
            var rootCanvasPrefab = Resources.Load<RootCanvas>(ROOT_CANVAS_PREFAB_PATH);
            RootCanvas = Object.Instantiate(rootCanvasPrefab);
            Object.DontDestroyOnLoad(RootCanvas);
        }

        public void Dispose()
        {
            if (RootCanvas)
            {
                Object.Destroy(RootCanvas.gameObject);
            }
        }

        public TScreen GetScreen<TScreen>() where TScreen : UIScreen
        {
            if (!createdScreens.ContainsKey(typeof(TScreen)))
            {
                createdScreens.Add(typeof(TScreen), uiFactory.CreateScreen<TScreen>(RootCanvas.transform));
            }

            return createdScreens[typeof(TScreen)] as TScreen;
        }

        public TScreen ShowScreen<TScreen>() where TScreen : UIScreen
        {
            var screenType = typeof(TScreen);
            if (activeScreen != null && activeScreen.GetType() == screenType)
            {
                return activeScreen as TScreen;
            }

            if (activeScreen != null)
            {
                activeScreen.Hide();
            }

            activeScreen = GetScreen<TScreen>();
            activeScreen.Show();

            return activeScreen as TScreen;
        }

        public void HideScreen<TScreen>() where TScreen : UIScreen
        {
            GetScreen<TScreen>().Hide();
        }
    }
}