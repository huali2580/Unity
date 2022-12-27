using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : MonoBehaviour
{
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //爆炸特效
    //OnCollisionEnter 碰撞侦测，与update不同，前者只要碰撞到物体才会执行{}内程式，后者是一直在执行{}
    private void OnCollisionEnter(Collision collision)
    {
        var expFx = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(expFx, 5);//代表5秒后删除
        Destroy(gameObject);
    }
}
