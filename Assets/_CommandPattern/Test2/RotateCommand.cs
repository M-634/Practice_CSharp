using CommandPattern.Test2;
using System;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using UnityEngine;

namespace CommandPattern_Test2
{
    public class RotateCommand : ICommand
    {
        Transform m_player;
        float m_rotateValue_Z;

        public RotateCommand(Transform player,float rotaeValue_Z)
        {
            m_player = player;
            m_rotateValue_Z = rotaeValue_Z;
        }

        public void Execute()
        {
            m_player.Rotate(new Vector3(0, 0, m_rotateValue_Z));
        }

        public void Undo()
        {
            m_player.Rotate(new Vector3(0, 0, m_rotateValue_Z * -1));
        }
    }

}

