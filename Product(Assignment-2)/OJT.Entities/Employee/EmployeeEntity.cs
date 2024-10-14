namespace Entities.Employee
{
    using System;

    /// <summary>
    /// Defines the <see cref="EmployeeEntity" />.
    /// </summary>
    public class EmployeeEntity
    {
        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        public int employeeId { get; set; }

      
        /// <summary>
        /// Gets or Sets name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        public string designation { get; set; }

        /// <summary>
        /// Gets or Sets salary
        /// </summary>
        public decimal salary { get; set; }

        /// <summary>
        /// Gets or sets the joining date
        /// </summary>
        public DateTime joiningDate { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeEntity"/> class.
        /// </summary>
        public EmployeeEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        internal void InitializedObjectValue()
        {
            this.employeeId = 0;
            this.name = String.Empty;
            this.address = String.Empty;
            this.designation = String.Empty;
            this.salary = 0;
            this.joiningDate = DateTime.Now;
        }
    }
}
