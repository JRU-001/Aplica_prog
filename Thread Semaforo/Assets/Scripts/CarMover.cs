using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    public bool run = false;
    public char direction;
    public GameObject semafaro = null;
    private Vector3 movingDirection;
    void Start()
    {

	   
    }

    // Update is called once per frame
    void Update() {
	if(run) {
	    switch(direction){
		case 'U':
	            movingDirection = new Vector3(0,2*Time.deltaTime,0);
	            break;
	        case 'D':
		    movingDirection = new Vector3(0,-2*Time.deltaTime,0);
		    break;
	        case 'L':
		    movingDirection = new Vector3(-2*Time.deltaTime,0,0);
		    break;
	        case 'R':
		    movingDirection = new Vector3(2*Time.deltaTime,0,0);
		    break;
	    }
		gameObject.transform.position += movingDirection;
	}
    }

    private void OnTriggerEnter2D(Collider2D collider) {
	switch(collider.tag){
	    case "Semafaro":
		run = collider.gameObject.GetComponent<ControlerLight>().passable;
		if(!run){
		    semafaro = collider.gameObject;
		    semafaro.GetComponent<ControlerLight>().lsCars.Add(gameObject);
		}
		break;
	    case "Banshee":
		run = collider.gameObject.GetComponent<CarMover>().run;
		if(!run){
		    semafaro = collider.gameObject.GetComponent<CarMover>().semafaro;
		    semafaro.GetComponent<ControlerLight>().lsCars.Add(gameObject);
		}
		break;
	    case "Ded":
		Destroy(this.gameObject);
		break;
	}
    }
}
