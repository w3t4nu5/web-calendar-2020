using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCalendar.DAL.EF.Context;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.DAL.Repositories.Implementation;
using Xunit;

namespace WebCalendar.UnitTests.DALTests
{
    public class CRUDRequestsTests
    {
        [Fact]
        public async void GetAllTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Database")
           .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new ApplicationDbContext(options))
            {
                context.Calendars.Add(new Calendar { Name = "calendar 1", Description = "ghgj" });
                context.Calendars.Add(new Calendar { Name = "calendar 2", Description = "ghgj" });
                context.Calendars.Add(new Calendar { Name = "calendar 3", Description = "ghgj" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new ApplicationDbContext(options))
            {
                EFRepositoryAsync<Calendar> calendarRepository =
                    new EFRepositoryAsync<Calendar>(context);
                List<Calendar> calendars = (await calendarRepository.GetAllAsync()).ToList();

                Assert.Equal(3, calendars.Count);
            }
        }

         [Fact]
        public async void AdditionTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Database")
           .Options;


            // Use a clean instance of the context to run the test
            using (var context = new ApplicationDbContext(options))
            {
                EFRepositoryAsync<Calendar> calendarRepository =
                    new EFRepositoryAsync<Calendar>(context);

                List<Calendar> calendars = context.Calendars.ToList();

                await calendarRepository.AddAsync(new Calendar { Name = "calendar 4", Description = "ghgj" });
                await calendarRepository.SaveAsync();

                List<Calendar> updatedCalendars = context.Calendars.ToList();

                int expected = calendars.Count + 1;
                int actual = updatedCalendars.Count;

                Assert.Equal(4, updatedCalendars.Count);
            }
        }

        [Fact]
        public async void DeletionTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Database")
           .Options;

            const string CALENDAR_NAME = "calendar to delete";

            // Use a clean instance of the context to run the test
            using (var context = new ApplicationDbContext(options))
            {
                EFRepositoryAsync<Calendar> calendarRepository =
                    new EFRepositoryAsync<Calendar>(context);

                await calendarRepository.AddAsync(new Calendar { Name = CALENDAR_NAME, Description = "ghgj" });
                await calendarRepository.SaveAsync();

                List<Calendar> calendars = context.Calendars.ToList();

                Calendar calendarToDelete = calendars.First(c => c.Name == CALENDAR_NAME);

                calendarRepository.Remove(calendarToDelete);
                await calendarRepository.SaveAsync();

                List<Calendar> updatedCalendars = context.Calendars.ToList();

                int actual = updatedCalendars.Count();
                int expected = calendars.Count() - 1;

                Assert.Equal(expected, actual);
            }
        }
    }
}
