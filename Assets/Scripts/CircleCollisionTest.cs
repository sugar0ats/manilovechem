using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollisionTest : MonoBehaviour
{
    private Vector2 mousePos;
    //private float startPosX;
    //private float startPosY;
    //private bool isClicked = false;
    public float minCollideRadius = 1.9f;
    public GameObject electron;
    public GameObject fullElectron;
    public int maxElectronCount = 4;
    private GameObject[] electrons;
    public int electronCount = 0;
    public float radius;
    public string orbitalName;
    // Start is called before the first frame update
    void Start()
    {
        electrons = new GameObject[maxElectronCount];
        //Debug.Log("this circle's position is " + transform.position);
        radius = this.GetComponent<CircleCollider2D>().radius * this.gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject e in electrons)
        {
            Destroy(e);
        }

        for (int i = 0; i < electronCount; i++)
        {
            float radians = ((float) i / electronCount) * 2 * (float)System.Math.PI;
            GameObject piece = (electronCount == maxElectronCount ? Instantiate(fullElectron) : Instantiate(electron));
            electrons[i] = piece;
            piece.transform.position = this.transform.position + radius * new Vector3((float)System.Math.Cos(radians), (float)System.Math.Sin(radians), 30);
            //Debug.Log("radians are " + (i / maxElectronCount) + "* 2pi");
        }

        
    }

    private void OnMouseOver()
    {
        Debug.Log("click registered # " + name);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("mouse position is " + mousePos);
        Vector2 circlePos = this.transform.position;
        float distance = (mousePos - circlePos).SqrMagnitude();
        //Debug.Log("distance is " + distance);
        if (Input.GetMouseButtonDown(0) && distance >= System.Math.Pow(minCollideRadius, 2))
        {
            Debug.Log("click on orbital " + name + "!");
            electronCount = (electronCount == maxElectronCount ? 0 : electronCount + 1);
        } 
        if (Input.GetMouseButtonDown(1) && distance >= System.Math.Pow(minCollideRadius, 2))
        {
            electronCount = (electronCount == 0 ? maxElectronCount : electronCount - 1);
        }
    }

    public void resetElectrons()
    {
        this.electronCount = 0;
    }

    //private void OnMouseUp()
    //{
    //    isClicked = false;
    //}
}
