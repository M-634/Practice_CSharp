using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern_Test1
{
    public interface ICommand
    {
        void Execute();
        void Undue();
    }
}

