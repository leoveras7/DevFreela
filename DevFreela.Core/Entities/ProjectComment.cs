﻿namespace DevFreela.Core.Entities
{
    public class ProjectComment : BaseEntity
    {
        public ProjectComment(string content, string idProject, int idUser)
        {
            Content = content;
            IdProject = idProject;
            IdUser = idUser;
        }

        public string Content { get; private set; }

        public string IdProject { get; private set; }

        public int IdUser { get; private set; }

        public DateTime CreatedAt { get; private set; }
    }
}