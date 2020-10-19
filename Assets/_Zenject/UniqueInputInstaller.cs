using Assets._Zenject;
using UnityEngine;
using Zenject;

namespace Assets._Zenject
{
    public class UniqueInputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
            .Bind<IInputProbider>()
            .To<UniqueInputProvider>()
            .AsCached();
        }
    }
}