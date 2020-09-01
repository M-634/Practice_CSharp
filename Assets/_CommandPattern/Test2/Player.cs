using UnityEngine;
using System.Collections;
using CommandPattern_Test2;
using System.Data;

namespace CommandPattern.Test2
{
    public class Player : MonoBehaviour
    {
        [SerializeField] float m_speed = 2f;
        [SerializeField] float m_rotate_Z;
        ICommand[] commands;

        // Update is called once per frame
        void Update()
        {
            if (CommandManager.Instance.m_isLocked)
                return;

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            var move = new MoveCommand(this.transform, v, h, m_speed);
            //move.Execute();

            //(回転と移動)の同時押し
            if (Input.GetKeyDown(KeyCode.Z) && h == 1 || Input.GetKeyDown(KeyCode.Z) && v == 1)
            {
                Debug.Log("同時におした");
                var rotate = new RotateCommand(this.transform, m_rotate_Z);
                rotate.Execute();
                move.Execute();
                commands[0] = rotate;
                commands[1] = move;
                CommandManager.Instance.AddCommand(true,commands);
                return;
            }
            else if (Input.GetKeyDown(KeyCode.X) && h == 1 || Input.GetKeyDown(KeyCode.X) && v == 1)
            {
                Debug.Log("同時におした");
                var rotate = new RotateCommand(this.transform, m_rotate_Z * -1);
                rotate.Execute();
                move.Execute();
                commands[0] = rotate;
                commands[1] = move;
                CommandManager.Instance.AddCommand(true,commands);
                return;
            }

            //通常

            if (Input.GetKeyDown(KeyCode.Z))
            {
                //左回転
                //transform.Rotate(new Vector3(0, 0, m_rotate_Z));
                var rotate = new RotateCommand(this.transform, m_rotate_Z);
                rotate.Execute();
                commands[0] = rotate;
                CommandManager.Instance.AddCommand(false,commands);
                return;
                //CommandManager.Instance.AddCommand(rotate);
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                //右回転
                //transform.Rotate(new Vector3(0, 0, m_rotate_Z * -1));
                var rotate = new RotateCommand(this.transform, m_rotate_Z * -1);
                rotate.Execute();
                commands[0] = rotate;
                CommandManager.Instance.AddCommand(false,commands);
                return;
                // CommandManager.Instance.AddCommand(rotate);
            }

            commands[0] = move;
            CommandManager.Instance.AddCommand(false,commands);
        }
    }
}