using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Observer
{
    public class Tank : MonoBehaviour
    {
        [SerializeField] int m_maxAmmo = 9999;
        [SerializeField] GameObject m_instanceAmmo;
        [SerializeField] Transform m_muzzle;
        [SerializeField] float m_shotPower = 100f;

        private int currentAmmo;

        //イベントの購読・発行を一元管理
        private Subject<int> ammoSubject = new Subject<int>();

        //イベントの購読側だけ公開する
        public IObservable<int> OnAmmoNumberChanged => ammoSubject;

        public int CurrentAmmo 
        {
            get => currentAmmo;
            private set 
            {
                currentAmmo = value;
                ammoSubject.OnNext(currentAmmo);//値が変化する度にイベントを発行する
            } 
        }

        void Start()
        {
            CurrentAmmo = m_maxAmmo;
        }

        void Update()
        {
            if (m_instanceAmmo && Input.GetMouseButtonDown(0))
            {
                var ammo = Instantiate(m_instanceAmmo, m_muzzle.position, Quaternion.identity);
                ammo.GetComponent<Rigidbody>().AddForce(m_muzzle.forward * m_shotPower);
                CurrentAmmo--;
            }
        }
    }
}