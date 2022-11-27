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
   public Transform respawnPoint;
   public MenuController menuControler;


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
      if(_count >= 12)
      {
         menuControler.WinGame();
         gameObject.SetActive(false);
      }
   }

   private void FixedUpdate()
   {
      Vector3 movement = new Vector3(_movementX, 0.0F, _movementY);
      _rb.AddForce(movement*speed);
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
  /*
   public void Respawn()
   {
      var enumerator = Wait();
      _rb.velocity = Vector3.zero;
      _rb.angularVelocity =Vector3.zero;
      _rb.Sleep();
      transform.position = respawnPoint.position;
      
   }
   */ 
  private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.CompareTag("Enemy"))
      {
         EndGame();
         
      }
   }
   void EndGame()     
   {
      menuControler.LostGame();
      gameObject.SetActive(false);
     
      
   }
}
