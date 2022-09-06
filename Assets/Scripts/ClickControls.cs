using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://forum.unity.com/threads/2d-ring-collider.574540/

public class ClickControls : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isClicked = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Vector3 mousePos; // create vector3
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos); // convert screen point of mouse to in game point

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 30);
            //Debug.Log("this obj is being clicked");

            //this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void OnMouseDown()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos; // create vector3
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos); // convert screen point of mouse to in game point

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isClicked = true;
        }
        
    }

    private void OnMouseUp()
    {
        isClicked = false;
    }
}
