﻿// Copyright 2007-2017 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Topology
{
    using System;


    /// <summary>
    /// The message-specific publish topology, which may be configured or otherwise
    /// setup for use with the publish specification.
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public interface IMessagePublishTopology<TMessage>
        where TMessage : class
    {
        /// <summary>
        /// Used to format the entity name on the broker for the message type
        /// </summary>
        IMessageEntityNameFormatter<TMessage> EntityNameFormatter { get; }

        void Apply(ITopologyPipeBuilder<PublishContext<TMessage>> builder);

        /// <summary>
        /// Returns the publish address for the message, using the topology rules. This cannot use
        /// a PublishContext because the transport isn't available yet.
        /// </summary>
        /// <param name="baseAddress">The host base address, used to build out the exchange address</param>
        /// <param name="message">The message to be published</param>
        /// <param name="publishAddress">The address where the publish endpoint should send the message</param>
        /// <returns>true if the address was available, otherwise false</returns>
        bool TryGetPublishAddress(Uri baseAddress, TMessage message, out Uri publishAddress);
    }
}