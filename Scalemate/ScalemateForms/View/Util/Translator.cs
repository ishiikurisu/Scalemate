﻿using ScalemateForms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalemateForms.View.Util
{
    /// <summary>
    /// Handles the static texts that appear all the program by providing 
    /// them in the preferred language.
    /// </summary>
    public class Translator
    {
        /// <summary>
        /// Creates a new translator. Requires the existence of a
        /// "assets\translations.csv" table with all static texts and their
        /// translations.
        /// </summary>
        /// <param name="code">The preferred language code.</param>
        public Translator(string code)
        {
            DAL = new DataAccessLayer();
            SetPreferredLanguage(code);

            // Loading translation file
            var aliens = DAL.Load("assets\\translations.csv");
            var fields = aliens[0].Split('\t').Select(it => it.Trim()).ToArray();

            for (int i = 1; i < aliens.Length; ++i)
            {
                var stuff = aliens[i].Split('\t').Select(it => it.Trim()).ToArray();
                var translation = new Dictionary<string, string>();

                for (int j = 1; j < fields.Length; ++j)
                {
                    translation[fields[j]] = stuff[j];
                }

                Translations[stuff[0]] = translation;
            }
        }

        /// <summary>
        /// Gets a static text in the current set language.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string Get(string text)
        {
            return Translations[Code][text];
        }

        /// <summary>
        /// Sets the new preferred language.
        /// </summary>
        /// <param name="code">The language code.</param>
        public void SetPreferredLanguage(string code)
        {
            Code = code;
        }

        public string Code { get; private set; }
        public Dictionary<string, Dictionary<string, string>> Translations;
        private DataAccessLayer DAL;
    }
}