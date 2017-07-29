﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdapply
{
    using MUT;

    class Command
    {
        public enum Action { ignore, create, overwrite, delete }

        public string filename { get; set; }
        public Action action { get; set; }
        public Tag tagData { get; set; }

        public Command(string commandItem)
        {
            var elements = commandItem.Split('\t');
            filename = elements[0];
            action = ToAction(elements[1]);
            tagData = new Tag(elements[2], elements[3], elements[4]);
        }

        public Action ToAction(string input)
        {
            var result = Action.ignore;

            if (String.IsNullOrEmpty(input) || String.CompareOrdinal("ignore", input.ToLower()) == 0)
                result = Action.ignore;
            else if (String.CompareOrdinal("create", input.ToLower()) == 0)
                result = Action.create;
            else if (String.CompareOrdinal("overwrite", input.ToLower()) == 0)
                result = Action.overwrite;
            else if (String.CompareOrdinal("delete", input.ToLower()) == 0)
                result = Action.delete;
            else
            {
                Console.WriteLine("Unexpected action {0}, treating as ignore.");
            }
            return result;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("filename: " + filename + " ");
            sb.Append("action: " + action.ToString() + " ");
            sb.Append("tag: " + tagData.ToString());
            return sb.ToString();
        }

    }
}