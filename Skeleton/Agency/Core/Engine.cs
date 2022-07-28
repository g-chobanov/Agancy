﻿using System;
using System.Collections.Generic;
using System.Text;
using Agency.Core.Contracts;
using Agency.Core.Providers;
using Agency.Models.Contracts;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Core
{
    public class Engine : IEngine
    {
        private static IEngine instanceHolder;

        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        // private because of Singleton design pattern
        public Engine(IReader reader, IWriter writer, IParser parser, IAgencyDatabase agencyDatabase)
        {
            this.Reader = reader;
            this.Writer = writer;
            this.Parser = parser;
            this.AgencyDatabase = agencyDatabase;

        }

        public static IEngine Instance
        {
            get
            {
                if (instanceHolder == null)
                {
                    instanceHolder = new Engine(new ConsoleReader(), new ConsoleWriter(), new CommandParser(), new AgencyDatabase());
                }

                return instanceHolder;
            }
        }

        // Property dependencty injection not validated for simplicity
        public IReader Reader { get; set; }

        public IWriter Writer { get; set; }

        public IParser Parser { get; set; }

        public IAgencyDatabase AgencyDatabase { get; set; }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.Reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ex.Message);
                    //this.Writer.WriteLine("####################");
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.Parser.ParseCommand(commandAsString);
            var parameters = this.Parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.Writer.WriteLine(executionResult);
            //this.Writer.WriteLine("####################");
        }
    }
}
