using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSaveManager : BaseMonobehavior
{

    private static GameSaveManager instance;

    public static GameSaveManager Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if(instance == null)
        {
            instance = this;
        } else if(instance != null)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public void SaveCoinToJson(float totalCoin)
    {
        DataSave data = new DataSave();
        data.coinData = totalCoin;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/Data/CoinData.json", json);
    }

    public float LoadCoinToJson()
    {
        if(File.Exists(Application.dataPath + "/Data/CoinData.json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/Data/CoinData.json");
            DataSave data = JsonUtility.FromJson<DataSave>(json);

            return data.coinData;
        }
        return -1;
    }

    public void SaveTotalWeaponToJson()
    {
        DataSave data = new DataSave();
        data.weaponCountData += 1;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/Data/WeaponData.json", json);
    }

    public int LoadTotalWeaponToJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/Data/WeaponData.json");
        DataSave data = JsonUtility.FromJson<DataSave>(json);


        return data.weaponCountData;
    }

    public void SaveTotalPractitionerToJson()
    {
        DataSave data = new DataSave();
        data.practitionersCountData += 1;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/Data/PratitionersData.json", json);
    }

    public int LoadTotalPractitionerToJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/Data/PratitionersData.json");
        DataSave data = JsonUtility.FromJson<DataSave>(json);


        return data.practitionersCountData;
    }
}
