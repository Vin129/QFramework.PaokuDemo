using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.PaokuDemo
{

    public class People : MonoBehaviour,IGameObj
    {

        public bool isHit = false;
        public float speed = 10;
        public bool isFly = false;
        Animation anim;

        private void Awake()
        {
            GameObjManager.Instance.AddObj(this, GameObjType.People);

            anim = GetComponentInChildren<Animation>();

            anim.Play("run");
        }



        public void HitPlayer(Vector3 pos)
        {
            isHit = false;
            isFly = true;
            anim.Play("fly");
        }



        //开始移动
        public void HitTrigger()
        {
            isHit = true;
        }

        private void Update()
        {
            if (isHit && GameManager.Instance.GS == GameState.Start)
            {
                transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            if (isFly && GameManager.Instance.GS == GameState.Start)
            {
                transform.position += new Vector3(0, speed, speed) * Time.deltaTime;
            }
        }

        public void Show()
        {
            anim.transform.localPosition = Vector3.zero;
            isHit = false;
            isFly = false;
        }

        public void Hide()
        {
            
        }
    }
}
