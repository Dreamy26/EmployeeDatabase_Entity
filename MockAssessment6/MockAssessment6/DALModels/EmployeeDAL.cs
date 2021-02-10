using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MockAssessment6.DALModels
{
    public class EmployeeDAL
    {
        //no contructor needed.
        //make properties

        //make the key
        [Key]
        //Datebase generatior option
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

        

    }
}
