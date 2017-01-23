using UnityEngine;
using System.Collections;

public class CharacterAnimationController : MonoBehaviour {

    private Animator characterAnimator;
    private CharacterController controller;
    public float speed = 0.5f;
    public float runSpeed = 1.7f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

    private bool attackState = false;



    private DistanceSearch distanceScripts;

    private AnimatorStateInfo stateInfo;

    void Start () 
    {
        distanceScripts = GetComponent<DistanceSearch> ();
        characterAnimator = GetComponent<Animator>();
        controller = GetComponent<CharacterController> ();
        characterAnimator.SetInteger ("moving", 1);
    }

    void Update ()
    {
        stateInfo = characterAnimator.GetCurrentAnimatorStateInfo(0);

        if (distanceScripts.SearchedFlag) {
            characterAnimator.SetInteger ("moving", 0);
            characterAnimator.SetInteger ("battle", 1);
            //idle or run -> battle change
        } 

        else
        {
            characterAnimator.SetInteger ("battle", 0);
            characterAnimator.SetInteger ("moving", 1);
            //battle -> run or idle chage
        }

        if (characterAnimator.GetInteger ("moving") == 1) {
            if(controller.isGrounded)
            {
                moveDirection = transform.forward * speed * runSpeed;

            }
            controller.Move(moveDirection * Time.deltaTime);
            moveDirection.y -= gravity * Time.deltaTime;
        }
    }

    public void SetBattle()
    {
        characterAnimator.SetInteger ("moving", 0);
        characterAnimator.SetInteger ("battle", 1);
        //idle or run -> battle change
    }

    public void SetIdle()
    {
        characterAnimator.SetInteger ("battle", 0);
        characterAnimator.SetInteger ("moving", 1);
        //battle -> run or idle chage
    }

    public void AttackAnimation(int attackDamage)
    {
        if (distanceScripts.target != null)
        {
            switch (this.transform.name)
            {
                case "EntMage":
                    characterAnimator.SetInteger("moving", Random.Range(7, 9));//AttackMotion Random Play
                    break;

                case "GoblinWarrior":
                    characterAnimator.SetInteger("moving", 3);//AttackMotion Random Play
                    break;

                case "GoblinShaman":
                    characterAnimator.SetInteger ("moving", Random.Range(5, 7));//AttackMotion Random Play
                    break;

                case "GoblinArcher":
                    characterAnimator.SetInteger("moving", 7);
                    break;

                case "IguanaMage":
                    characterAnimator.SetInteger ("moving", Random.Range(6, 8));//AttackMotion Random Play
                    break;

                case "OgreShaman":
                    characterAnimator.SetInteger ("moving", Random.Range(6, 8));//AttackMotion Random Play
                    break;

                case "OgreWarrior":
                    characterAnimator.SetInteger ("moving", Random.Range(3, 5));//AttackMotion Random Play
                    break;

                case "Rabbit":
                    characterAnimator.SetInteger ("moving", Random.Range(3, 6));//AttackMotion Random Play
                    break;

                default:
                    characterAnimator.SetInteger ("moving", Random.Range(3, 5));//AttackMotion Random Play
                    break;
            }
            distanceScripts.target.SendMessage("GetDamage", attackDamage, SendMessageOptions.DontRequireReceiver);
        }

    }

    public void HitAnimation()
    {
        if (!stateInfo.IsName("hit_1"))
        {
            characterAnimator.SetInteger("moving", 15);//HitMotion Random Play
        }
    }

    public void DeathAnimation()
    {
        if (!stateInfo.IsName("death_1"))
        {
            this.SendMessage("AttackAnimationStop");
            characterAnimator.SetInteger("moving", 13);//DeathMotion Random Play
            Destroy(this.gameObject, 1.5f);
        }
    }
}
