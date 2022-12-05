using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //引入uinty UI的Text資料形態
using UnityEngine.SceneManagement; //要载入场景用到的


public class player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f; //public，显示在unity控制中调整movespeed 数值,[SerializeField]可以在运行的同时修改的在停止后没有修改
    GameObject currentFloor; //目前脚下的阶梯
    [SerializeField] int HP;//目前血量
    [SerializeField] GameObject HpBar; // 血條
    [SerializeField] Text scoreText; 
    int score;
    float scoreTime;
    Animator anim;
    SpriteRenderer render;
    AudioSource deathSound;
    [SerializeField] GameObject replayButton;
    // Start is called before the first frame update
    void Start()
    {
        HP = 10;
        score = 0;
        scoreTime = 0f;
        anim =GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        deathSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //左右移动
        if(Input.GetKey(KeyCode.D)) //Input.GetKey输入按键
        {
            transform.Translate(moveSpeed*Time.deltaTime,0,0);
            render.flipX = false; //圖片的x軸旋轉取消打勾
            anim.SetBool("run",true); //動畫啓動
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed*Time.deltaTime,0,0);
            render.flipX = true; //圖片的x軸旋轉打勾
            anim.SetBool("run",true);
        }
        else
        {
            anim.SetBool("run",false);
        }
    
        UpdateScore();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Normal") 
        {
            if(other.contacts[0].normal == new Vector2(0f,1f))
           {
                //Debug.Log("撞到阶梯");
                currentFloor = other.gameObject;
                ModifyHp(1);
                other.gameObject.GetComponent<AudioSource>().Play(); //打開音效
           } 
        }
        else if(other.gameObject.tag == "Nails")
        {
            
            if(other.contacts[0].normal == new Vector2(0f,1f))
            
            {
                //Debug.Log("撞到尖刺");
                currentFloor = other.gameObject;
                ModifyHp (-1);
                anim.SetTrigger("hurt");
                other.gameObject.GetComponent<AudioSource>().Play();
            }
        }
        else if(other.gameObject.tag =="Ceiling")
        {
            //Debug.Log("撞到天花板");
            currentFloor.GetComponent<BoxCollider2D>().enabled = false;
            ModifyHp (-1);
            anim.SetTrigger("hurt");
            other.gameObject.GetComponent<AudioSource>().Play();
        }
    }
    void OnTriggerEnter2D(Collider2D other) //掉下去
    {
        if(other.gameObject.tag == "DeathLine")
        {
            //Debug.Log("你输了");
            Die(); 
        }
        
    }
     
    void ModifyHp(int num) //血量变化
    {
        HP += num;
        if(HP>10)
        {
            HP=10;
        }
        else if(HP<0) //没血
        {
            HP=0;
            Die();
        }
        UpdateHpBar(); //血量变化就更新血条
    }


    void UpdateHpBar() //血条掉血更新
    {
        for(int i=0; i<HpBar.transform.childCount; i++)
        {
            if(HP>i) //HP是血量
            {
                HpBar.transform.GetChild(i).gameObject.SetActive(true);  
            }
            else
            {
                HpBar.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

    }
    void UpdateScore() //分數更新
    {
        scoreTime += Time.deltaTime;
        if(scoreTime>2f)
        {
            score++;
            scoreTime = 0f;
            scoreText.text = "地下" + score.ToString() + "層";
        }
    }
    void Die() //定义Die
    {
        deathSound.Play();
        Time.timeScale = 0f; //游戏时间重置为0，即游戏停止
        replayButton.SetActive(true); //"继续"的激活按钮打开
    }
    public void Replay()
    {
       Time.timeScale = 1f; //重置时间
        SceneManager.LoadScene("SampleScene"); //重新载入场景

    }
}
