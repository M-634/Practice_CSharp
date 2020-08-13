using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class Player : MonoBehaviour
    {
        [SerializeField] GameObject m_bulletPrefab = default;
        public bool hasPool;//test

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (hasPool)
                {
                    PoolManager.Instance.SearchPool(m_bulletPrefab);
                }
                else
                {
                    Instantiate(m_bulletPrefab);
                }
            }
        }
    }

}

