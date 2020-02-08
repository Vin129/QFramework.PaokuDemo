using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.PaokuDemo
{
    public class Obstacle : QMonoBehaviour
    {

        public override IManager Manager
        {
            get
            {
                return GameManager.Instance;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == Tag.player)
            {
                SendEvent(GameEvent.HitObstacle);
            }
        }
    }
}
