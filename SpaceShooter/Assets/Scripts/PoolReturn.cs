/**** 
 * Created by: Cristian misla
 * Date Created: 4/11/2022
 * 
 * Last Edited by: Cristian misla
 * Last Edited: 4/11/2022
 * 
 * Description: Returns object to pool on disable
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturn : MonoBehaviour
{

    private ObjectPull pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = ObjectPull.POOL;
    }

    private void OnDisable()
    {
        if(pool != null)
        {
            pool.ReturnObject(this.gameObject); //return object to pool
        }
    }//end OnDisabled()
}
