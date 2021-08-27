using System.Collections;
using UnityEngine;
using TMPro;

namespace DesignPatterns.Observer
{
    public class AmmoViewer : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI m_ammoCounter;
        [SerializeField] Tank m_tank;

        private void Awake()
        {
            //TankクラスのCurrentAmmoプロパティの値が変化するたびに、登録した下記の匿名関数が呼ばれる。
            m_tank.OnAmmoNumberChanged.Subscribe((ammo) =>
            {
                m_ammoCounter.text = $"ammo counter:{ammo}";
            });
        }
    }
}