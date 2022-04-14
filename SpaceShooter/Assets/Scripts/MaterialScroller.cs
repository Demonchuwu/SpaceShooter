/**** 
 * Created by: Akram Taghavi-Burris
 * Date Created: March 16, 2022
 * 
 * Last Edited by: Cristian misla
 * Last Edited: 4/13/2022
 * 
 * Description: Background animator 
****/

/*** Using Namespaces ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScroller : MonoBehaviour
{
    /***VARIBLES***/
    public Vector2 scrollspeed = new Vector2(0, 0f);
    private Renderer goRenderer;
    private Material goMat;
    private Vector2 offset;


    // Start is called before the first frame update
    void Start()
    {
        goRenderer = GetComponent<Renderer>();
        goMat = goRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = (scrollspeed * Time.deltaTime);
        goMat.mainTextureOffset += offset;
    }
}
