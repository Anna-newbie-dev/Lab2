using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonsLib;

namespace LaunchLab
{
    /// <summary>
    /// RandomPerson class
    /// </summary>
    public static class RandomPerson
    {
        #region Fields

        /// <summary>
        /// Random object
        /// </summary>
        private static Random _random = new Random();

        #endregion

        #region Objects array

        /// <summary>
        /// Objects array of Person class
        /// </summary>

        private static Person[] _source = new Person[]
        {
            new Person("Max","Payne", 38, Gender.Male),
            new Person("Lara", "Croft", 27, Gender.Female),
            new Person("Duke", "Nukem", 34, Gender.Male),
            new Person("Takumi", "Fujiwara", 18, Gender.Male),
            new Person("Ryosuke", "Takahashi", 23, Gender.Male),
            new Person("Jane", "Shepard", 29, Gender.Female),
            new Person("Ezio", "Auditore", 30, Gender.Male),
            new Person("Catherina", "Sforza", 26, Gender.Female),
            new Person("Lorenzo", "Medici", 24, Gender.Male),
            new Person("Annie", "Lennox", 29, Gender.Female),
        };
        #endregion

        #region Methods

        /// <summary>
        /// Picks a random entry from source list
        /// </summary>
        public static Person PickPerson()
        {
            int index = _random.Next(0, _source.Length);
            return _source[index];
        }

        #endregion

    }
}
