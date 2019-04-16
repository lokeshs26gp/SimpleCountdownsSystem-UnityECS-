using UnityEngine;
using Unity.Entities;
using System.Collections;
public class TestCountDownSystem : MonoBehaviour
{

    // Start is called before the first frame update
    IEnumerator Start()
    {

        CountDownSystem system =  World.Active.GetOrCreateManager<CountDownSystem>();

        for (int i = 0; i < 20;i++)
        {
            system.AddCountDown("key" + i,20, HandleAction,true);
            yield return new WaitForSeconds(10);
            system.ForceRemoveCountDown("key"+i);
        }
       

        
    }


    void HandleAction(string obj,float timer)
    {
        Debug.Log("countdown -->"+obj+" = "+timer);
    }

}
