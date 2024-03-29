﻿namespace WorkTool.Core.Modules.Common.Helpers;

public static class Constants
{
    public const ushort BufferSize = 16 * 1024;

    public const string UpperChars = "QWERTYUIOPASDFGHJKLZXCVBNM";
    public const string LowerChars = "qwertyuiopasdfghjklzxcvbnm";
    public const string NumberChars = "1234567890";
    public const string SymbolsChars = "`~!@#$%^&*()-_=,./<>?\\|";
    public const string SpaceChars = " \\t";
    public const string LetterChars = UpperChars + LowerChars;
    public const string LetterNumberChars = UpperChars + LowerChars + NumberChars;

    public const string AllLineChars = LetterChars + NumberChars + SymbolsChars + SpaceChars;

    public static readonly string AllChars = AllLineChars + Environment.NewLine;
    public static readonly Random Random = new();

    public static readonly string[] LastNames =
    {
        "Smith",
        "Jones",
        "Taylor",
        "Williams",
        "Brown",
        "White",
        "Harris",
        "Martin",
        "Davies",
        "Wilson",
        "Cooper",
        "Evans",
        "King",
        "Thomas",
        "Baker",
        "Green",
        "Wright",
        "Johnson",
        "Edwards",
        "Clark",
        "Roberts",
        "Robinson",
        "Hall",
        "Lewis",
        " Clarke",
        "Young",
        "Davis",
        "Turner",
        "Hill",
        "Phillips",
        "Collins",
        "Allen",
        "Moore",
        "Thompson",
        "Carter",
        "James",
        "Knight",
        "Walker",
        "Wood",
        "Hughes",
        "Parker",
        "Ward",
        "Bennett",
        "Cook",
        "Webb",
        "Bailey",
        "Scott",
        "Jackson",
        "Lee",
        "Cox",
        "Patel",
        "Wright ",
        "Thomas ",
        "Clarke",
        "Ward ",
        "Harrison",
        "Lee ",
        "Morris",
        "Khan",
        "Scott ",
        "Watson",
        "Richardson",
        "Mitchell"
    };

    public static readonly string[] Names =
    {
        "James",
        "Robert",
        "John",
        "Michael",
        "David",
        "William",
        "Richard",
        "Joseph",
        "Thomas",
        "Charles",
        "Christopher",
        "Daniel",
        "Matthew",
        "Anthony",
        "Mark",
        "Donald",
        "Steven",
        "Paul",
        "Andrew",
        "Joshua",
        "Kenneth",
        "Kevin",
        "Brian",
        "George",
        "Timothy",
        "Ronald",
        "Edward",
        "Jason",
        "Jeffrey",
        "Ryan",
        "Jacob",
        "Gary",
        "Nicholas",
        "Eric",
        "Jonathan",
        "Stephen",
        "Larry",
        "Justin",
        "Scott",
        "Brandon",
        "Benjamin",
        "Samuel",
        "Gregory",
        "Alexander",
        "Frank",
        "Patrick",
        "Raymond",
        "Jack",
        "Dennis",
        "Jerry",
        "Tyler",
        "Aaron",
        "Jose",
        "Adam",
        "Nathan",
        "Henry",
        "Douglas",
        "Zachary",
        "Peter",
        "Kyle",
        "Ethan",
        "Walter",
        "Noah",
        "Jeremy",
        "Christian",
        "Keith",
        "Roger",
        "Terry",
        "Gerald",
        "Harold",
        "Sean",
        "Austin",
        "Carl",
        "Arthur",
        "Lawrence",
        "Dylan",
        "Jesse",
        "Jordan",
        "Bryan",
        "Billy",
        "Joe",
        "Bruce",
        "Gabriel",
        "Logan",
        "Albert",
        "Willie",
        "Alan",
        "Juan",
        "Wayne",
        "Elijah",
        "Randy",
        "Roy",
        "Vincent",
        "Ralph",
        "Eugene",
        "Russell",
        "Bobby",
        "Mason",
        "Philip",
        "Louis",
        "Mary",
        "Patricia",
        "Jennifer",
        "Linda",
        "Elizabeth",
        "Barbara",
        "Susan",
        "Jessica",
        "Sarah",
        "Karen",
        "Lisa",
        "Nancy",
        "Betty",
        "Margaret",
        "Sandra",
        "Ashley",
        "Kimberly",
        "Emily",
        "Donna",
        "Michelle",
        "Carol",
        "Amanda",
        "Dorothy",
        "Melissa",
        "Deborah",
        "Stephanie",
        "Rebecca",
        "Sharon",
        "Laura",
        "Cynthia",
        "Kathleen",
        "Amy",
        "Angela",
        "Shirley",
        "Anna",
        "Brenda",
        "Pamela",
        "Emma",
        "Nicole",
        "Helen",
        "Samantha",
        "Katherine",
        "Christine",
        "Debra",
        "Rachel",
        "Carolyn",
        "Janet",
        "Catherine",
        "Maria",
        "Heather",
        "Diane",
        "Ruth",
        "Julie",
        "Olivia",
        "Joyce",
        "Virginia",
        "Victoria",
        "Kelly",
        "Lauren",
        "Christina",
        "Joan",
        "Evelyn",
        "Judith",
        "Megan",
        "Andrea",
        "Cheryl",
        "Hannah",
        "Jacqueline",
        "Martha",
        "Gloria",
        "Teresa",
        "Ann",
        "Sara",
        "Madison",
        "Frances",
        "Kathryn",
        "Janice",
        "Jean",
        "Abigail",
        "Alice",
        "Julia",
        "Judy",
        "Sophia",
        "Grace",
        "Denise",
        "Amber",
        "Doris",
        "Marilyn",
        "Danielle",
        "Beverly",
        "Isabella",
        "Theresa",
        "Diana",
        "Natalie",
        "Brittany",
        "Charlotte",
        "Marie",
        "Kayla",
        "Alexis"
    };
}
