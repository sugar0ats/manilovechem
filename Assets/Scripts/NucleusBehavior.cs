using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NucleusBehavior : MonoBehaviour
{
    public GameObject protonField;
    public InputField protonInput;

    public GameObject neutronField;
    public InputField neutronInput;

    public int protonCount;
    public int neutronCount;
    // Start is called before the first frame update
    void Start()
    {
        protonInput = protonField.GetComponent<InputField>();
        neutronInput = neutronField.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateProtons()
    {
        //InputField protonNums = protonField.GetComponent<InputField>();
        protonCount = (protonInput.text != "" ? Int16.Parse(protonInput.text) : 0);

    }

    public void updateNeutrons()
    {
        neutronCount = (neutronInput.text != "" ? Int16.Parse(neutronInput.text) : 0);
    }
}
