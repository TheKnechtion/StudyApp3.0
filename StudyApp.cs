/*
 * Study Appliacation3.0 - Branching
 * by Donald Knechtel, 10/26/2020
 * 
 * ASCII Art from the ASCII Art Archive https://www.asciiart.eu/books/books by Donovan Bake(dwb)
 * 
 * Random number functionality, switch statements and getter setter methods discussed with tutor Benjie Valpey
 * 
 */
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudyApp3._0
{
    //store terms and definition in arrays
    //add randomizer with lists
    class StudyApp
    {
        //scoping
        Player newUser;
        string keepPlaying = "n";

        //array for terms
        string[] dataList = File.ReadAllLines("data.txt");

        public void start()
        {
            Console.WindowHeight = 45;
            Console.WindowWidth = 80;
            //add title
            Console.Title = "Study Application 3.0 by Donald Knechtel";

            //get players name and store it
            //introduce player to game tell them what will happen
            //ask the questions and display severl options for the player to choose
            string response;
            do
            {
                studyGame();
                score();
                newUser.points = 0;
                ending();
            }
            while (keepPlaying.ToUpper() == "Y");

            //keep tabs of what questions they got correct
            //conditional statement that detirmines if they got the answer correct
            //add loop to ask if they would like to play again
        }

        public void studyGame()
        {
            //ask player name
            newUser = new Player();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n<==============================================================================>");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            string title = @" 
                        __
                       (`/\
             `=\/\ __...--~~~~~-._   _.- ~~~~~--...__
              `=\/\               \ /               \\
               `=\/ V                 \\
               //_\___--~~~~~~-._  |  _.-~~~~~~--...__\\
               //  ) (..----~~~~._\ | /_.~~~~----.....__\\
             === (INK) ==========\\|//====================
            __ejm\___ / ________dwb`---`_______________________";

            Console.WriteLine(title);
            Console.ResetColor();




            Console.WriteLine("\n\n        Welcome to Programming Class 101-04, Terms and review V 2.0.");
            Console.WriteLine("\n                        Please enter your name.");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("<==============================================================================>\n");
            Console.ResetColor();
            newUser.name = Console.ReadLine();
            Console.Write($"\nWelome to the Study Application, ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(newUser.name);
            Console.ResetColor();
            Console.WriteLine("\nPress any key when you are ready to begin.\n");
            Console.ReadKey();

            Console.Write("In this application we will test your understanding of several ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("TERMS");
            Console.ResetColor();
            Console.Write(" and their\ncoresponding ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("DEFINITIONS");
            Console.ResetColor();
            Console.Write(". \n\nOnce ready, terms will appear and you will match them to their definitons in multiple choice answers. \nSelect each correct answer to get the maximum score. \nDon't worry if you get any wrong, you can always try again.");
            Console.Write(" \nWhen you are ready, press ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ENTER");
            Console.ResetColor();
            Console.Write(".");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n<==============================================================================>");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();

            //ask 15 times
            //initialize something to keep track of which hasnt been chosen
            //initialize a list with thenumber 0-14
            //choose the question at random (from the list of numbers)
            //choose 3 other choices at random that are all diff
            //we want to ask the question but need to place correct answer in a random positon
            //chose random position (0-3)[1-4]
            //create a sctructure to hold the answer choices with this order
            //print out the question and choices
            //get answer input
            //check if correct
            //add point to score if correct otherwise tell them wrong 
            //ask if they want to play again[do while of they want to play again

            List<int> myList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, };

            Random r = new Random();

            for (int i = 0; i < 15; ++i)
            {
                //r = random(0,i+1) //r is a random number between 0, and i (inclusive)
                //pick question based on i chosen
                //get a random number that has not been chosen
                //questionNum = list[i];
                //mylist.RemoveAt(r);//ensures we dont selectthe same question twice int r1; int r2; int r;3
                //do while loop = rndom(0,15)
                //while (r1!=qestionNum)

                int randomIndex = r.Next(0, 15 - i);
                int questionNum = myList[randomIndex];
                myList.RemoveAt(randomIndex);

                int r1, r2, r3;
                //do
                //{
                // ParallelLoopResult body (aka body)
                //} while (condition);
                do
                {
                    r1 = r.Next(16, 31);
                    r2 = r.Next(16, 31);
                    r3 = r.Next(16, 31);
                }
                while (r1 == questionNum + 16 ||
                    r1 == r2 ||
                    r1 == r3 ||
                    r2 == questionNum + 16 ||
                    r2 == r3 ||
                    r3 == questionNum + 16);

                int randomPlacement = r.Next(0, 4); //randomize position of correct answer
                string[] answerChoices = new string[4];
                int numChosen = 0;
                for (int j = 0; j < 4; ++j)
                {
                    if (j == randomPlacement)
                    {
                        answerChoices[j] = dataList[questionNum + 16];
                    }
                    else
                    {
                        switch (numChosen)
                        {
                            case 0:
                                answerChoices[j] = dataList[r1];
                                break;
                            case 1:
                                answerChoices[j] = dataList[r2];
                                break;
                            case 2:
                                answerChoices[j] = dataList[r3];
                                break;
                        }
                        numChosen++;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                string input;

                title = @" 
                        __
                       (`/\
             `=\/\ __...--~~~~~-._   _.- ~~~~~--...__
              `=\/\               \ /               \\
               `=\/ V                 \\
               //_\___--~~~~~~-._  |  _.-~~~~~~--...__\\
               //  ) (..----~~~~._\ | /_.~~~~----.....__\\
             === (INK) ==========\\|//====================
            __ejm\___ / ________dwb`---`_______________________";

                Console.WriteLine(title);
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n<==============================================================================>\n");
                Console.ResetColor();
                Console.Write("Which definition fits the following term: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{dataList[questionNum]}");
                Console.ResetColor();
                Console.Write($". \n\n1.) {answerChoices[0]}. \n\n2.) {answerChoices[1]}. \n\n3.) {answerChoices[2]}. \n\n4.) {answerChoices[3]}.\n\n");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n<==============================================================================>\n");
                Console.ResetColor();

                do
                {
                    Console.WriteLine("Please enter one of the corresponding numbers.\n");
                    input = Console.ReadLine();
                } while (input != "1" && input != "2" && input != "3" && input != "4");

                int answer = Convert.ToInt32(input);

                if (answer - 1 == randomPlacement)
                {
                    Console.WriteLine("\nThat was the correct answer. Nice!\n");
                    newUser.addpoints();
                    Console.WriteLine("Press enter to continue");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<==============================================================================>\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"\n{input} was not the correct answer.\n");
                    Console.WriteLine("Press enter to continue");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("<==============================================================================>\n");
                    Console.ResetColor();
                }
                Console.ReadLine();
                Console.Clear();
            }

        }
        public void score()
        {

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n<==============================================================================>");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            string title = @" 
                        __
                       (`/\
             `=\/\ __...--~~~~~-._   _.- ~~~~~--...__
              `=\/\               \ /               \\
               `=\/ V                 \\
               //_\___--~~~~~~-._  |  _.-~~~~~~--...__\\
               //  ) (..----~~~~._\ | /_.~~~~----.....__\\
             === (INK) ==========\\|//====================
            __ejm\___ / ________dwb`---`_______________________";

            Console.WriteLine(title);
            Console.ResetColor();


            Console.WriteLine("\n\n" + newUser.name + " got " + newUser.points + "/15 correct.");


        }
        public void ending()
        {
            //loop to ask if they want to try again if they did not get 15/15
            // Console.WriteLine($"Looks like you got {player.points}. Would you like to A.) Try again or B.) Exit the game?");
            //else congrats you got 15/15 press enter to leave
            Console.WriteLine("Do you want to play again: Y/N?");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("<==============================================================================>\n");
            Console.ResetColor();
            keepPlaying = Console.ReadLine();
            Console.Clear();
        }
    }
}
