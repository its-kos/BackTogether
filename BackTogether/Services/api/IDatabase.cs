using BackTogether.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BackTogether.Services.api {
    public interface IDatabase {

        //public bool IsAvailable();

        /*  
         *  Create 
         */
        public Task<int> CreateUser(User user);
        public Task<int> CreateProject(Project project);

        /*  
         *  Read 
         */
        public Task<User?> GetUserById(int? id);
        public Task<User?> GetUserByProjectId(int projectId);
        public Task<List<User>> GetAllUsers();
        public Task<Project?> GetProjectById(int id);
        public Task<List<Project>?> GetCreatedProjectsByUserId(int userId);
        public Task<List<Project>?> GetBackedProjectsByUserId(int userId);
        public Task<List<Project>> GetAllProjects(int amount);

        /* 
         * Update 
         */
        public Task<User> UpdateUser(User user);
        public Task<Project> UpdateProject(Project project);

        /* 
         * Delete 
         */
        public Task<bool> DeleteUser(int id);
        public Task<bool> DeleteProject(int id);
    }
}
