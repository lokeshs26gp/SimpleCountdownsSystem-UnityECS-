using UnityEngine;
using Unity.Jobs;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class CubeSpawnerRotationJobSystem : JobComponentSystem
{
    struct Rotationjob : IJobProcessComponentData<Rotation>
    {
        public float dt;
        public void Execute(ref Rotation data)
        {
            quaternion newRotationValue = data.Value;
            newRotationValue = math.mul(math.normalize(data.Value), quaternion.AxisAngle(new float3(0, 1, 0), 10.0f * dt));
            data = new Rotation { Value = newRotationValue };
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        return new Rotationjob
        {
            dt = Time.deltaTime

        }.Schedule(this, inputDeps);
    }
}
