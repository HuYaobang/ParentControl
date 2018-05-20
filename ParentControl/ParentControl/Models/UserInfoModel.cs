using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ParentControl.Models
{
    public class UserInfoModel
    {        
        public UserInfoModel()
        {
            EatingTimer = 0;
            EyesTimer = 0;
            ExerciseTimer = 0;
            ShutDownTimer = 0;
            UseShutDownTimer = false;
            UseEatingTimer = false;
            UseExerciseTimer = false;
            UseEyesTimer = false;
            EnableAutoStart = false;
            IsEmailConfirmed = false;
        }
        
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public bool EnableAutoStart { get; set; }

        public bool UseEatingTimer { get; set; }

        public bool UseEyesTimer { get; set; }

        public bool UseExerciseTimer { get; set; }

        public bool UseShutDownTimer { get; set; }

        public int EatingTimer { get; set; }

        public int EyesTimer { get; set; }

        public int ExerciseTimer { get; set; }

        public int ShutDownTimer { get; set; }
    }
}
