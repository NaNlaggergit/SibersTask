using System.ComponentModel.DataAnnotations;

namespace BlazorPage.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Название обязательно")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Описание обязательно")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Дата начала обязательна")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Дата окончания обязательна")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Приоритет обязателен")]
        public int? Priority { get; set; }

        [Required(ErrorMessage = "Компания-заказчик обязательна")]
        public string CustomerCompany { get; set; } = string.Empty;

        [Required(ErrorMessage = "Компания-исполнитель обязательна")]
        public string ExecutorCompany { get; set; } = string.Empty;
        public int ManagerId { get; set; }
        public List<int> EmployeeIds { get; set; }= new ();
    }
}
