using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //left click
        //cast a ray
        // detect a cube
        // asign random color

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray,out hitInfo))
            {
                if (hitInfo.collider.tag == "Cube")
                {
                    //execute click command
                    ICommand click = new ClickCommand(hitInfo.collider.gameObject, new Color(Random.value, Random.value, Random.value));
                    click.Execute();
                }
            }
        }
    }
}
