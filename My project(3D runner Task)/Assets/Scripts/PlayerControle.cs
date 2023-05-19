using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControle : MonoBehaviour
{
    [SerializeField] float speed;
    private float moveSpeed = 2f;
    private float coinCount=0f;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        float moveInput = Input.GetAxisRaw("Horizontal");


        Vector3 movement = transform.right * moveInput;
        transform.position += movement * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(Mathf.Clamp(transform.position.x, -3f, 4f), transform.position.y, transform.position.z);


        if (Input.GetKey(KeyCode.Space))
        {
            _rb.AddForce(new Vector3(0f, 5f, 0f)* 5 * Time.deltaTime, ForceMode.Impulse);
        }
        
        



    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {

            Destroy(collision.gameObject);
            coinCount++;
            Debug.Log(coinCount);
        }
    }
}
