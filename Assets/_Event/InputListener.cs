using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using UnityEngine.XR.WSA.Input;

namespace Practice_Event
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] UnityEvent m_onButtonDown;
        [SerializeField] UnityEvent m_onButtonUp;
        [SerializeField] Input Input;

        private void Start()
        {
            m_onButtonDown.AddListener(() => Debug.Log("press"));
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_onButtonDown.Invoke();
            }
            else if(Input.GetMouseButtonUp(0))
            {
                m_onButtonUp.Invoke();
            }
        }

    }
}

