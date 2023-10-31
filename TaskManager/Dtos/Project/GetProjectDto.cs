using TaskManager.Dtos.Tasks;
using TaskManager.Models;

namespace TaskManager.Dtos.Project
{
    public class GetProjectDto: BaseProjectDto
    {
        public int Id { get; set; }
        public virtual IList<GetTaskDto>? Tasks { get; set; }
    }
}
