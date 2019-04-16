using UnityEngine;
using Unity.Jobs;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

#pragma warning disable CS0618 // Type or member is obsolete
[ComputeJobOptimization]
#pragma warning restore CS0618 // Type or member is obsolete
public class CubeSpawnerScaleJobSystem : JobComponentSystem
{
    struct ScaleJob : IJobProcessComponentData<Scale>
    {
        public float time;
        public void Execute(ref Scale data)
        {
            float scalex = data.Value.y * math.sin(time);
            data = new Scale { Value = new float3(scalex, 1, 1) };
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        return new ScaleJob
        {
            time = Time.time

        }.Schedule(this, inputDeps);
    }
}