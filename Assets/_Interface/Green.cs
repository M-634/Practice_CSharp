using UnityEngine;

public class Green : Base
{
    public override void ChangeColor()
    {
        m_meshRenderer.material.color = Color.green;
    }
}
