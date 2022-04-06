/**** 
 * Created by: Akram Taghavi-Burris
 * Date Created: 4/6/2022
 * 
 * Last Edited by: Cristian misla
 * Last Edited: 4/6/2022
 * 
 * Description: Behaviors for projectiles
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    /***Variables***/
    private BoundsCheck bndCheck;

    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bndCheck.offUp)
        {
            Destroy(gameObject);
        }
    }
}
