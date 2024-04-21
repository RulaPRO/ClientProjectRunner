using Services.UIService.Implementation.UIUnits;

namespace Services.UIService.Interfaces
{
    public interface IUIService
    {
        TScreen GetScreen<TScreen>() where TScreen : UIScreen;
        TScreen ShowScreen<TScreen>() where TScreen : UIScreen;
        void HideScreen<TScreen>() where TScreen : UIScreen;
    }
}