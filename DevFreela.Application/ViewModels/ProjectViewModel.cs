using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        private DateTime createdAt;

        public ProjectViewModel(string title, DateTime createdAt)
        {
            Title = title;
            this.createdAt = createdAt;
        }

        public string  Title { get; private set; }

        public DateTime CreateAt { get; private set; }
    }
}
