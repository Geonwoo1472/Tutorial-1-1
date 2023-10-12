using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Text;

public class FileDeleteTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public class testDeleteHa
    {
        public string name;
        public int age;
        public List<int> id = new List<int>();

        public testDeleteHa()
        {
            id.Add(0);
        }

        public testDeleteHa(string _name, int _age, List<int> _id)
        {
            name = _name;
            age = _age;
            id = _id;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R 눌림");

            testDeleteHa t1 = new testDeleteHa("양로원", 70, new List<int>());
            string jsonData = JsonConvert.SerializeObject(t1);

            FileStream stream = new FileStream(Application.dataPath + "/SaveFile/deleteTest.json", FileMode.Create);
            byte[] data = Encoding.UTF8.GetBytes(jsonData);
            stream.Write(data, 0, data.Length);
            stream.Close();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("T 눌림");

            FileStream stream = new FileStream(Application.dataPath + "/SaveFile/deleteTest.json", FileMode.Open);
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            stream.Close();
            string dataDeserialize = Encoding.UTF8.GetString(data);

            var dataFile = JsonConvert.DeserializeObject<testDeleteHa>(dataDeserialize);

            Debug.Log(dataFile.name + " ," + dataFile.id);
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Y 눌림");

            testDeleteHa t2 = new testDeleteHa();
            string jsonData = JsonConvert.SerializeObject(t2);

            FileStream stream = new FileStream(Application.dataPath + "/SaveFile/deleteTest.json", FileMode.Create);
            byte[] data = Encoding.UTF8.GetBytes(jsonData);
            stream.Write(data, 0, data.Length);
            stream.Close();


        }

    }
}
