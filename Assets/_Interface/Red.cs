using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : Base
{
    public override void ChangeColor()
    {
        m_meshRenderer.material.color = Color.red;
    }
}
