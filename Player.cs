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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyApp3._0
{
    //store attempts taken and how many questions are correct
    public class Player
    {

        //get players name and store it
        public string name = "Anonymous person";
        public int points;

        public int get_points()
        {
            return points;
        }

        public void addpoints()
        {
            points++;
        }
    }
}
