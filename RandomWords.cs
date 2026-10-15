using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomWords : MonoBehaviour
{
    private string[] quotes={
        "\"You will face many defeats in life, but never let yourself be defeated.\" -Maya Angelou",
        "\"The greatest glory in living lies not in never falling, but in rising every time we fall.\" -Nelson Mandela",
        "\"I failed my way to success.\" -Thomas Edison",
        "\"Those who don't know history are doomed to repeat it.\" — Edmund Burke",
        "\"A hero need not speak. When he is gone, the world will speak for him.\"-Unkown",
        "\"Learn as if you will live forever, live like you will die tomorrow.\" — Mahatma Gandhi",
        "\"Success is not final; failure is not fatal: It is the courage to continue that counts.\" — Winston S. Churchill",
        "\"You learn more from failure than from success. Don’t let it stop you. Failure builds character.\" — Unknown",
        "\"He who conquers himself is the mightiest warrior.\" — Confucius",
        "\"The elevator to success is out of order. You’ll have to use the stairs, one step at a time.\" — Joe Girard",
        "\"Only a fool makes the same mistake two times.\"" 
    };
    public Text text;
    private void Start(){
        text.text=GenerateQuote();
    }
    private string GenerateQuote(){
        string Quote=quotes[Random.Range(0,quotes.Length)];
        return Quote;
    }
}
