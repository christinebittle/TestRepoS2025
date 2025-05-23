using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreRouting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        // GOAL: learn about query parameters as part of the GET request

        /// <summary>
        /// Welcomes the user to the program
        /// </summary>
        /// <returns>
        /// A welcome message
        /// </returns>
        /// <example>
        /// GET: api/Example/Welcome -> "Welcome!"
        /// </example>
        [HttpGet(template: "Welcome")]
        public string Welcome()
        {
            return "Welcome!";
        }



        /// <summary>
        /// This method receives a course code as a query parameter and welcomes the user to the course
        /// </summary>
        /// <returns></returns>
        /// <example>
        /// GET: api/Example/Course?Code=HTTP5125 -> "You are enrolled in HTTP5125"
        /// GET: api/Example/Course?Code=HTTP5126 -> "You are enrolled in HTTP5126"
        /// </example>
        [HttpGet(template: "Course")]
        public string Course(string Code)
        {

            string Message = "You are enrolled in " + Code;
            return Message;
        }


        /// <summary>
        /// Receives information about the user as three query parameters and outputs a string
        /// </summary>
        /// <param name="Name">The name of the user</param>
        /// <param name="FavColor">The users favorite Color</param>
        /// <param name="FavFood">The favorite food of the user</param>
        /// <returns>An introduction of the user with their information</returns>
        /// <example>
        /// GET: api/Example/Introduction?Name=Christine
        // &FavColor=Yellow
        // &FavFood=Almonds -> "Your name is Christine and your favorite color is Yellow and you like Almonds"
        /// </example>
        /// <example>
        /// GET: api/Example/Introduction?Name=Sean
        // &FavColor=Blue
        // &FavFood=Chocolate -> "Your name is Sean and your favorite color is Blue and you like Chocolate"
        /// </example>
        [HttpGet(template: "Introduction")]
        public string Introduction(string Name, string FavColor, string FavFood)
        {
            string Message = $"Your name is {Name} and your favorite color is {FavColor} and you like {FavFood}";
            return Message;
        }



        /// <summary>
        /// Receives two favorite animals and produces a discussion on them
        /// </summary>
        /// <param name="FavoriteAnimal">First favorite animal</param>
        /// <param name="SecondFavoriteAnimal">Second Favorite animal</param>
        /// <returns>A discussion string</returns>
        /// <example>
        /// GET : api/Example/Discussion/Zebra/Elephant -> "Your favorite animal is a Zebra  your second favorite is {SecondFavoriteAnimal}"
        /// GET : api/Example/Discussion/Turle/Monkey -> "Your favorite animal is a Turle your second favorite is Monkey"
        ///</example>
        [HttpGet(template: "Discussion/{FavoriteAnimal}/{SecondFavoriteAnimal}")]
        public string Discussion(string FavoriteAnimal, string SecondFavoriteAnimal)
        {
            return $"Your favorite animal is a {FavoriteAnimal} your second favorite is {SecondFavoriteAnimal}";
        }


        /// <summary>
        /// This method receives the Assignment as an input POST data and produces the final grade
        /// </summary>
        /// <param name="Assignment">The assignment value</param>
        /// <returns>
        /// The final grade
        /// </returns>
        /// <example>
        /// POST: localhost:xx/api/example/ReportCard
        /// Header: "Content-Type: application/json"
        /// Request Body: "99"
        /// -> "Your grade is 99"
        /// </example>
        [HttpPost(template: "ReportCard")]
        public string ReportCard([FromBody] int Assignment)
        {
            // "22" + 2 -> "222" or 24?
            string Message = "Your grade is " + Assignment.ToString();
            return Message;
        }



        /// </summary>
        /// <returns>A string with the final grade summary</returns>
        /// <example>
        /// POST: string FinalGrade?name=Christine
        /// Content-Type: application/x-www-form-urlencoded
        /// DATA: Assignment1=80&Assignment2=90&Assignment3=50
        /// -> "Christine's grade is 73.33" <summary>
        /// </example>

        [HttpPost(template: "FinalGrade")]
        public string FinalGrade(string Name, [FromForm] decimal Assignment1, [FromForm] decimal Assignment2, [FromForm] decimal Assignment3)
        {

            // how to round? research and explore!
            decimal FinalGrade = Math.Round((Assignment1 + Assignment2 + Assignment3) / 3, 2);

            //goal : produce an average
            return $"{Name}'s Final Grade is " + FinalGrade.ToString();
        }


        /// <summary>
        /// This computes the volume of the prism given a width, length, and height
        /// </summary>
        /// <param name="Length">The length of the prism in inches</param>
        /// <param name="Width">The width of the prism in inches</param>
        /// <param name="Height">The height of the prism in inches</param>
        /// <returns>A string describing the volume</returns>
        /// <example>
        // POST: api/Example/Prism
        // Header: Content-Type: application/x-www-form-urlencoded
        // DATA: Length=10&Width:10&height=10 -> "The total volume is 16,387cm^3"
        // POST: api/Example/Prism
        // Header: Content-Type: application/x-www-form-urlencoded
        // DATA: Length=1&Width:2&height=3 -> "The total volume is 6cm^3"
        //</example>
        [HttpPost(template: "Prism")]
        public string Prism([FromForm] int Length, [FromForm] int Width, [FromForm] int Height)
        {
            decimal Length_Metric = Length * 2.54M;
            decimal Width_Metric = Width * 2.54M;
            decimal Height_Metric = Height * 2.54M;
            decimal Volume_Metric = Length_Metric * Width_Metric * Height_Metric;
            return $"The total volume is {Volume_Metric}cm^3";
        }


    }
}
