/*using System.Collections;
using System.Collections.Generic;

using Unity.Jobs;
using Unity.Transforms;
using Unity.Entities;
using Unity.Mathematics;

public class JobSystem : JobComponentSystem
{
    struct Job : IJobProcessComponentData<Rotation>
    {
        public float dt;

        public void Execute(ref Rotation data)
        {
            throw new System.NotImplementedException();
        }
    }
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Job job = new Job()
        {
            dt = UnityEngine.Time.deltaTime
        };
        return job.Schedule(this, inputDeps);
    }
}
*/