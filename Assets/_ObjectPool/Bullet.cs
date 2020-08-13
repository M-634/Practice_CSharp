using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] float m_existenceTime = 1f;
        private void OnEnable()
        {
            StartCoroutine(SetFalse(m_existenceTime));
        }

        IEnumerator SetFalse(float time)
        {
            yield return new WaitForSeconds(time);
            gameObject.SetActive(false);
        }
    }
}
