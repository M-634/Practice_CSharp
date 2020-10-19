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
           .Bind<IInputProbider>() //InputProvider‚ª‚ ‚é‚Æ‚« 
           .To<NormalInputProvider>() //InputProvider‚ğ’“ü‚·‚é
           .AsCached(); //¶¬Ï‚İ‚È‚çg‚¢‰ñ‚·
        }
    }
}
