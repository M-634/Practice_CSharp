using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColor : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] ChangeColor m_child;
    private MeshRenderer m_rendere;
    [SerializeField] float m_substractAlphaValue = 0.1f;

    private void Awake()
    {
        m_rendere = GetComponent<MeshRenderer>();
        if (m_child == this) m_child = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //ここでクリック回数だけを保存する
        FindObjectOfType<Test_DirtyFlag>().m_clickCount++;
        //SubtractAlpha(m_substractAlphaValue);
    }

    public void SubtractAlpha(float value)
    {
        var setColor = m_rendere.material.color;
        setColor.b -= value;

        m_rendere.material.color = setColor;

        if (m_child != null)
        {
            m_child.SubtractAlpha(value * 0.5f);
        }

        Debug.Log("ChangeColor");
    }
}
