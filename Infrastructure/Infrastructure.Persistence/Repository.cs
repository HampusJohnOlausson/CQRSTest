using System;
using System.Collections.Generic;
using Domain.Models;

namespace Infrastructure.Persistence
{
    public class Repository
    {
        public List<Todo> Todos { get; } = new List<Todo>
        {
            new Todo{Id = 1, Name = "Eat food", Completed = false}
        };
    }
}
