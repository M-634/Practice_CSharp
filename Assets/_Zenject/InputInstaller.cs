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
           .Bind<IInputProbider>() //InputProvider������Ƃ� 
           .To<NormalInputProvider>() //InputProvider�𒍓�����
           .AsCached(); //�����ς݂Ȃ�g����
        }
    }
}
