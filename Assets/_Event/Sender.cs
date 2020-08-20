using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Practice_Event
{
    /// <summary>
    /// イベントを発行するクラス
    /// </summary>
    public class Sender : MonoBehaviour
    {
        ///<summary>イベントハンドラ</summary>
        public delegate void EventHandler();
        ///<summary>イベント</summary>
        public static event EventHandler OnSomeEvent;

        /// <summary>
        /// イベント実行
        /// </summary>
        protected virtual void Execute()
        {
            OnSomeEvent?.Invoke();

            //if (OnSomeEvent != null)
            //{
            //    OnSomeEvent();
            //}
        }
    }
}

