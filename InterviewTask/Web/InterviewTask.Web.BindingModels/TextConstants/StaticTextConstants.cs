﻿namespace InterviewTask.Web.BindingModels.TextConstants
{
    public class StaticTextConstants
    {
        #region Global

        public const string DATE_FORMAT = "{0:MM/dd/yyyy}";

        #endregion

        #region Errors

        public const string NAME_ERROR_MESSAGE = "Еnter the name!";

        public const string LENGTH_ERROR_MESSAGE = "Minimum length 2 and maximum length 30!";

        public const string NUMBER_ERROR_MESSAGE = "The number should not be zero or less!";

        public const string HEADQUARTERS_ERROR_MESSAGE = "Is it the headquarters?";

        public const string DATE_ERROR_MESSAGE = "Select data!";

        public const string EXPIRIENCE_ERROR = "Select experience of the employee!";

        public const string ADDRESS_ERROR = "Еnter the address!";

        #endregion


        #region Office

        public const string COUNTRY_DISPLAY_NAME = "Name of the country";

        public const string CITY_DISPLAY_NAME = "Name of the city";

        public const string STREET_DISPLAY_NAME = "Name of the street";

        public const string STREET_DISPLAY_NUMBER = "Number of the street";

        public const string HEADQUARTERS_DISPLAY = "Headquarters";

        public const string NUMBER_MIN_VALUE = "1";

        public const string NUMBER_MAX_VALUE = "2147483647"; // int max value

        #endregion


        #region Employee

        public const string EMPLOYEE_DISPLAY_FIRST_NAME = "Employee's first name";

        public const string EMPLOYEE_DISPLAY_LAST_NAME = "Employee's last name";

        public const string EMPLOYEE_DISPLAY_SALARY = "Salary of the employee";

        public const string EMPLOYEE_SALARY_MIN_VALUE = "0.01";

        public const string EMPLOYEE_SALARY_MAX_VALUE = "79228162514264337593543950335"; // decimal max value

        public const string EMPLOYEE_DISPALY_START_DATE = "Start date";

        public const string EMPLOYEE_DISPLAY_EXPIRIENCE = "Level of experience of the employee";

        #endregion


        #region Company

        public const string COMPANY_DISPLAY_NAME = "Name of the company";

         public const string COMPANY_DISPLAY_ADDRESS = "Address of the company";
             
        #endregion
    }
}
