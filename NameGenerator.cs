﻿using System;
namespace NameGenerator
{
	public class NameGenerator : INameGenerator
    {
        public string Nickname { get; set; }

        public char[] Vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };

        public char[] Constants = { 'b', 'c', 'd', 'f', 'f', 'h', 'j', 'k', 'l', 'm',
        'n', 'p', 'g', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };


        public virtual string NickGenerator()
        {
            char firstLetterChar = FirstLetterChoise();
            string firstLetterString = Char.ToString(firstLetterChar);
            char secondLetterChar = SecondLetterChoise(firstLetterChar);
            string otherLetters = OtherLettersCreate();

            string nickname = firstLetterString + secondLetterChar + otherLetters;
            Console.WriteLine($"Your nickname: {nickname}");

            Again(nickname);

            return nickname;
        }

        public string Again(string nickname)
        {
            Console.WriteLine("If u dont like it we can recraate.");
            Console.WriteLine("Press enter for continue, or escape two times for left.");

            if(Console.ReadKey().Key == ConsoleKey.Enter)
            {
                NickGenerator();
            }

            else if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Console.WriteLine($"Okay, your name:{nickname}");
            }

            return nickname;   
        }

        public char FirstLetterChoise()
        {
            Console.WriteLine("Write first letter for your nickname please.");

            char firstLetter = char.Parse(Console.ReadLine());

            return firstLetter;
        }

        public char SecondLetterChoise(char firstLetter)
        {
            int indexForSecondLetter;
            char secondLetter = '0';

            if (Vowels.Contains(firstLetter))
            {
                Random rnd = new Random();
                indexForSecondLetter = rnd.Next(Constants.Length);
                secondLetter = Constants[indexForSecondLetter];
            }

            else if (Constants.Contains(firstLetter))
            {
                Random rnd = new Random();
                indexForSecondLetter = rnd.Next(Vowels.Length);
                secondLetter = Vowels[indexForSecondLetter];
            }

            return secondLetter;
        }

        public string OtherLettersCreate()
        {

            Console.WriteLine("Write how many letters lenght you want?");
            int lenght = int.Parse(Console.ReadLine());
            int lenghtMinusFirst = lenght - 2;
            char[] OtherLetters = new char[lenghtMinusFirst];
            string[] LetterVariations = { "first", "second" };


            for (int i = 0; i < lenghtMinusFirst; i++)
            {
                //int j = i + 1;

                Random rnd = new Random();

                int variationInt = rnd.Next(LetterVariations.Length);
                string variationString = LetterVariations[variationInt];

                if (variationString == "first")
                {
                    int index = rnd.Next(Vowels.Length);
                    OtherLetters[i] = Vowels[index];
                }

                else if (variationString == "second")
                {
                    int index = rnd.Next(Constants.Length);
                    OtherLetters[i] = Constants[index];
                }
            }

            string otherLetters = new string(OtherLetters);

            return otherLetters;
        }
    }
}

