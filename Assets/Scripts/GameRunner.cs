using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] orbitals = new GameObject[3]; // precondition: must be an orbital
    public int[] electronArray = new int[3];
    public int[] maxElecArray = { 2, 8, 8 };
    public int totalElectronCount = 0;
    public int correctAnswer;
    public int correctProtons;
    public int correctNeutrons;

    public  int numElements = 18; // must be static to be used below
    public Element[] elements = new Element[18];
    public string[] elementNames = {"hydrogen", "helium", "lithium", "beryllium", "boron", "carbon", 
        "nitrogen", "oxygen", "fluorine", "neon", "sodium", "magnesium", "aluminum", 
        "silicon", "phosphorus", "sulfur", "chlorine", "argon"};
    public string[] elementSymbols = {"H", "He", "Li", "Be", "B", "C", "N", "O", "F", "Ne", "Na",
        "Mg", "Al", "Si", "P", "S", "Cl", "Ar"};
    public Element currentElement;

    public TextMeshProUGUI elementDisplayText;
    public TextMeshProUGUI massDisplayText;
    public TextMeshProUGUI chargeDisplayText;
    public TextMeshProUGUI checkDisplayText;
    public GameObject chckDispTextObj;

    public GameObject nucleus;
    public int protonCount;
    public int neutronCount;

    void Start()
    {
        updateNucleus();

        initElements();
        resetRound();
        
    }

    // Update is called once per frame
    void Update()
    {
        updateNucleus();

        totalElectronCount = 0; // reset electron count, or else it just keeps adding throughout all the frames :(

        for (int i = 0; i < orbitals.Length; i++) // for each loop in the orbitals
        {
            GameObject orbital = orbitals[i];
            if (orbital != null) // as long as there is something in the orbital 
            {
                int num = orbital.GetComponent<CircleCollisionTest>().electronCount; // get the electron count of that orbital only
                electronArray[i] = num;
                totalElectronCount += num; // add to the total count

                //Debug.Log("this orbital has " + num + " electrons");
            }
        }

        //Debug.Log("total electron count is " + totalElectronCount);
    }

    public void updateNucleus()
    {
        protonCount = nucleus.GetComponent<NucleusBehavior>().getProtons();
        neutronCount = nucleus.GetComponent<NucleusBehavior>().getNeutrons();
    }

    public void resetNucleus()
    {
        nucleus.GetComponent<NucleusBehavior>().resetProtons();
        nucleus.GetComponent<NucleusBehavior>().resetNeutrons();
    }

    public void isCorrect() // for now, we are asking for ground states ONLY
    {
        int valenceOrbital;
        int count = 0;

        if (correctAnswer < maxElecArray[0]) // i dont like this, make it look nicer sometime
        {
            valenceOrbital = 1;

        } else if (correctAnswer < maxElecArray[0] + maxElecArray[1])
        {
            valenceOrbital = 2;
        } else if (correctAnswer < maxElecArray[0] + maxElecArray[1] + maxElecArray[2])
        {
            valenceOrbital = 3;
        } else
        {
            valenceOrbital = 0; // for now, sussy logic
        }
        Debug.Log("valence orbital is #" + valenceOrbital);
        for (int i = 0; i < valenceOrbital; i++)
        {
            count += (i == valenceOrbital - 1 ? electronArray[i] : maxElecArray[i]);
        }
        Debug.Log("count is " + count);

        //chckDispTextObj.SetActive(true);
        checkDisplayText.enabled = true;

        if (count == correctAnswer && totalElectronCount == correctAnswer && isProtCorrect() && isNeutCorrect()) { // what happens when you check the answer?
            checkDisplayText.text = "correct!";

            Invoke("resetRound", 1.0f);
        } else
        {
            checkDisplayText.text = "incorrect";
        };

        Invoke("hideCheckDisplayText", 0.5f);
    }

    public bool isProtCorrect()
    {
        return protonCount == correctProtons;
    }

    public bool isNeutCorrect()
    {
        return neutronCount == correctNeutrons;
    }

    public void resetRound()
    {
        currentElement = elements[getRandInt(0, numElements - 1)];
        Isotope isotope = new Isotope(currentElement);
        elementDisplayText.text = currentElement.getSymbol(); // convert correct answer to string
        massDisplayText.text = "" + isotope.getMass();
        chargeDisplayText.text = "" + isotope.getCharge();
        correctAnswer = isotope.getElectrons(); // placeholder
        correctProtons = isotope.getProtons();
        correctNeutrons = isotope.getNeutrons();

        foreach (GameObject orbital in orbitals)
        {
            orbital.GetComponent<CircleCollisionTest>().resetElectrons();
        }

        
    }

    private void initElements()
    {
        //Debug.Log("does this run?");
        for (int i = 0; i < numElements; i++)
        {
            elements[i] = new Element(elementNames[i], elementSymbols[i], i + 1);
            //Debug.Log("element #" + (i + 1) + " is " + elementNames[i]);
        }
    }
    private int getRandInt(int start, int end)
    {
        return (int) (Random.Range(start, end));
    }

    public void hideCheckDisplayText()
    {
        checkDisplayText.enabled = false;
    }
}
