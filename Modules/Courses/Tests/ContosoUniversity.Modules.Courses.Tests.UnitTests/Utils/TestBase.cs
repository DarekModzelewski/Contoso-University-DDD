using System;
using System.Collections.Generic;
using System.Linq;
using ContosoUniversity.Modules.Courses.Domain.Common;
using ContosoUniversity.SharedKernel.Domain;
using NUnit.Framework;

namespace ContosoUniversity.Modules.Courses.Tests.Domain.UnitTests.Utils
{
    public abstract class TestBase
    {
        public static T AssertPublishedDomainEvent<T>(Entity aggregate) where T : IDomainEvent
        {
            var domainEvent = DomainEventsTestHelper.GetAllDomainEvents(aggregate).OfType<T>().SingleOrDefault();

            if (domainEvent == null)
            {
                throw new Exception($"{typeof(T).Name} event not published");
            }

            return domainEvent;
        }

        public static List<T> AssertPublishedDomainEvents<T>(Entity aggregate) where T : IDomainEvent
        {
            var domainEvents = DomainEventsTestHelper.GetAllDomainEvents(aggregate).OfType<T>().ToList();

            if (!domainEvents.Any())
            {
                throw new Exception($"{typeof(T).Name} event not published");
            }

            return domainEvents;
        }

        public static void AssertBrokenRule<TRule>(TestDelegate testDelegate) where TRule : class, IDomainRule
        {
            var message = $"Expected {typeof(TRule).Name} broken rule";
            var domainException = Assert.Catch<DomainException>(testDelegate, message);
            if (domainException != null)
            {
                Assert.That(domainException.DomainRule, Is.TypeOf<TRule>(), message);
            }
        }

        [TearDown]
        public void AfterEachTest()
        {
            SystemClock.Reset();
        }
    }
}