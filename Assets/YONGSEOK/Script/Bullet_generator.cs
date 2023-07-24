using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_generator : MonoBehaviour
{
    public List<GameObject> bullets = new List<GameObject>();
    int curent_bullet = 0;

    private void Update()
    {
        curent_bullet++;
        if (curent_bullet >= bullets.Count) curent_bullet = 0;

        if(bullets.Count > 0)
            Instantiate(bullets[curent_bullet], transform.position, Quaternion.identity);
            

        
    }

}
