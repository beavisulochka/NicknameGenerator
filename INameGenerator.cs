using System;
namespace NameGenerator
{
    public interface INameGenerator
    {
        string NickGenerator();
	char FirstLetterChoise();
	char SecondLetterChoise(char firstLetter);
	string OtherLettersCreate();
    }
}

