using UniRx;
using Zenject;

namespace ProjectR.MVC.HomeScene
{
    public class InfoPanelMediator : MediatorBase<InfoPanelView>, IInitializable
    {
        [Inject] private HomeSceneEvents.OnConnecting onConEvent;
        [Inject] private HomeSceneEvents.OnConnected onConedEvent;
        [Inject] private InfoPanelView view;
        public void Initialize()
        {
            view.HideButton();
            onConEvent.AsObservable().Subscribe(_ => OnConting("Connecting...")).AddTo(view);
            onConedEvent.AsObservable().Subscribe(_ => OnConed()).AddTo(view);
        }                                
        
        public void OnConting(string info)
        {
            view.Display(info);
        }        
        
        public void OnDisplay(string info, string buttonInfo, UnityEngine.Events.UnityAction buttonClbk)
        {
            view.Display(info, buttonInfo, buttonClbk);
        }

        public void OnConed()
        {
            view.Hide();
        }
    }
}