using CommandPattern.Test2;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CommandPattern_Test2
{
    public class CommandManager : MonoBehaviour
    {

        //シングルトンパターン
        private static CommandManager m_instance;
        public static CommandManager Instance 
        {
            get
            {
                if (m_instance == null)
                {
                    return FindObjectOfType<CommandManager>();
                }
                return m_instance;
            }
        }

        private List<ICommand> m_commandBuffer = new List<ICommand>();
        private Dictionary<bool, ICommand[]> m_commdndBufferDicttionary = new Dictionary<bool, ICommand[]>();

        public bool m_isLocked;

        private void Awake()
        {
            m_instance = this;
        }


        public void AddCommand(ICommand command)
        {
            m_commandBuffer.Add(command);
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="simultaneousPressing">同時押しならture</param>
       /// <param name="commands"></param>
        public void AddCommand(bool simultaneousPressing, ICommand[] commands)
        {
            m_commdndBufferDicttionary.Add(simultaneousPressing, commands);
        }


        public void Rewind()
        {
            if (m_isLocked) return;

            m_isLocked = true;
            StartCoroutine(RewindCorutine());
        }

        public void PlayBack()
        {
            if (m_isLocked) return;

            m_isLocked = true;
            StartCoroutine(PlayBackCoroutine());
        }


        private IEnumerator PlayBackCoroutine()
        {
            Debug.Log("Playback Start");
            foreach (var command in m_commandBuffer)
            {
                command.Execute();
                yield return new WaitForEndOfFrame();
            }
            Debug.Log("PlayBack End");
            m_isLocked = false;
        }


        private IEnumerator RewindCorutine()
        {
            Debug.Log("Rewind Start");
            ///Listを逆からとる。List.Reverse()はListの中身を変えてしまうのでEnumerable.Reversを使う
            //foreach (var command in Enumerable.Reverse(m_commandBuffer)) 
            //{
            //    command.Undo();
            //    yield return new WaitForEndOfFrame();
            //}

            foreach (KeyValuePair<bool, ICommand[]> command in Enumerable.Reverse(m_commdndBufferDicttionary)) 
            {
                //同時押ししたコマンドを同一フレームで処理
                if (command.Key)
                {
                    for (int i = 0; i < command.Value.Length; i++)
                    {
                        command.Value[i].Undo();
                    }
                    Debug.Log("同時処理!!");
                    yield return new WaitForEndOfFrame();
                    continue;
                }

                //通常処理
                for (int i = 0; i < command.Value.Length; i++)
                {
                    command.Value[i].Undo();
                    yield return new WaitForEndOfFrame();
                }
            }
            Debug.Log("Rewind End");
            m_isLocked = false;
        }
    }
}

