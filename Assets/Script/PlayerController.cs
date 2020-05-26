using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 4.0f;
    bool walking = false;
    public Vector2 lastMovement = Vector2.zero;
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";
    const string lastHorizontal = "LastHorizontal";
    const string lastVertical = "LastVertical";
    const string walkingState = "Walking";
    private Animator animator;
    Rigidbody2D playerRigidbody;
    public static bool playerCreated;
    public string nextPlaceName;

    private const string attackingState="Attacking";

    bool attacking=false;
    public float attackTime;
    float attackTimeCounter;
    SFXManager sFXManager; 

    // Start is called before the first frame update
    void Start () {
        animator=GetComponent<Animator>();
        sFXManager = FindObjectOfType<SFXManager>();
        
        playerRigidbody=GetComponent<Rigidbody2D>();

        if (!playerCreated)
        {
            playerCreated=true;
            DontDestroyOnLoad(this.transform.gameObject);
        }else{
            Destroy(gameObject);
        }
        /// Este es para que quede bien desde el inicio
        /// Este es para que quede  la animacion bien desde el inicio
        //Lo comente porque por alguna razón a mi me funciona bien:)
        // lastMovement=new Vector2(1,0);
    }

    // Update is called once per frame
    public bool canWalk;

    void Update () {
        //Time.time->Regresa el tiempo transcurrido
        //Timer.deltaTime->La velocidad a la que corre el juego
        // print("TIEMPO: "+Time.deltaTime);


        walking = false;
        if (Input.GetMouseButtonDown(0)){
            attacking=true;
            attackTimeCounter=attackTime;
            playerRigidbody.velocity=Vector2.zero;
            animator.SetBool(attackingState,true);
            
        }
       
        if (attacking)
        {
            attackTimeCounter -= Time.deltaTime;
            sFXManager.playerAttack.Play();
            if (attackTimeCounter < 0)
            {
                attacking = false;
                animator.SetBool(attackingState, false);
            }
        }
        //Creé esta variable y la pueden dejar asinada desde el start
        canWalk=GameObject.FindObjectOfType<DialogManager>().dailogActive;
        if ((Mathf.Abs(Input.GetAxisRaw(HORIZONTAL))>0.5f|| Mathf.Abs(Input.GetAxisRaw(VERTICAL))>0.5f) && !canWalk){
            walking=true;
            lastMovement=new Vector2(
                Input.GetAxisRaw(HORIZONTAL),
                Input.GetAxisRaw(VERTICAL));

            playerRigidbody.velocity=lastMovement.normalized * speed*Time.deltaTime;
        }
        animator.SetFloat (HORIZONTAL, Input.GetAxisRaw (HORIZONTAL));
        animator.SetFloat (VERTICAL, Input.GetAxisRaw (VERTICAL));

        animator.SetBool (walkingState, walking);

        animator.SetFloat (lastHorizontal, lastMovement.x);
        animator.SetFloat (lastVertical, lastMovement.y);

        if(!walking){
            ///Reseteamos la velocidad para que no quede patinando el jugador cuando deje de caminar
            // Si esto persiste puedes quitarle peso a la "mass" del ridgy
            playerRigidbody.velocity=Vector2.zero;
        }

    }
}