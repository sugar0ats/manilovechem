using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NucleusBehavior : MonoBehaviour
{
    public GameObject protonField;
    public TMP_InputField protonInput;

    public GameObject neutronField;
    public TMP_InputField neutronInput;

    public int protonCount;
    public int neutronCount;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("doesthis work?");
        
        updateProtons();
        updateNeutrons();
        // protonInput = protonField.GetComponent<TMP_InputField>();
        // neutronInput = neutronField.GetComponent<TMP_InputField>();
        protonInput.text = "0";
        neutronInput.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateProtons()
    {

        protonCount = (protonInput.text != "" ? Int16.Parse(protonInput.text) : 0);

    }

    public void updateNeutrons()
    {

        neutronCount = (neutronInput.text != "" ? Int16.Parse(neutronInput.text) : 0);
    }

    public void repZeroPro() {
        if (protonInput.text == "") {

        }
    }
}
