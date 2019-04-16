using Unity.Entities;
using Unity.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using UnityEngine;
using Unity.Jobs;
using System.Linq;

public class CountDownSystem : ComponentSystem
{

    private ConcurrentDictionary<int, CountDown> countdownDictionary;

    private ConcurrentDictionary<int, CountDownRef> concurrentDictionaryMapper;

    private CountDownjob countDownjob;

    private JobHandle countDownHandle;

    protected override void OnCreateManager()
    {
        countdownDictionary = new ConcurrentDictionary<int, CountDown>();
        concurrentDictionaryMapper = new ConcurrentDictionary<int, CountDownRef>();
    }

    protected override void OnUpdate()
    {
        int count = countdownDictionary.Count();

        if (count <= 0)
            return;

        NativeArray<CountDown> copy = new NativeArray<CountDown>(countdownDictionary.Values.ToArray(), Allocator.TempJob);

        countDownjob = new CountDownjob
        {
            dt = Time.deltaTime,
            countDowns = copy
        };
        countDownHandle = countDownjob.Schedule(count, 128);

        countDownHandle.Complete();

        UpdateCountDowns(countDownjob.countDowns);

        copy.Dispose();


    }

    private void UpdateCountDowns(NativeArray<CountDown> jobCopy)
    {
        for (int i = 0; i < jobCopy.Count(); i++)
        {
            if (jobCopy[i].isCompleted == 0)
            {
                countdownDictionary[jobCopy[i].key] = jobCopy[i];
                concurrentDictionaryMapper[jobCopy[i].key].
                     OnUpdate(countdownDictionary[jobCopy[i].key].totalTime);
            }
            else if (jobCopy[i].isCompleted == 1)
            {
                CountDown removing;

                countdownDictionary.TryRemove(jobCopy[i].key, out removing);

                CountDownRef countDownRef = null;

                concurrentDictionaryMapper.TryRemove(removing.key, out countDownRef);

                countDownRef.OnCompletedEvent();

                countDownRef = null;
            }

        }

    }
    protected override void OnDestroyManager()
    {
        concurrentDictionaryMapper.Clear();
        countdownDictionary.Clear();

    }

#region PublicFunctions
    public void AddCountDown(string key, float ptotalTime, System.Action<string, float> completed, bool isUpdateFrame)
    {
        countDownHandle.Complete();

        int uniqueInt = countdownDictionary.Count() + 1;

        if (concurrentDictionaryMapper.TryAdd(uniqueInt, new CountDownRef(key, completed, isUpdateFrame)))
        {
            CountDown newCountdown = new CountDown
            {
                key = uniqueInt,
                totalTime = ptotalTime
            };
            if (countdownDictionary.TryAdd(uniqueInt, newCountdown))
            {
                Debug.Log("Added " + key + "TotalTime = " + ptotalTime);
            }
        }
    }
    public void ForceRemoveCountDown(string key)
    {
        int jobKey = -1;
            jobKey = concurrentDictionaryMapper.FirstOrDefault(x => x.Value.IsEqual(key)).Key;
        if(jobKey > 0)
        {
            countDownHandle.Complete();
            CountDown removing = countdownDictionary[jobKey];
            removing.totalTime = 0.0f;
            countdownDictionary[jobKey] = removing;
            Debug.Log("ForceRemoved = " + key);
        }
       
    }
#endregion

}
