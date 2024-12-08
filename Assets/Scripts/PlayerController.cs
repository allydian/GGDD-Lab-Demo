using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed; //To adjust character movement speed in the Inspector window.
    private bool isMoving; //To identify whether the playable character is moving.
    private Vector2 input; //Vector2 is a struct in Unity that is used to represent 2D
    //positions and vectors. It holds X and Y values.

    private Animator animator;
    //Awake() is used to initialise variables or states before the game starts.
    //In this case, it initialises the Animator variable.
    private void Awake()
    {
        animator = GetComponent<Animator>();//Gets the generic animator component.
        //Used for the sprite animation when moving.
    }

    public void Update()
    {
        //If the character is not moving, it will be waiting and checking for inputs.
        if (!isMoving)
        {

            input.x = Input.GetAxisRaw("Horizontal");//Horizontal movement is stored as input.x.
            input.y = Input.GetAxisRaw("Vertical"); //Vertical movement is stored as input.y.
            //Value ranges from -1 to 1 because input is not smooth.
            //Horizontal axis is managed by the following keys: A, D, left arrow, right arrow.
            //Vertical axis is managed by the following keys: W, S, up arrow, down arrow.
            
            Debug.Log("This is input.x:" + input.x); //This only appears in the console.
            Debug.Log("This is input.y:" + input.y); //This only appears in the console.
            if (input.x != 0) input.y = 0; //To prevent the character from moving diagonally.
            //Can be removed if you want them to move diagonally.
            
            if (input != Vector2.zero) //Vector2.zero is (0,0). If the input is any other key,
            {
                //Gets the values of moveX and moveY.
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position; //transform.position can be found in the
                //Inspector window of the GameObject.
                //Rect Transform -> Position.

                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos));
            }
        }
        animator.SetBool("isMoving", isMoving);
    }
    //Function for coroutine to move the player from one point to another point.
    //Vector3 holds three values: X, Y, and Z.
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        //If the target position minus the original move >0 , then an action will be taken.
        
        //Epsilon is a tiny floating point value.
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            //Moves the object from its current position to the target position at the
            //set movement speed.
            //Time.deltaTime ensures that the frame rate remains the same regardless of the
            //device's frame rate.

            yield return null;
        }
        transform.position = targetPos;
        isMoving= false;
    }
}