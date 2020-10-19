using UnityEngine;
using System.Collections;

namespace Assets._Zenject
{
    /// <summary>
    /// 入力とは逆方向に動く。ジャンプはしない
    /// </summary>
    public class UniqueInputProvider : IInputProbider
    {
        public float GetHorizontal()
        {
            return Input.GetAxis("Horizontal") * -1;
        }

        public float GetVertical()
        {
            return Input.GetAxis("Vertical") * -1;
        }

        public bool IsJump()
        {
            //return Input.GetKeyDown(KeyCode.Space);
            return false;
        }
    }
}