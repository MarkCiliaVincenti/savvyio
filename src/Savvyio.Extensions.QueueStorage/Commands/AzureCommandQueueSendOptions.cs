﻿using System;
using Cuemon.Configuration;

namespace Savvyio.Extensions.QueueStorage.Commands
{
    /// <summary>
    /// Configuration options that is related to sending messages from an Azure Storage Queue.
    /// </summary>
    public class AzureCommandQueueSendOptions : IParameterObject
    {
        private TimeSpan _visibilityTimeout;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureCommandQueueSendOptions"/> class.
        /// </summary>
        internal AzureCommandQueueSendOptions()
        {
            VisibilityTimeout = TimeSpan.Zero;
            TimeToLive = TimeSpan.FromDays(7);
        }

        /// <summary>
        /// Gets or sets the time-to-live for the messages. Default is 7 days.
        /// </summary>
        /// <value>The time-to-live for the messages.</value>
        public TimeSpan TimeToLive { get; set; }

        /// <summary>
        /// Gets or sets the visibility timeout for the messages. Default is <see cref="TimeSpan.Zero"/>.
        /// </summary>
        /// <value>The visibility timeout for the messages.</value>
        /// <remarks>
        /// The minimum allowed value is <see cref="TimeSpan.Zero"/>, and the maximum allowed value is limited to <see cref="AzureCommandQueueOptions.MaxVisibilityTimeout"/>.
        /// <br/>
        /// Reference: https://learn.microsoft.com/en-us/rest/api/storageservices/put-message#uri-parameters
        /// </remarks>
        public TimeSpan VisibilityTimeout
        {
            get => _visibilityTimeout;
            set
            {
                if (value < TimeSpan.Zero) { value = TimeSpan.Zero; }
                if (value > AzureCommandQueueOptions.MaxVisibilityTimeout) { value = AzureCommandQueueOptions.MaxVisibilityTimeout; }
                _visibilityTimeout = value;
            }
        }
    }
}
