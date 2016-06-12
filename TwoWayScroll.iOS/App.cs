using MvvmCross.Platform.IoC;
using TwoWayScroll.iOS.ViewModels;

namespace TwoWayScroll.iOS
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<FirstViewModel>();
        }
    }
}

