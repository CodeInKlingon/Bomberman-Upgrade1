using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    float bombTime;
    bool hasExploded = false;
    public int range = 3;

    public LayerMask blastCollision;
    public GameObject blast;

    float blasthalfWidth = 0.4f;

	// Use this for initialization
	void Start () {
        bombTime = Time.time + 2;
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time > bombTime && !hasExploded) {
            hasExploded = true;
            Blast();
        }
	}

    void Blast () {
        Vector3[] directions = new Vector3[]{ Vector3.up, Vector3.left, Vector3.down, Vector3.right };
        foreach (Vector3 dir in directions) {
            for (int i = 0; i < range; i++)
            {
                RaycastHit2D hit = Physics2D.CircleCast(transform.position + (dir * (i+1)), 0.5f,new Vector3(0,0,1));
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Destructable") {
                        hit.collider.SendMessage("Destroy");
                    }
                    //hit a wall or powerup
                    //Vector3 pos = transform.position + (dir * (i + 1));
                    //Instantiate(blast, pos, Quaternion.identity);
                    break;
                    
                }
                else
                {
                    Vector3 pos = transform.position + (dir * (i+ 1));
                    GameObject blastInstance = Instantiate(blast, pos, Quaternion.identity) as GameObject;

                    //print("range is:" + i + "/" + range);
                    if (i == range-1) {
                        print("is tip");
                        blastInstance.GetComponent<Blast>().setIsTip();
                    }
                    blastInstance.GetComponent<Blast>().setDir(dir);
                    //spawn fire
                }
            }
            
            
        }
        GameObject blastInstance2 = Instantiate(blast, transform.position, Quaternion.identity) as GameObject;
        blastInstance2.GetComponent<Blast>().Center();
        Destroy(gameObject);
    }
}
