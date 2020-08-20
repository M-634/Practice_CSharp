using UnityEngine;

namespace Practice_Event
{
    /// <summary>
    /// イベントを受けるクラス
    /// </summary>
    public class Receiver : MonoBehaviour
    {
        private void Start()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            //イベントの購買(subscribe)
            Sender.OnSomeEvent += SomeMethod;
            Debug.Log("subcribe event...");
        }

        private void UnSubcribe()
        {
            //イベントへの登録を解除
            Sender.OnSomeEvent -= SomeMethod;
            Debug.Log("unSubcribe event...");
        }


        private void SomeMethod()
        {
            Debug.Log("SomeMethod");
        }
    }
}

