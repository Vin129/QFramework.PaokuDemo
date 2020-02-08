using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace QFramework.PaokuDemo
{

    public class Car : MonoBehaviour,IGameObj
    {
        public bool canMove = true;
        bool isBlock = false;
        public float speed = 10;

        Vector3 localPos;
        void Awake()
        {
            localPos = transform.localPosition;
        }

        //碰撞到触发区域
        public void HitTrigger()
        {
            isBlock = true;
        }

        private void Update()
        {
            if (isBlock && canMove && GameManager.Instance.GS == GameState.Start)
            {
                transform.Translate(-transform.forward * speed * Time.deltaTime);
            }
        }

        public void Show()
        {
            isBlock = false; transform.localPosition = localPos;
        }

        public void Hide()
        {
            
        }
    }
}
