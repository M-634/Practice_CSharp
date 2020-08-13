using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

namespace ObjectPool
{
    public class PoolManager : MonoBehaviour
    {
        List<GameObject> m_poolList = new List<GameObject>();
        [SerializeField] GameObject m_poolObject = default;
        [SerializeField] int m_generateNumber = 10;

        public static PoolManager instance;
        public static PoolManager Instance 
        {
            get 
            {
                return instance;
            } 
        }


        //simple singlton
        private void Awake()
        {
            if (instance != null && instance == this)
            {
                Destroy(gameObject);
            }
            instance = this;
        }

        private void Start()
        {
            for (int i = 0; i < m_generateNumber; i++)
            {
                GameObject go = Instantiate(m_poolObject);
                go.transform.parent = transform;
                go.SetActive(false);
                m_poolList.Add(go);
            }
        }

        public GameObject SearchPool(GameObject go)
        {
            if (go != m_poolObject)
            {
                Debug.LogError("This Object isn't poolObject");
                return null;
            }

            foreach (var oldObj in m_poolList)
            {
                if (oldObj.activeSelf == false)
                {
                    oldObj.SetActive(true);
                    return oldObj;
                }
            }

            GameObject newObj = Instantiate(m_poolObject);
            newObj.transform.parent = transform;
            m_poolList.Add(newObj);
            return newObj;
        }
    }

}
