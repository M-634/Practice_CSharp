using UnityEngine;

public class Blue : Base
{
    public override void ChangeColor()
    {
        m_meshRenderer.material.color = Color.blue;
    }
}
