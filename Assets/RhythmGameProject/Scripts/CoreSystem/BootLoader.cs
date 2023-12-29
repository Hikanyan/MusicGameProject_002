using System;
using UnityEngine;


/// <summary> 開始時に SequenceManager をインスタンス化して初期化します。 </summary>
public class BootLoader : MonoBehaviour
{
    [SerializeField] SequenceManager sequenceManagerPrefab;
    private void Awake()
    {
        Instantiate(sequenceManagerPrefab);
        SequenceManager.Instance.Initialize();
    }
}