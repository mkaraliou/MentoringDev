﻿using System;
using Task3.CustomException;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            string message = null;

            try
            {
                var task = new UserTask(description);
                _taskService.AddTaskForUser(userId, task);
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            if (message != null)
            {
                model.AddAttribute("action_result", message);
                return false;
            }

            return true;
        }
    }
}