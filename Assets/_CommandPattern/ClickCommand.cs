using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class ClickCommand : ICommand
    {
        private GameObject m_cube;
        private Color m_color;
        private Color m_previousColor;


        public ClickCommand(GameObject cube, Color color)
        {
            this.m_cube = cube;
            this.m_color = color;
        }

        public void Execute()
        {
            //change the color of the cube to a random color
            m_previousColor = m_cube.GetComponent<MeshRenderer>().material.color;
            m_cube.GetComponent<MeshRenderer>().material.color = m_color;
        }

        public void Undue()
        {
            m_cube.GetComponent<MeshRenderer>().material.color = m_previousColor;
        }
    }
}
