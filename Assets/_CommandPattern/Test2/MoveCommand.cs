using CommandPattern.Test2;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace CommandPattern_Test2
{
    public class MoveCommand :ICommand
    {
        private Transform m_player;
        private float m_v;
        private float m_h;
        private float m_speed;

        public MoveCommand(Transform player,float v,float h,float speed)
        {
            m_player = player;
            m_v = v;
            m_h = h;
            m_speed = speed;
        }

        public void Execute()
        {
            var setPos = m_player.position;
            setPos.y += m_v * Time.deltaTime * m_speed;
            setPos.x += m_h * Time.deltaTime * m_speed;

            m_player.position = setPos;
        }

        public void Undo()
        {
            var setPos = m_player.position;
            setPos.y -= m_v * Time.deltaTime * m_speed;
            setPos.x -= m_h * Time.deltaTime * m_speed;

            m_player.position = setPos;
        }
    }
}

