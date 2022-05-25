/****************************************************************************************
 *                                                                                      *
 *  File:        FormHelper.cs                                                          *
 *  Copyright:   (c) 2022, Murariu-Tanasache Iulian, Pandeleanu Cosmin, Enache Stefan   *
 *  E-mail:      cosmin-constantin.pandeleanu@student.tuiasi.ro                         *
 *  Website:     https://github.com/IulianMurariu-Tanasache/MP3_Player                  *
 *  Description: Generates file information headers.                                    *
 *                                                                                      *
 *  This program is free software; you can redistribute it and/or modify                *
 *  it under the terms of the GNU General Public License as published by                *
 *  the Free Software Foundation. This program is distributed in the                    *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even                 *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR                 *
 *  PURPOSE. See the GNU General Public License for more details.                       *
 *                                                                                      *
 ****************************************************************************************/


using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace FormHelpers
{
    public class FormHelper 
    {
        /// <summary>
        /// Functie care transforma timpul din secunde in minute si secunde
        /// </summary>
        public static string ConvertTime(int timeInSeconds)
        {
            string time = "";
            if ((timeInSeconds / 60) < 10)
            {
                time += "0";
            }
            time += (timeInSeconds / 60) + ":";
            if ((timeInSeconds % 60) < 10)
            {
                time += "0";
            }
            time += (timeInSeconds % 60);
            return time;
        }

        public static List<string> AddWithoutDuplicates(List<string> newItems, List<string> mainList)
        {
            List<string> newList = new List<string>();
            foreach (String file in newItems)
            {
                bool found = false;
                foreach (String melody in mainList)
                {
                    if (melody.Equals(file))
                    {
                        
                        found = true;
                    }
                }

                if(!found)
                {
                    newList.Add(file);
                }
            }
            return newList;
        }
    }
}