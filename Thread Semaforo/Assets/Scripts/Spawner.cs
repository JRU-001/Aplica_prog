using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    public GameObject Banshee;
    enum Direction {
	L,
	R,
	U,
	D
    };
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCar", 0, 1);
    }

    private void SpawnCar(){
	GameObject newBanshee = Instantiate(Banshee, new Vector3(-20,-20,-20), Quaternion.identity);
	Array values = Enum.GetValues(typeof(Direction));
	System.Random random = new System.Random();
	Direction randomDir = (Direction)values.GetValue(random.Next(values.Length));
	Vector3 spawnPoint = new Vector3(0, 0, 0);
	Quaternion rotationPoint = new Quaternion(0, 0, 0, 0);
	char dir='L';
	switch(randomDir){
	    case Direction.R:
	        dir = 'R';
	        spawnPoint = new Vector3(-2.9f, -0.3f, 4);
	        break;
	    case Direction.L:
		dir = 'L';
		spawnPoint = new Vector3(2.9f, 0.3f, 4);
		rotationPoint = new Quaternion(0,180,0,1);
		break;
	    case Direction.D:
		dir = 'D';
		spawnPoint = new Vector3(-0.3f, 2, 4);
		rotationPoint = Quaternion.Euler(0,0,270);
		break;
	    case Direction.U:
		dir = 'U';
		spawnPoint = new Vector3(0.3f, -2, 4);
		rotationPoint = Quaternion.Euler(0,0,90);

		break;
	}
       newBanshee.transform.position = spawnPoint;
       newBanshee.transform.rotation = rotationPoint;
       newBanshee.GetComponent<CarMover>().direction = dir;
       newBanshee.GetComponent<CarMover>().run = true;
    }
}
