using Unity.Entities;
using UnityEngine;

public class RotationSystem : ComponentSystem
{
     struct Criteria 
    {
        public Transform transfrom;
        public RotationMonoComponent Rotation;
       // public MeshRenderer renderer;
    }
    
    protected override void OnUpdate()
    {
        float dt = UnityEngine.Time.deltaTime;

        Debug.Log("OnUpdate");

        foreach (Criteria criteria in GetEntities<Criteria>() )
        {
            // Debug.Log(criteria.transfrom.name);


            criteria.transfrom.Rotate(Vector3.up);//criteria.Rotation.quaternion;


        }
    }

}
