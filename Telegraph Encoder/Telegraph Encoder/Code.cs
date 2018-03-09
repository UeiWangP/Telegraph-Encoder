using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegraph_Encoder
{
    class Code
    {
        private Dictionary<string, Dictionary<char, string>> codeRing= new Dictionary<string,Dictionary<char,string>>();//stores all codes
        private Dictionary<char, string> currentCode;
        private string ciphertext;
        public bool isEncoded = false;//flags whether current text in TextBox1 has been encoded

        private void selectCode(string s)
        {
            currentCode = codeRing[s];
        }

        private void encode(string text)
        {
            ciphertext = "";
            text.ToLower();//telegraph code is insensitive to capitalizing

            foreach(char a in text)
            {
                try
                {
                    ciphertext += currentCode[a];
                }
                //if an invalid character is used, throw an exception to Form1
                catch(KeyNotFoundException)
                {
                    throw new InvalidCharacterException(a);
                }
            }
            isEncoded = true;
        }

        public Code()
        {
            //Add Morse Code to currentCode
            //For more information on Morse Code, visit https://en.wikipedia.org/wiki/Morse_code
            currentCode.Add('a', ".-  ");
            currentCode.Add('b', "-...  ");
            currentCode.Add('c', "-.-.  ");
            currentCode.Add('d', "-..  ");
            currentCode.Add('e', ".  ");
            currentCode.Add('f', "..-.  ");
            currentCode.Add('g', "--.  ");
            currentCode.Add('h', "....  ");
            currentCode.Add('i', "..  ");
            currentCode.Add('j', ".---  ");
            currentCode.Add('k', "-.-  ");
            currentCode.Add('l', ".-..  ");
            currentCode.Add('m', "--  ");
            currentCode.Add('n', "-.  ");
            currentCode.Add('o', "---  ");
            currentCode.Add('p', ".--.  ");
            currentCode.Add('q', "--.-  ");
            currentCode.Add('r', ".-.  ");
            currentCode.Add('s', "...  ");
            currentCode.Add('t', "-  ");
            currentCode.Add('u', "..-  ");
            currentCode.Add('v', "...-  ");
            currentCode.Add('w', ".--  ");
            currentCode.Add('x', "-..-  ");
            currentCode.Add('y', "-.--  ");
            currentCode.Add('z', "--..  ");
            currentCode.Add(' ', "      ");
            currentCode.Add('1', ".----  ");
            currentCode.Add('2', "..---  ");
            currentCode.Add('3', "...--  ");
            currentCode.Add('4', "....-  ");
            currentCode.Add('5', ".....  ");
            currentCode.Add('6', "-....  ");
            currentCode.Add('7', "--...  ");
            currentCode.Add('8', "---..  ");
            currentCode.Add('9', "----.  ");
            currentCode.Add('0', "-----  ");

            codeRing.Add("Morse Code", currentCode);//add Morse Code to codeRing
        }
    }
}
