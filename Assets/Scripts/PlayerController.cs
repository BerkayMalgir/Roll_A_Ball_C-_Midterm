using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
   [SerializeField] private float speed = 0;
   public TextMeshProUGUI countText;
   
   private Rigidbody _rb;
   private int _count;
   private float _movementX;
   private float _movementY;
   

   private void Start()
   {
      _rb = GetComponent<Rigidbody>();
      _count = 0;
      SetCountText();
   }

   void OnMove(InputValue movementValue)
   {
      Vector2 movementVector = movementValue.Get<Vector2>();
      _movementX = movementVector.x;
      _movementY = movementVector.y;
      
   }

   void SetCountText()
   {
      countText.text = "Count: " + _count.ToString();
   }

   private void FixedUpdate()
   {
      Vector3 movement = new Vector3(_movementX, 0.0F, _movementY);
      _rb.AddForce(movement);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("PickUp"))
      {
         other.gameObject.SetActive(false);
         _count = _count + 1 ;
         SetCountText();
      }
         
   }
}
