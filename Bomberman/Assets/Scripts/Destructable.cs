using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

    public Animator anim;
    public GameObject[] powerups;

    // Use this for initialization
    public void Destroy()
    {
        anim.SetTrigger("Explode");
        StartCoroutine("SpawnDestroy", .75f);
        
    }
    
    IEnumerator SpawnDestroy(float delay)
    {
        float destroyTime = Time.time + delay;
        while (true)
        {
            if (Time.time > destroyTime)
            {
                float chance = Random.Range(0f, 100f);
                print(chance);
                if (chance > 75)
                {
                    int item = Random.Range(0, 6);
                    Instantiate(powerups[item], transform.position, Quaternion.identity);
                }
                print("Shoudl destro");
                break;
            }
            else
            {
                yield return null;
            }
        }
        Destroy(gameObject);
    }
}
