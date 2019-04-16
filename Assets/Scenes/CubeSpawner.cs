using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;

public class CubeSpawner : MonoBehaviour
{
    private static EntityManager entityManager, entityManager_1;
    private static MeshInstanceRenderer cubeRenderer, cubeRenderer_1;
    private static EntityArchetype entityArchetype,entityArchetype_1;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initilize()
    {
        entityManager = World.Active.GetOrCreateManager<EntityManager>();
        entityManager_1 = World.Active.GetOrCreateManager<EntityManager>();

        entityArchetype = entityManager.CreateArchetype(typeof(Position), typeof(Scale));
        entityArchetype_1 = entityManager.CreateArchetype(typeof(Position), typeof(Rotation));
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void InitalizeWitScene()
    {
        MeshInstanceRendererComponent meshInstanceRendererComponent = GameObject.FindObjectOfType<MeshInstanceRendererComponent>();

        if (meshInstanceRendererComponent != null)
        {
            cubeRenderer = GetRenderer("Render_1");
            cubeRenderer_1 = GetRenderer("Render_2");
            for (int i = 0; i < 50000; i++)
                    SpawnCube(i);
            
        }
    }
    private static MeshInstanceRenderer GetRenderer(string name)
    {
        GameObject render = GameObject.Find(name);
        return render.GetComponent<MeshInstanceRendererComponent>().Value;
    }
    private static void SpawnCube(int index)
    {
      /* if (index % 2 == 0)
        {
            Entity cubeEntity = entityManager.CreateEntity(entityArchetype);
            Vector3 random = UnityEngine.Random.insideUnitSphere * UnityEngine.Random.Range(-100, 100);
            Unity.Mathematics.float3 RandomPosition = new Unity.Mathematics.float3(random.x, random.y, random.z);
            entityManager.SetComponentData(cubeEntity, new Position { Value = RandomPosition });
            entityManager.SetComponentData(cubeEntity, new Scale { Value = new float3(1, 1, 1) });
            entityManager.AddSharedComponentData(cubeEntity, cubeRenderer);
        }*/
      //  else
        {
            Entity cubeEntity = entityManager_1.CreateEntity(entityArchetype_1);
            Vector3  random = UnityEngine.Random.insideUnitSphere * UnityEngine.Random.Range(-100, 100);
            Unity.Mathematics.float3  RandomPosition = new Unity.Mathematics.float3(random.x, random.y, random.z);
            entityManager.SetComponentData(cubeEntity, new Position { Value = RandomPosition });
            entityManager.SetComponentData(cubeEntity, new Rotation { Value = quaternion.identity });
            entityManager.AddSharedComponentData(cubeEntity, cubeRenderer_1);
        }
    }

    private void OnDestroy()
    {
        
    }

}
