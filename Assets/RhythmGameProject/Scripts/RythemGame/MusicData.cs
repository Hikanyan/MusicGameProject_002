using UnityEngine;
//using UnityEngine.AddressableAssets;

public class MusicData : MonoBehaviour
{
    [SerializeField] public AudioClip _music = default;
    [SerializeField] public int _musicNumber = default;//CRI
    //[SerializeField] public AssetReferenceT<TextAsset> _musicJsonReference;
    [SerializeField] public float _delayTime = 0.0f;
}