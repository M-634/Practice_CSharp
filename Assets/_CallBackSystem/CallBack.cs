using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MyRoutine(() => 
        {
            Debug.Log("The Routine has finished");
        }
        ));
    }


    public IEnumerator MyRoutine(Action onCmplete = null)
    {
        yield return new WaitForSeconds(5.0f);

        onCmplete?.Invoke();
    }
}
