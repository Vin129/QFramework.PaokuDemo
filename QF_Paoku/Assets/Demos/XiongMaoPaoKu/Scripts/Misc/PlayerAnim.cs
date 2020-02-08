using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace QFramework.PaokuDemo
{
    public class PlayerAnim : QMonoBehaviour
    {

        Animation anim;
        Action PlayAnim;

        public override IManager Manager
        {
            get
            {
                return GameManager.Instance;
            }
        }

        private void Awake()
        {
            anim = GetComponent<Animation>();
            PlayAnim = PlayRun;
            Manager.RegisterEvent<AnimEvent>(AnimEvent.PlayerAnim, ChangeAnim);
        }

        void Update()
        {
            if (PlayAnim != null)
            {
                if (GameManager.Instance.GS == GameState.Start)
                {
                    PlayAnim();
                }
                else
                {
                    anim.Stop();
                }

            }
        }

        void PlayRun()
        {
            anim.Play("run");
        }

        void PlayLeft()
        {
            anim.Play("left_jump");
            if (anim["left_jump"].normalizedTime > 0.95f)
            {
                PlayAnim = PlayRun;
            }
        }
        void PlayRight()
        {
            anim.Play("right_jump");
            if (anim["right_jump"].normalizedTime > 0.95f)
            {
                PlayAnim = PlayRun;
            }
        }
        void PlayRoll()
        {
            anim.Play("roll");
            if (anim["roll"].normalizedTime > 0.95f)
            {
                PlayAnim = PlayRun;
            }
        }
        void PlayJump()
        {
            anim.Play("jump");
            if (anim["jump"].normalizedTime > 0.95f)
            {
                PlayAnim = PlayRun;
            }
        }

        void PlayShoot()
        {
            anim.Play("Shoot01");
            if (anim["Shoot01"].normalizedTime > 0.95f)
            {
                PlayAnim = PlayRun;
            }
        }

        public void MessagePlayShoot()
        {
            PlayAnim = PlayShoot;
        }


        public void ChangeAnim(int key, params object[] obj)
        {
            if (key != (int)AnimEvent.PlayerAnim)
                return;
            InputDirection dir = (obj[0] as AnimMsg).Dir;
            switch (dir)
            {
                case InputDirection.NULL:
                    break;
                case InputDirection.Right:
                    PlayAnim = PlayRight;
                    break;
                case InputDirection.Left:
                    PlayAnim = PlayLeft;
                    break;
                case InputDirection.Down:
                    PlayAnim = PlayRoll;
                    break;
                case InputDirection.Up:
                    PlayAnim = PlayJump;
                    break;
                default:
                    break;
            }

        }

    }
}
