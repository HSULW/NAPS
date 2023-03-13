using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManger : MonoBehaviour
{
    public static PuzzleManger Instance;

    [SerializeField]
    RawImage test;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadTexture();
    }
    
    void LoadTexture()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "JPG|*.jpg|PNG_image|*.png";
        if (openFileDialog.ShowDialog() == DialogResult. OK) 
        {
            string texPath = openFileDialog. FileName;
            Texture2D tex2d = new Texture2D(1, 1);
            byte[] texByte = File.ReadAllBytes(texPath);
            tex2d. LoadImage(texByte);
            test. texture = tex2d;
        }
    }
}
