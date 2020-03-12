using System;
using System.Collections.Generic;
using System.Linq;
using WebCalendar.Common.Contracts;
using WebCalendar.DAL.EF.Context;
using WebCalendar.DAL.Models.Entities;

namespace WebCalendar.DAL.EF
{
    public class EFDataInitializer : IDataInitializer
    {
        private readonly ApplicationDbContext _context;

        public EFDataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public void Seed()
        {
            if (_context.Database.EnsureDeleted())
            {
                _context.Database.EnsureCreated();
                AddUser();
                AddCalendar();
                AddCalendarUser();
                AddEvent();
                AddUserEvent();
                AddTask();
                AddReminder();
            }
        }

        private void AddUser()
        {
            var users = new List<User>()
            {
                new User
                {
                    Id = new Guid(),
                    FirstName = "Evil",
                    SecondName = "Arthas",
                    Email = "papich@velichayshiy.com",
                    IsSubscribedToEmailNotifications = false,
                    IsSubscribedToNativeNotifications = true
                },

                new User
                {
                    Id = new Guid(),
                    FirstName = "Yermolenko",
                    SecondName = "Mykhail",
                    Email = "ermolenko1999@gmail.com",
                    IsSubscribedToEmailNotifications = true,
                    IsSubscribedToNativeNotifications = false
                }
            };

            _context.Users.AddRange(users);
            _context.SaveChanges();
        }

        private void AddCalendar()
        {
            var userid = _context.Users.ToArray();

            var calendars = new List<Calendar>()
            {
                new Calendar
                {
                    Id = new Guid(),
                    Name = "VI KA",
                    Description = "Izi dlya papizi",
                    UserId = userid[0].Id
                },

                new Calendar
                {
                    Id = new Guid(),
                    Name = "Trial Calendar",
                    Description = "text",
                    UserId = userid[1].Id
                }
            };

            _context.Calendars.AddRange(calendars);
            _context.SaveChanges();
        }
        private void AddCalendarUser()
        {
            var calendarid = _context.Calendars.ToArray();
            var userid = _context.Users.ToArray();

            var calendaruser = new List<CalendarUser>()
            {
                new CalendarUser
                {
                    CalendarId = calendarid[0].Id,
                    UserId = userid[1].Id
                }
            };

            _context.CalendarUsers.AddRange(calendaruser);
            _context.SaveChanges();
        }

        private void AddEvent()
        {
            var calendarid = _context.Calendars.ToArray();

            var events = new List<Event>()
            {
                new Event
                {
                    Id = new Guid(),
                    Name = "Reincarnation",
                    Description = "Ultimate VK",
                    StartTime = new DateTime(2020, 5, 3, 23, 59, 59),
                    EndTime = new DateTime(2020, 5, 4, 0, 0, 0),
                    NotifyBeforeMode = Models.Entities.Enums.NotifyBeforeMode.None,
                    RepeatMode = Models.Entities.Enums.RepeatMode.EveryWeek,
                    CalendarId = calendarid[0].Id
                },

                new Event
                {
                    Id = new Guid(),
                    Name = "My Birthday",
                    Description = "Party na hate",
                    StartTime = new DateTime(2020, 8, 13, 0, 0, 0),
                    EndTime = new DateTime(2100, 12, 31, 23, 59, 59),
                    NotifyBeforeMode = Models.Entities.Enums.NotifyBeforeMode.None,
                    RepeatMode = Models.Entities.Enums.RepeatMode.EveryYear,
                    CalendarId = calendarid[1].Id
                }
            };

            _context.Events.AddRange(events);
            _context.SaveChanges();
        }

        private void AddUserEvent()
        {
            var userid = _context.Users.ToArray();
            var eventid = _context.Events.ToArray();

            var userevent = new List<UserEvent>()
            {
                new UserEvent
                {
                    UserId = userid[1].Id,
                    EventId = eventid[0].Id
                }
            };

            _context.UserEvents.AddRange(userevent);
            _context.SaveChanges();
        }

        private void AddReminder()
        {
            var calendarid = _context.Calendars.ToArray();

            var reminders = new List<Reminder>()
            {
                new Reminder
                {
                    Id = new Guid(),
                    Name = "Courses",
                    Time = new DateTime(2020, 5, 9),
                    CalendarId = calendarid[1].Id
                }
            };

            _context.Reminders.AddRange(reminders);
            _context.SaveChanges();
        }
        private void AddTask()
        {
            var calendarid = _context.Calendars.ToArray();

            var tasks = new List<Task>()
            {
                new Task
                {
                    Id = new Guid(),
                    Name = "Become programmer",
                    Description = "#",
                    StartTime = new DateTime(2020, 5, 16),
                    IsDone = false,
                    CalendarId = calendarid[1].Id
                }
            };

            _context.Tasks.AddRange(tasks);
            _context.SaveChanges();
        }
    }
}