using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using TacheScript;
using TMPro;

public class Caress : MonoBehaviour
{ // GameObject Mii = GameObject.Find("Mii");
   
   

     public GameObject _child;
    //  public int Ccount = Tatch.count;
     private float size = 0.1f;
     public float grow = 0;
     bool isOnce = true;

    // count = 0;

    void Start()
    {
       
         _child =GameObject.Find ("Mii");
            // GameObject a = GameObject.Find("Mii");
             _child.transform.localScale = new Vector3(size,size,size);
            Debug.Log( _child);
            //  StartCoroutine("ScaleUp");
           
    }

     void Update() {
        int Ccount = Tatch.count;
         Debug.Log(Ccount);

        switch (Ccount)
        {
            case 1:
                grow = 0.5f;
                Debug.Log("成長１");
                StartCoroutine("ScaleUp");
                isOnce = false;
                break; 
             case 2: 
                grow = 1f;
                Debug.Log("成長２");
                StartCoroutine("ScaleUp");
                isOnce = false;
                break;
            case 3: 
                grow = 1.5f;
                Debug.Log("成長３");
                StartCoroutine("ScaleUp");
                isOnce = false;
                break;
            default:
                break;
            
        }

        // if(Ccount == 1 && isOnce){
        //     grow = 0.5f;
        //     StartCoroutine("ScaleUp");
        //     isOnce = false;
        // }
        // if(Ccount == 2 && isOnce){
        //      grow = 1f;
        //     StartCoroutine("ScaleUp");
        //     isOnce = false;
        // }
        // if(Ccount == 3 && isOnce){
        //      grow = 1.5f;
        //     StartCoroutine("ScaleUp");
        //     isOnce = false;
        // }
        
    }
    IEnumerator ScaleUp()
    {
       
        for ( float i = size ; i < grow ; i+=0.1f ){
            //  _child.transform.localScale = new Vector3(i,i,i);
            _child.transform.localScale = new Vector3(i,i,i);
            yield return new WaitForSeconds(0.1f);
            size = i;
        }
        
        isOnce = true;
    }

}
