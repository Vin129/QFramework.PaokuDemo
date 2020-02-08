using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.PaokuDemo
{
    public class Coin : QMonoBehaviour,IGameObj
    {
        public override IManager Manager
        {
            get
            {
                return GameManager.Instance;
            }
        }
        private void Awake()
        {
            GameObjManager.Instance.AddObj(this,GameObjType.Coin);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == Tag.player)
            {
                Hide();
                SendEvent(GameEvent.HitCoin);
            }
        }
    }
}
