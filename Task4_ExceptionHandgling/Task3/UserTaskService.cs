﻿using System;
using Task3.CustomException;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskService
    {
        private readonly IUserDao _userDao;

        public UserTaskService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public void AddTaskForUser(int userId, UserTask task)
        {
            if (userId < 0)
            {
                throw new InvalidUserIdException("UserId should not be less 0.");
            }

            var user = _userDao.GetUser(userId);

            var tasks = user.Tasks;
            foreach (var t in tasks)
            {
                if (string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase))
                {
                    throw new TaskAlreadyExistsException();
                }
            }

            tasks.Add(task);
        }
    }
}