﻿// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using System.Threading.Tasks;
using LeVent.Services.Foundations.Events;

namespace LeVent.Services.Processings.Events
{
    public partial class EventProcessingService<T> : IEventProcessingService<T>
    {
        private readonly IEventService<T> eventService;

        public EventProcessingService(IEventService<T> eventService) =>
            this.eventService = eventService;

        public void AddEventHandler(Func<T, ValueTask> eventHandler) => 
        TryCatch(() =>
        {
            ValidateEventHandler(eventHandler);

            this.eventService.AddEventHandler(eventHandler);
        });
    }
}