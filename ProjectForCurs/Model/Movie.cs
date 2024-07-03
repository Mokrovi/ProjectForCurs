using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ProjectForCurs.Model
{
    [Table("Movies", Schema = "dbo")]
    internal partial class Movie
    {
        public int Id { set; get; }
        public string Name { set; get; } = "";
        public string OriginName { set; get; } = "";
        public string Description { set; get; } = "";
        public int Score { set; get; }
        public bool IsCanToWatch { set; get; }

        public List<History> Histories { set; get; } = new();

        public List<string> ValidateName()
        {
            var errors = new List<string>();
            
            if (Name.Trim().Length == 0)
                errors.Add("Имя не должно быть пустым");

            if (SpaceCheckerRegex().IsMatch(Name))
                errors.Add("Имя не должно содерждать пробелы подряд");
            
            if (Name.Length >= 60)
                errors.Add("Имя слишком большое");
            
            
            
            return errors;
        }

        public List<string> ValidateOriginName()
        {
            var errors = new List<string>();

            if (OriginName.Trim().Length == 0)
                errors.Add("Оригинальное название не должно быть пустым");
            
            if (SpaceCheckerRegex().IsMatch(OriginName))
                errors.Add("Оригинальное название не должно содерждать пробелы подряд");

            if (OriginName.Length >= 60)
                errors.Add("Оригинальное название слишком длинное");
            
            return errors;
        }

        public List<string> ValidateDescription()
        {
            var errors = new List<string>();
            
            if (Description.Trim().Length == 0)
                errors.Add("Описание не должно быть пустым");
            
            if (SpaceCheckerRegex().IsMatch(Description))
                errors.Add("Описание не должно содерждать пробелы подряд");

            if (Description.Length >= 60)
                errors.Add("Описание слишком большое");

            return errors;
        }

        public List<string> ValidateScore()
        {
            var errors = new List<string>();
            
            if (Score is < 0 or > 10)
                errors.Add("Оценка быть цифрой должна от 0 до 10");

            return errors;
        }

        [System.Text.RegularExpressions.GeneratedRegex("\\s+")]
        private static partial Regex SpaceCheckerRegex();
    }
}