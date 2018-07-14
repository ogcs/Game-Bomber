using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{

    public int MoveSpeed = 10;

    public Vector3 Direction;

    public bool IsMoving = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        #region Keyboard Control

        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.W))
            {
                IsMoving = true;
                MoveForward();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                IsMoving = true;
                MoveBack();
            }

            if (Input.GetKey(KeyCode.A))
            {
                IsMoving = true;
                MoveLeft();
            }
            else if (Input.GetKey(KeyCode.D))
            {
                IsMoving = true;
                MoveRight();
            }
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            IsMoving = false;
            Debug.Log("" + IsMoving);
        }

        #endregion



    }


    public void MoveForward()
    {
        Direction = Vector3.forward;
    }

    public void MoveBack()
    {
        Direction = Vector3.back;
    }

    public void MoveLeft()
    {
        Direction = Vector3.left;
    }

    public void MoveRight()
    {
        Direction = Vector3.right;
    }

    private void FixedUpdate()
    {
        if (IsMoving)
        {
            transform.Translate(this.Direction * MoveSpeed * Time.deltaTime, Space.World);
        }
    }
}
