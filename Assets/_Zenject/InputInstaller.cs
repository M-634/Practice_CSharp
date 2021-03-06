using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace Assets._Zenject
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
           .Bind<IInputProbider>() //InputProviderがあるとき 
           .To<NormalInputProvider>() //InputProviderを注入する
           .AsCached(); //生成済みなら使い回す
        }
    }
}
