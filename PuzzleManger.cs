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

    [SerializeField]
    Vector2 basicSize;//規定大小範圍

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
            TextureScaleResize(tex2d);
        }
    }

    void TextureScaleResize(Texture2D tex)
    {
        bool isWidth = tex.width > tex.height ? true : false;//判斷為橫立或直立圖片
        float longSide = isWidth == true ? tex.width : tex.height;//設定最長邊

        bool expand;//判斷原圖須縮小或放大(false縮小/true放大)
        float ratio;

        if(isWidth)//如果是橫圖由X軸縮放
        {
            expand = longSide > basicSize.x ? false : true;//判斷最長邊與設定值的大小比較
            ratio = expand == true ? longSide / basicSize.x : basicSize.x / longSide;//設定縮放比例(長邊/短邊)
        }else{//否則直立圖由y軸縮放
            expand = longSide > basicSize.y ? false : true;
            ratio = expand == true ? longSide / basicSize.y : basicSize.y / longSide;
        }

        float newW, newH;//定義縮放後的寬與高
        //若原圖較大則除以比例，反之則乘以比例
        newW = expand == true ? tex.width / ratio : tex.width * ratio;
        newH = expand == true ? tex.height / ratio : tex.height * ratio;

        //解決類正方形圖片縮放時出現的問題
        if(newH > basicSize.y)
        {
            ratio = basicSize.y / newH;
            newW = newW * ratio;
            newH = newH * ratio;
        }

        test.GetComponent<RectTransform>().sizeDelta = new Vector2(newW, newH);
    }
}
