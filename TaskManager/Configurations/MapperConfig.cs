using AutoMapper;
using TaskManager.Dtos.Notification;
using TaskManager.Dtos.Project;
using TaskManager.Dtos.Tasks;
using TaskManager.Dtos.User;
using TaskManager.Models;

namespace TaskManager.Configurations
{
    public class MapperConfig: Profile
    {
        public MapperConfig() 
        {
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<GetAllUsersDto, User>().ReverseMap();
            CreateMap<GetUserDto, User>().ReverseMap();
            CreateMap<UpdateUserDto, User>().ReverseMap();
            
            CreateMap<CreateProjectDto, Project>().ReverseMap();
            CreateMap<GetAllProjectDto, Project>().ReverseMap();
            CreateMap<GetProjectDto, Project>().ReverseMap();
            CreateMap<UpdateProjectDto, Project>().ReverseMap();
            
            CreateMap<CreateTaskDto, Tasks>().ReverseMap();
            CreateMap<GetAllTasksDto, Tasks>().ReverseMap();
            CreateMap<GetTaskDto, Tasks>().ReverseMap();
            CreateMap<UpdateTaskDto, Tasks>().ReverseMap();
            
            CreateMap<CreateNotificationDto, Notification>().ReverseMap();
            CreateMap<GetAllNotificationsDto, Notification>().ReverseMap();
            CreateMap<GetNotificationDto, Notification>().ReverseMap();
            CreateMap<UpdateNotificationDto, Notification>().ReverseMap();

            //CreateMap<BaseUserDto, BaseModel>().ReverseMap();
            //CreateMap<GetTaskDto, Tasks>().ReverseMap();
            //CreateMap<GetNotificationDto, Notification>().ReverseMap();
            //CreateMap<GetUserDto, User>().ReverseMap();
        }
    }
}
