using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public class CameraComplete : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;
        [SerializeField] private float dump;
        private PlayerControle player;
        void Start()
        {
            player = FindObjectOfType<PlayerControle>();
        }

        void Update()
        {

        }
        private void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, dump * Time.deltaTime);
        }
    }
}
