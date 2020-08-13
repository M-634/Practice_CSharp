using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CommandPattern
{
    public class CommandManager : MonoBehaviour
    {
        private static CommandManager m_instance;
        public static CommandManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    Debug.LogError("The CommandManager is NULL");
                }
                return m_instance;
            }
        }

        private List<ICommand> m_commandBuffer = new List<ICommand>();

        private void Awake()
        {
            if (m_instance != null && m_instance == this)
            {
                Destroy(gameObject);
            }
            m_instance = this;
        }

        //create a method to add command to the command buffer
        public void AddCommand(ICommand command)
        {
            m_commandBuffer.Add(command);
        }

        //create a play routine by a play method that's going to play back all the commands
        //1 second delay
        public void PlayCommand()
        {
            if (m_commandBuffer.Count == 0)
                return;

            StartCoroutine(PlayRoutine());
        }

        IEnumerator PlayRoutine()
        {
            foreach (var c in m_commandBuffer)
            {
                c.Execute();
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }

        public void Rewind()
        {
            if (m_commandBuffer.Count == 0)
                return;

            StartCoroutine(RewindRoutine());
        }

        IEnumerator RewindRoutine()
        {
            foreach (var c in Enumerable.Reverse(m_commandBuffer))
            {
                c.Undue();
                yield return new WaitForSeconds(1f);
            }
        }


        //Done = Finished with changing colors,Turn them all white
        public void Finish()
        {
            var cubes = GameObject.FindGameObjectsWithTag("Cube");
            foreach (var cube in cubes)
            {
                cube.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }

        //Reset - Clear command buffer
        public void Reset()
        {
            m_commandBuffer.Clear();
        }

    }
}
