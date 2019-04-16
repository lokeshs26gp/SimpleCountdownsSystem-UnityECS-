using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
/*
public class CubeSpawnerScaleSystem : ComponentSystem
{
    struct Query
    {
        public ComponentDataArray<Position> positions;
        public ComponentDataArray<Scale> scales;
        public readonly int Length;
    }
    [Inject] private Query query;
    protected override void OnUpdate()
    {
        float dt = Time.deltaTime;
        for (int i = 0; i < query.Length; i++)
        {
            float scalex = query.scales[i].Value.y * math.sin(Time.time);
            query.scales[i] = new Scale { Value = new float3(scalex, 1, 1) };
        }
        
    }

}
*/