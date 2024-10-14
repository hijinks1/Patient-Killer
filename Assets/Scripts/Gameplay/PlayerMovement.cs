using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    public Camera eyes;
    public Rigidbody rB;
    public float mouseSensitivity = 3f;
    public float walkSpeed = 6f;
    public Blink blink;
    public bool isWalking = false;

    public TextMeshProUGUI healthText;

    public DamagePlayer damagePlayer;
    public float dmgCD;
    public float lastDmgTime;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        CameraMovement();
        Walk();
        
        if (blink.canMove == false && isWalking == true && Time.time - lastDmgTime > dmgCD)
        {
            //dmg player
            if (damagePlayer != null &&  healthText != null)
            {
                Debug.Log("Health: " + damagePlayer.currentHP);
                healthText.text = "Health: " + damagePlayer.currentHP;
                
                Debug.Log("Take Dmg");
                bool isDead = damagePlayer.TakeDamage(damagePlayer.damage);
                lastDmgTime = Time.time;

                if (isDead)
                {
                    Debug.Log("Dead");
                }
            }
        }
    }
    

    public void CameraMovement()
    {
        float xRot = Input.GetAxis("Mouse X") * mouseSensitivity;
        float yRot = -Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.Rotate(0, xRot, 0);
        eyes.transform.Rotate(yRot, 0, 0);
        
        Vector3 eRot = eyes.transform.localRotation.eulerAngles;
        eRot.x += yRot;
        if (eRot.x < -180) eRot.x += 360;
        if (eRot.x > 180) eRot.x -= 360;
        eRot = new Vector3(Mathf.Clamp(eRot.x, -90f, 90f), 0f, 0f);
        eyes.transform.localRotation = Quaternion.Euler(eRot);
    }

    public void Walk()
    {
        Vector3 move = Vector3.zero;
        isWalking = false;

        if (Input.GetKey(KeyCode.W))
        {
            move += transform.forward;
            isWalking = true;
        }
        
        move = move.normalized * walkSpeed;
        
        rB.velocity = new Vector3(0, 0, move.z);
    }
    
}
