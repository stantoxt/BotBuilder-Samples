﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights;
using Microsoft.Bot.Builder.AI.Luis;

namespace Luis_Bot
{
    /// <summary>
    /// Represents the bot's references to external services.
    ///
    /// For example, Application Insights and Luis services
    /// are kept here (singletons).  These external services are configured
    /// using the <see cref="BotConfiguration"/> class (based on the contents of your ".bot" file).
    /// </summary>
    /// <seealso cref="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.1"/>
    /// <seealso cref="https://www.luis.ai/home"/>
    /// <seealso cref="https://azure.microsoft.com/en-us/services/application-insights/"/>
    [Serializable]
    public class BotServices
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BotServices"/> class.
        /// </summary>
        /// <param name="client">An Application Insights <see cref="TelemetryClient"/> instance.</param>
        /// <param name="luisServices">A dictionary of named <see cref="LuisRecognizer"/> instances for usage within the bot.</param>
        public BotServices(TelemetryClient client, Dictionary<string, LuisRecognizer> luisServices)
        {
            TelemetryClient = client ?? throw new ArgumentNullException(nameof(client));
            LuisServices = luisServices ?? throw new ArgumentNullException(nameof(luisServices));
        }

        /// <summary>
        /// Gets the Application Insights Telemetry client.
        /// Use this to log new custom events/metrics/traces/etc into your
        /// Application Insights service for later analysis.
        /// </summary>
        /// <value>
        /// The Application Insights <see cref="TelemetryClient"/> instance created based on configuration in the .bot file.
        /// </value>
        /// <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.applicationinsights.telemetryclient?view=azure-dotnet"/>
        public TelemetryClient TelemetryClient { get; }

        /// <summary>
        /// Gets the (potential) set of Luis Services used.
        /// Given there can be multiple Luis services used in a single bot,
        /// LuisServices is represented as a Dictionary.  This is also modeled in the
        /// ".bot" file since the elements are named (string).
        /// This sample only uses a single Luis instance.
        /// </summary>
        /// <value>
        /// A <see cref="LuisRecognizer"/> client instance created based on configuration in the .bot file.
        /// </value>
        public Dictionary<string, LuisRecognizer> LuisServices { get; } = new Dictionary<string, LuisRecognizer>();
    }
}