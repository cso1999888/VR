using System.Collections;
using UnityEngine;

//要球元件（類型（元件類型）），再套用腳本時才會觸發
[RequireComponent(typeof(AudioSource))]
public class RotateObject : MonoBehaviour
{
    [Header("Rotate Angle"), Range(0, 360)]
    public float angle = 90;
    [Header("Rotate Speed"), Range(0, 100)]
    public float speed = 1.5f;
    [Header("Sound")]
    public AudioClip sound;
    [Header("Volume"), Range(1, 5)]
    public float volume = 1;

    private AudioSource aud;

    /// <summary>
    /// Start Rotating
    /// </summary>
    public void RotateStart()
    {
        StartCoroutine(Rotate());
    }

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }


    private IEnumerator Rotate()
    {
        aud.PlayOneShot(sound, volume);
        GetComponent<Collider>().enabled = false;   //關閉碰撞器
        // 當 角度 不等於 指定的旋轉角度
        while (transform.rotation != Quaternion.Euler(0, angle, 0))
        {
            //角度的插值
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), speed * Time.deltaTime);
            yield return null;
        }
    }
}
