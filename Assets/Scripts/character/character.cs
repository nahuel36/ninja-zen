using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
public class Character : MonoBehaviour {

    Animator animator;

    [SerializeField] GameObject ExplodeUL;
    [SerializeField] GameObject ExplodeUR;
    [SerializeField] GameObject ExplodeDL;
    [SerializeField] GameObject ExplodeDR;

    [SerializeField] GameObject[] KaratekaSprites;

    private bool isLeft = false;
    private bool inputEnabled = true;

    private InputAction actionUR;
    private InputAction actionUL;
    private InputAction actionDR;
    private InputAction actionDL;

    [SerializeField] ItemsSpawner spawnerUR;
    [SerializeField] ItemsSpawner spawnerUL;
    [SerializeField] ItemsSpawner spawnerDR;
    [SerializeField] ItemsSpawner spawnerDL;

    [SerializeField] SpawnManager spawnManager;

    [SerializeField] PlaySound kickSounds;
    [SerializeField] PlaySound hurtSound;
    [SerializeField] PlaySound bottleCrashSound;

    public void Start() {
        inputEnabled = true;
        animator = GetComponent<Animator>();
        isLeft = false;
        LevelManager.looseGame += disableInput;
        
        actionUR = InputSystem.actions.FindAction("UR");
        actionUL = InputSystem.actions.FindAction("UL");
        actionDR = InputSystem.actions.FindAction("DR");
        actionDL = InputSystem.actions.FindAction("DL");
    }

    public void Update()
    {
        

        if (actionUR.WasPressedThisFrame())
        {
            Punch("UR");
        }
        else if (actionUL.WasPressedThisFrame())
        {
            Punch("UL");
        }
        else if (actionDR.WasPressedThisFrame())
        {
            Punch("DR");
        }
        else if (actionDL.WasPressedThisFrame())
        {
            Punch("DL");
        }
    }

    public void changeSprite(Sprite up, Sprite down, Sprite iddle)
    {


    }

    public void disableInput() {
        inputEnabled = false;
    }

    public bool canPunch() {
        return (inputEnabled && animator.GetCurrentAnimatorStateInfo(0).IsName("Iddle") && spawnManager.IsSpawning);
    }

    public void rotateSprites()
    {
        for (int i = 0; i < KaratekaSprites.Length; i++)
        {
            KaratekaSprites[i].transform.Rotate(0, 180, 0);

        }
    }

    public void Punch(string direction)
    {
        if (!canPunch())
            return;

        kickSounds.Play();

        if (direction == "UL")
        {
            spawnerUL.Break();
            animator.SetTrigger("UpAttack");
            if (!isLeft)
            {
                rotateSprites();
                isLeft = true;
            }
        }
        else if (direction == "UR")
        {
            spawnerUR.Break();
            animator.SetTrigger("UpAttack");
            if (isLeft)
            {
                rotateSprites();
                isLeft = false;
            }
        }
        else if (direction == "DL")
        {
            spawnerDL.Break();
            animator.SetTrigger("MiddleAttack");
            if (!isLeft)
            {
                rotateSprites();
                isLeft = true;
            }

        }
        else if (direction == "DR")
        {
            spawnerDR.Break();
            animator.SetTrigger("MiddleAttack");
            if (isLeft)
            {
                rotateSprites();
                isLeft = false;
            }
        }
    }


        public void Avoid(string direction)
    {
        if (direction == "Down")
        {
            animator.SetTrigger("Down");
        }
        else if (direction == "Jump")
        {
            animator.SetTrigger("Jump");

        }
        
    }

    public void KickExplode(string direction)
    {
        bottleCrashSound.Play();
        if (direction == "UL")
        {
            ExplodeUL.GetComponent<ParticleSystem>().Play();
        }
        else if (direction == "UR")
        {
            ExplodeUR.GetComponent<ParticleSystem>().Play();
        }
        else if (direction == "DL")
        {
            ExplodeDL.GetComponent<ParticleSystem>().Play();
        }
        else if (direction == "DR")
        {
            ExplodeDR.GetComponent<ParticleSystem>().Play();
        }
    }

    public void Hurt() {

        animator.SetTrigger("Hurt");
        if(LevelManager.Instance.lifes > 0)
            hurtSound.Play();
        
    }



}
