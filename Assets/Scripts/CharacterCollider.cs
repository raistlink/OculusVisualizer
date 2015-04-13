using UnityEngine;
using System.Collections;

public class CharacterCollider : MonoBehaviour {

    GameObject character;
    GameObject sphere;
    Vector3 lastPosition;

	// Use this for initialization
	void Start () {
        character = GameObject.Find("First Person Controller");
        sphere = GameObject.Find("Sphere");
	}
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(character.transform.position, Vector3.zero) > 15)
        {
            character.transform.position = lastPosition;
        }

        lastPosition = character.transform.position;
        
	}
}
