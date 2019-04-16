using Unity.Entities;

public struct CountDown : IComponentData
{
    public int key;
    public float totalTime;
    public int isCompleted;

    public CountDown(int pkey,float ptotaltime)
    {
        key = pkey;
        totalTime = ptotaltime;
        isCompleted = totalTime <= 0 ? 1:0;
    }
   

}

public class CountDownRef
{
    private string key;
    private bool updateFrame = false;
    private System.Action<string,float> OnCallback; 

    public CountDownRef(string pkey, System.Action<string,float> pcallback,bool onUpdate = false)
    {

        key = pkey;
        OnCallback = pcallback;
        updateFrame = onUpdate;
    }
    public void OnUpdate(float timer)
    {
        if(updateFrame)
            OnCallback(key, timer);
    }
    public void OnCompletedEvent()
    {
        OnCallback(key,0);
    }

    public bool IsEqual(string pkey)
    {
        return key == pkey;
    }
   
}