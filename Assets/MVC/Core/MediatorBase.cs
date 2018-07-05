using Zenject;
namespace ProjectR.MVC
{
    public abstract class MediatorBase<TView> where TView : IView
    {
        [Inject]
        protected TView view;
    }
}