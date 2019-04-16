
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;
/*
public class CubeSpawnerRotationSystem : ComponentSystem
{
    struct Query
    {  
        public ComponentDataArray<Position> positions;
        public ComponentDataArray<Rotation> rotations;
        //public ComponentDataArray<Scale> scales;
        public readonly int Length;
        
    }
    [Inject] private Query query;
    protected override void OnUpdate()
    {
        float dt = Time.deltaTime;
        for(int i =0;i<query.Length;i++)
        {
            //Position newPositionValue = query.positions[i];
            //query.positions[i] = new Position { Value = newPositionValue.Value };

          //  if (i % 2 == 0)
           // {
                quaternion newRotationValue = query.rotations[i].Value;
                newRotationValue = math.mul(math.normalize(query.rotations[i].Value), quaternion.AxisAngle(new float3(0, 1, 0), 10.0f * dt));
                query.rotations[i] = new Rotation { Value = newRotationValue };
            //}
           
            
        }
    }
}
*/
/*public class RotateSystem : ComponentSystem
{
    struct Data
    {
        public readonly int Length;
        public ComponentDataArray<Rotation> Rotation;
        public ComponentDataArray<RotationSpeed> RotationSpeed;
    }

    [Inject] private Data m_Data;
    protected override void OnUpdate()
    {
        float dt = Time.deltaTime;
        for (int index = 0; index < m_Data.Length; ++index)
        {
            var rotation = m_Data.Rotation[index].Value;
            rotation = math.mul(math.normalize(m_Data.Rotation[index].Value), quaternion.AxisAngle(new float3(0, 1, 0), m_Data.RotationSpeed[index].Value * dt));

            m_Data.Rotation[index] = new Rotation { Value = rotation };
        }
    }
}

/*public class MoveSystem : ComponentSystem
{
    // This version is different from the Hybrid approach just so we can show the lists
    // of contiguous elements Position and MoveSpeed ComponentDataArrays<>
    struct Data
    {
        public readonly int Length;
        public ComponentDataArray<Position> Position;
        public ComponentDataArray<MoveSpeed> MoveSpeed;
    }

    // This inject acts similar to the GetEntities version in our Hybrid approach
    // You can see that the m_Data. is already populated with the objects containing
    // a Position, MoveSpeed in the world

    [Inject] private Data m_Data;
    protected override void OnUpdate()
    {
        float t = Time.time;

        for (int index = 0; index < m_Data.Length; ++index)
        {
            var position = m_Data.Position[index].Value;

            position.y = math.sin(t * m_Data.MoveSpeed[index].speed) * 0.5f; // note that we are using the sin from the Unity.Mathematics namespace

            m_Data.Position[index] = new Position { Value = position };
        }
    }
}*/
