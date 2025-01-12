/**** 
 * Created by: Cristian misla
 * Date Created: 4/6/2022
 * 
 * Last Edited by: Cristian misla
 * Last Edited: 4/11/2022
 * 
 * Description: Create a pull of objects for reuse
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPull : MonoBehaviour
{

    /***Variables***/
    static public ObjectPull POOL;
    #region POOL Singleton
    void CheckPoolIsInScene()
    {
        if (POOL == null)
        {
            POOL = this;
        }
        else
        {
            Debug.Log("POOL.Awake() - Attempted to assign a second ObjectPull.POOL");
        }
    }//end CheckPoolIsInScene()
    #endregion
    private Queue<GameObject> projectile = new Queue<GameObject>();//New queue of projectiles
    [Header("Pool Settings")]
    public GameObject projectilePrefab;
    public int poolStartSize = 5;

    /***Methods***/
    private void Awake()
    {
        CheckPoolIsInScene();
    }//end Awake()

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < poolStartSize; i++)
        {
            GameObject projectileGO = Instantiate(projectilePrefab);
            projectile.Enqueue(projectileGO); //add to queue
            projectileGO.SetActive(false); 
        }
    }

    public GameObject GetObject()
    {
        if(projectile.Count > 0)
        {
            GameObject gObject = projectile.Dequeue();
            gObject.SetActive(true);
            return gObject;
        }
        else
        {
            Debug.LogWarning("Out of objects, reloading...");
            return null;
        }
    }//end GetObject()

   public void ReturnObject(GameObject gObject)
    {
        projectile.Enqueue(gObject);
        gObject.SetActive(false);
    }
}
