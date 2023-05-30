using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControle : MonoBehaviour
//{

#region one
//    private float speed = 5f;
//    private float rotspeed = 80;
//    private float gravity = 8;
//    private float rot = 0f;
//    Vector3 movDir=Vector3.zero;
//    CharacterController controller;
//    Animator anim;

//    private void Start()
//    {
//        controller= GetComponent<CharacterController>();
//        anim= GetComponent<Animator>(); 
//    }
//    private void Update()
//    {
//        anim.SetBool("Walk", true);
//        movDir=new Vector3(0,0,1);
//        movDir *= speed;
//        movDir=transform.TransformDirection(movDir);
//        if (Input.GetKeyUp(KeyCode.W))
//        {

//            anim.SetBool("Walk", false);
//            movDir = new Vector3(0,0,0);
//        }

//        rot += Input.GetAxis("Horizontal") * rotspeed * Time.deltaTime;
//        transform.eulerAngles =new Vector3(0,rot,0) ;
//        movDir.y -= gravity * Time.deltaTime;
//        controller.Move(movDir*Time.deltaTime);
//    }

//}
#endregion
{
    [SerializeField] float speed;
    private float moveSpeed = 2f;
    private float coinCount = 0f;

    private Rigidbody _rb;

    [SerializeField] Animator anime;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        anime = GetComponent<Animator>();
    }

    void Update()
    {

        float moveInput = Input.GetAxisRaw("Horizontal");


        //Vector3 movement = transform.right * moveInput;
        transform.position += new Vector3(moveInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3f, 4f), transform.position.y, transform.position.z);


        if (Input.GetKey(KeyCode.Space))
        {
            _rb.AddForce(new Vector3(0f, 5f, 0f) * 5 * Time.deltaTime, ForceMode.Impulse);
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            anime.SetTrigger("Finish");
        }


        if (other.CompareTag("Coin"))
        {

            Destroy(other.gameObject);
            coinCount++;
            Debug.Log(coinCount);

            transform.DOScale(transform.localScale * 1.3f, 0.3f);
        }
    }



}
