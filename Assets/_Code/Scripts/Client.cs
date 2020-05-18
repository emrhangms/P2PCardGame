using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Client : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        ins = this;
    }

    public static Client ins;
    string clientPath= "C:\\Users\\Serhad\\Desktop\\Commands";
    // Start is called before the first frame update
    void Start()
    {
        // Dosya dinlemeyi burası başlatıyor. Start içinde başlaması iyi olur.
        FileSystemWatcher fileWatch = new FileSystemWatcher();
        fileWatch.Path = Path.Combine(clientPath, "ToUnity");
        fileWatch.Created += onCreated;
        fileWatch.EnableRaisingEvents = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onCreated(object sender, FileSystemEventArgs e)
    {
        string requestPath = Path.Combine(clientPath, "Request.json");
        if (File.Exists(requestPath))
        {
            string requestJson = File.ReadAllText(requestPath);
            Request request = JsonUtility.FromJson<Request>(requestJson);

            // To DO : switch içerisine gelecek actionları şuanda kestiremiyorum. 
            //switch (request.Action)
            {
            }
            try
            {
                File.Delete(requestPath);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.Log(ex.Message);
            }
        }
    }

    // Request gönderme burada 
    public void SendRequest(Request request)
    {
        string filePath = Path.Combine(clientPath, "FromUnity", "Request.json");
        if (!File.Exists(filePath))
        {
            try
            {
                using (StreamWriter file = System.IO.File.CreateText(filePath))
                {
                    string reqMessage = JsonUtility.ToJson(request);
                    file.Write(reqMessage);
                }
            }
            catch (Exception)
            {
                UnityEngine.Debug.Log("Request.json dosyası oluşturulurken hata oluştu.");
            }
        }
        else
        {
            File.Delete(filePath);
            UnityEngine.Debug.Log("Böyle bir file olmamalı .exe alamamış bunu ");
        }

    }
}
