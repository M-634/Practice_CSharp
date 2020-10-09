using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public abstract class Base :MonoBehaviour,IColorChangeable,IPointerClickHandler
{
    protected MeshRenderer m_meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChangeColor();
    }

    public abstract void ChangeColor();
}

//IPointerClickHandler Not Working Checklist
//Added EventSystem game object to scene (Create -> UI -> Event System)

//Camera has a Physics Raycaster (Select Main Camera, Add Component -> Event -> Physics Raycaster)

//Selectable object is a MonoBehavior - derived class that implements IPointerClickHandler, IPointerDownHandler, and IPointerUpHandler (see accepted answer).

//Selectable game object includes selectable object MonoBehavior script.

//Selectable game object includes a collider (box, mesh, or any other collider type).

//Check Raycaster Event Mask vs. game object's Layer mask

//Verify no collider (possibly without a mesh) is obscuring the selectable game object.

//If collider is a trigger, verify that Queries Hit Triggers is enabled in Physics settings.


