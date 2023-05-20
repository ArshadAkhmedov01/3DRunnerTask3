using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControle : MonoBehaviour
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


        Vector3 movement = transform.right * moveInput;
        transform.position += movement * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(Mathf.Clamp(transform.position.x, -3f, 4f), transform.position.y, transform.position.z);


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
