using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isotope
{
    private Element element;
    private int charge;
    private int mass;
    private int protons;
    private int neutrons;
    private int electrons;
    // Start is called before the first frame update
    public Isotope(Element element)
    {
        this.element = element;
        this.protons = element.getNum();
        this.neutrons = this.randNeutron();
        this.electrons = this.randElectron();
        this.charge = this.protons - this.electrons;
        this.mass = this.protons + this.neutrons;
    }

    public int getCharge() {
        return charge;
    }

    public int getMass()
    {
        return mass;
    }

    public int getNeutrons()
    {
        return neutrons;
    }

    public int getElectrons()
    {
        return electrons;
    }

    public int getProtons()
    {
        return protons;
    }

    private int randElectron()
    {
        int electronNum = (int) (Random.Range(element.getNum() - 3, element.getNum() + 3));
        return electronNum;
    }

    private int randNeutron()
    {
        int neutronNum = (int)(Random.Range(element.getNum(), element.getNum() + 6));
        return neutronNum;
    }
}
