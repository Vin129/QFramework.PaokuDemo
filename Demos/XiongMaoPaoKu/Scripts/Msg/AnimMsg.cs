using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace QFramework.PaokuDemo
{
    public class AnimMsg : QMsg
    {
        public InputDirection Dir;

        public AnimMsg() { }
    }

    public class UIMsg:QMsg{
        public int Distance;
    }
}
