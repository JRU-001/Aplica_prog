using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ControlerLight : MonoBehaviour
{
    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject greenLight;
    public float delay;
    public bool passable = false;
    public ArrayList lsCars = new ArrayList();
    
    void Start()
    {
        redLight.GetComponent<Renderer>().enabled = true;
        yellowLight.GetComponent<Renderer>().enabled = false;
	greenLight.GetComponent<Renderer>().enabled = false;
	Invoke("SemafaroCall", delay);
    }

    void Update()
    {
    }

    void SemafaroCall(){
	StartCoroutine(Semafaro());
    }

    IEnumerator Semafaro(){
	while(true){
	    passable=false;
	    redLight.GetComponent<Renderer>().enabled=true;
	    yellowLight.GetComponent<Renderer>().enabled=false;
	    greenLight.GetComponent<Renderer>().enabled=false;
	    yield return new WaitForSeconds(10);
	    passable=true;
	    CarsCanPass();
	    redLight.GetComponent<Renderer>().enabled=false;
	    yellowLight.GetComponent<Renderer>().enabled=false;
	    greenLight.GetComponent<Renderer>().enabled=true;
	    yield return new WaitForSeconds(7);
	    redLight.GetComponent<Renderer>().enabled=false;
	    yellowLight.GetComponent<Renderer>().enabled=true;
	    greenLight.GetComponent<Renderer>().enabled=false;
	    yield return new WaitForSeconds(3);
	    StopCoroutine(MoveCars());
	}
    }

   IEnumerator MoveCars(){
        while (lsCars.Count > 0){
	    GameObject Banshee = lsCars[0] as GameObject;
	    Banshee.GetComponent<CarMover>().run = true;
	    Banshee.GetComponent<CarMover>().semafaro = null;
	    lsCars.Remove(Banshee);
	}
	yield return new WaitForSeconds(0);
    }

   async void CarsCanPass(){
       GameObject Centro = GameObject.Find("Centro");
       while(Centro.GetComponent<StreetCounter>().objs > 0){
	   await Task.Yield();
       }
       StartCoroutine(MoveCars());
   }
}
