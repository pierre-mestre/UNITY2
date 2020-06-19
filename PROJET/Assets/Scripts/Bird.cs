using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    [SerializeField] public AudioClip departSound;
    [SerializeField] public AudioClip perduSound;
    [SerializeField] public AudioClip perduSound2;
    //[SerializeField] public AudioClip newRecordSound;
    [SerializeField] public AudioClip point;
    [SerializeField] public AudioClip hit;
    [SerializeField] public AudioClip die;
    [SerializeField] public AudioClip soundMusic;
    [SerializeField] public float speedForward;
    [SerializeField] public float speedUp;
    [SerializeField] public float speedGravity;

    AudioSource sound;
    public static bool perduStatu = false;
    public static bool gameStart = false;
    public static bool pause = false;
    public static bool win = false;
    public static bool music = false;
    public static int count;

    public static int Count { get => count; set => count = value; }
    public static bool PerduStatu { get => perduStatu; set => perduStatu = value; }
    public static bool GameStart { get => gameStart; set => gameStart = value; }
    public static bool Win { get => win; set => win = value; }
    public static bool Pause { get => pause; set => pause = value; }

    void Start()
    {
        count = 0;
        sound = GetComponent<AudioSource>();
        


    }

    void Update()
    {
        if (pause == false)
        {

            if (gameStart == true)
            {
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
                {
                    sound.Pause();
                    pause = true;
                }
                if (music == false)
                {
                    System.Threading.Thread.Sleep(500);
                    sound.PlayOneShot(soundMusic);
                    music = true;
                }
                if (count >= 248)
                {
                    win = true;
                }

                if (this.transform.position.y <= 2 && perduStatu == false && win == false)
                {
                    sound.Stop();
                    perduStatu = true;
                    Debug.Log("Collision détected SOL");
                    sound.PlayOneShot(hit);
                    System.Threading.Thread.Sleep(500);
                    sound.PlayOneShot(die);
                    sound.PlayOneShot(perduSound2);
                }
                if (perduStatu == false && win == false)
                {
                    Vector3 move = new Vector3();
                    move.y -= speedGravity;
                    move.z += speedForward;
                    //Debug.Log(this.transform.position.y);

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Debug.Log("Clavier");
                        move.y += speedUp;
                        transform.position += move;

                    }
                    else
                    {
                        transform.position += move;
                    }
                }
                else if (win == false)
                {
                    if (this.transform.position.y >= 2)
                    {

                        Vector3 move = new Vector3();
                        move.y -= 1f;
                        transform.position += move;

                    }
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        Application.LoadLevel(0);
                        gameStart = false;
                        perduStatu = false;
                        win = false;
                        music = false;
                    }


                }
                else if (win == true)
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        Application.LoadLevel(0);
                        gameStart = false;
                        perduStatu = false;
                        win = false;
                        music = false;
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {

                    gameStart = true;
                    sound.PlayOneShot(departSound);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Return))
            {
                pause = false;
                sound.Play();
            }
        }
    }

        void OnTriggerEnter(Collider other)
        {
            if (perduStatu == false && gameStart == true && win == false)
            {
                if (other.gameObject.tag == "tuyau")
                {
                    sound.Stop();
                    perduStatu = true;
                    Debug.Log("Collision détected Tuyau");
                    sound.PlayOneShot(hit);
                    System.Threading.Thread.Sleep(500);
                    sound.PlayOneShot(die);
                    sound.PlayOneShot(perduSound);



                }
                if (other.gameObject.tag == "score")
                {
                    
                    Debug.Log("score");
                    sound.PlayOneShot(point);
                    count = count + 1;
                    Debug.Log(count);
                }
            }
        }
    }

