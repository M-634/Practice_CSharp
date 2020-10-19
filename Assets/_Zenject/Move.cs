using UnityEngine;
using System.Collections;
using Zenject;

namespace Assets._Zenject
{
    public class Move : MonoBehaviour
    {
        [Inject]//Zenjectの影響を受けるようになる
        private IInputProbider m_inputProbider;

        [SerializeField] float m_speed = 5f;
        [SerializeField] float m_jumpPawer = 700f;

        Rigidbody m_rb;

        private void Start()
        {
            m_rb = GetComponent<Rigidbody>();
        }

        //public void SetInputProvider(IInputProbider input)
        //{
        //    m_inputProbider = input;
        //}

        // Update is called once per frame
        void Update()
        {
            float h = m_inputProbider.GetHorizontal();
            float v = m_inputProbider.GetVertical();

            m_rb.velocity = new Vector3(h, 0, v).normalized * m_speed;

            if (m_inputProbider.IsJump())
            {
                m_rb.AddForce(0, m_jumpPawer, 0);
            }
        }
    }
}