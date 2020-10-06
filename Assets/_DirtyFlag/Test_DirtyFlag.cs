using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_DirtyFlag : MonoBehaviour
{
    public int m_clickCount = 0;
    [SerializeField] ChangeColor m_parent;//親オブジェクトをアサイン

    public void Excute()
    {
        if (m_clickCount == 0) return;
        m_parent.SubtractAlpha(m_clickCount * 0.1f);
    }
}
