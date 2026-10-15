using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
[System.Serializable]
public static class SaveSystem 
{
   public static void SavePlayer(PHealth Phealth){
        BinaryFormatter formatter= new BinaryFormatter();
        string path= Application.persistentDataPath + "/player.data";
        FileStream stream= new FileStream(path,FileMode.Create);
        
        PlayerData data=new PlayerData(Phealth);

        formatter.Serialize(stream,data);
        stream.Close();
   }
   //nalaganje podatkov igralca
   public static PlayerData LoadPlayer(){
        
        string path= Application.persistentDataPath + "/player.data";
        //preverjamo če obstaja datoteka
        if(File.Exists(path)){
             BinaryFormatter formatter= new BinaryFormatter();
              FileStream stream= new FileStream(path,FileMode.Open);
              PlayerData data= formatter.Deserialize(stream) as PlayerData;
                stream.Close();
              return data;

        }
        else {
            Debug.LogError("Save File not found in" + path);
            return null;
        }
   }
    public static void SaveInventory(Inventory inv){
        BinaryFormatter formatter= new BinaryFormatter();
        string path= Application.persistentDataPath + "/inv.data";
        FileStream stream= new FileStream(path,FileMode.Create);
        
        InventoryData data=new InventoryData(inv);

        formatter.Serialize(stream,data);
        stream.Close();
   }
   //nalaganje podatkov inventarja
   public static InventoryData LoadInventory(){
        string path= Application.persistentDataPath + "/inv.data";
        //preverjamo če obstaja datoteka
        if(File.Exists(path)){
             BinaryFormatter formatter= new BinaryFormatter();
              FileStream stream= new FileStream(path,FileMode.Open);
              InventoryData data= formatter.Deserialize(stream) as InventoryData;
               stream.Close();
              return data;
        }
        else {
            Debug.LogError("Inventory Save File not found in" + path);
            return null;
        }
   }
}
