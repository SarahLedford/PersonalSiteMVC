using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalSiteMVC.UI.MVC.Controllers
{
    public class MiniProjectsController : Controller
    {
        // GET: MiniProjects
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WaterLab(double? userGal, int? userArms)
        {
            double gallons;

            if (userGal != null && userArms != null)
            {
                gallons = Math.Round((double)userGal * 8.33, 2);

                ViewBag.Answer = $"{(userGal == 1 ? $"1 gallon of water weighs {gallons} pounds. That's not that heavy; you'll be all right. And you'll only need one arm to carry it{(userArms > 1 ? $", not {userArms}." : ".")}" : $"{userGal} gallons of water weighs {gallons} pounds. I sure do hope you're strong! Besides, you're going to need to carry{(userGal / userArms > 1 ? $" {userGal / userArms} gallons in each arm." : " 1 gallon in each arm.")} Good luck with that.")}";
            }
            if (userArms == null || userArms == null)
            {
                ViewBag.Answer = "Please fill out both fields to get your result.";
            }

            return View();
        }//end WaterLab


        public ActionResult InterestRate(decimal? balance, decimal? interestRate, decimal? years)
        {
            if (balance != null && interestRate != null && years != null)
            {
                decimal? userBalance = balance;
                decimal? userRate = interestRate;
                for (int i = 1; i <= years; i++)
                {
                    userBalance = userBalance * (1 + (interestRate / 100));
                }

                ViewBag.Answer = $"In {years} years, your new balance will be {userBalance:c}"; 
            }

            return View();
        }

        public ActionResult MinMaxAvg(int? num1, int? num2, int? num3, int? num4, int? num5)
        {
            if (num1 != null && num2 != null && num3 != null && num4 != null && num5 != null)
            {
                int? min;
                int? max;
                double avg;

                int?[] nums = new int?[] { num1, num2, num3, num4, num5 };

                min = Queryable.Min(nums.AsQueryable());
                max = Queryable.Max(nums.AsQueryable());
                avg = Convert.ToDouble(Queryable.Average(nums.AsQueryable()));

                ViewBag.Answer = $"You entered the numbers: {num1}, {num2}, {num3}, {num4}, and {num5}<br />The smallest number was {min}<br />The largest number was {max}<br />The average number was {avg}";
            }
            else
            {
                ViewBag.Answer = "Please fill out all fields to continue.";
            }
            return View();
        }

        public ActionResult MadLib(string noun, string pTVerb, string adjective, string adverb)
        {

            if (noun != null && pTVerb != null && adjective != null && adverb != null)
            {
                ViewBag.Answer = $"There once was a {noun} that was so {adjective} that everybody {adverb} {pTVerb}.";

            }
            else
            {
                ViewBag.Answer = "Please fill out all fields to generate your story.";
            }



            return View();
        }

        public ActionResult ChangeLab(decimal? userMoney)
        {
            if (userMoney != null)
            {
                int newUserMoney = Convert.ToInt32(userMoney * 100);

                int quarters = newUserMoney / 25;
                int dimes = (newUserMoney % 25) / 10;
                int nickels = (newUserMoney % 25 % 10) / 5;
                int pennies = (newUserMoney % 25 % 10 % 5) / 1;

                ViewBag.Answer = $"{userMoney:c} is made up of:<br />Quarters: {quarters}<br />dimes: {dimes}<br />nickels: {nickels}<br />pennies: {pennies}";
            }
            else
            {
                ViewBag.Answer = "Please enter a valid number.";
            }

            return View();
        }

        public ActionResult TempConverter(int? cTemp, int? fTemp)
        {
            if (cTemp != null)
            {
                int? userFTemp = cTemp * 9 / 5 + 32;

                ViewBag.Answer = $"{cTemp}&#8451; is {userFTemp}&#8457;";
            }

            if (fTemp != null)
            {

                int? userCTemp = (fTemp - 32) * 5 / 9;

                ViewBag.Answer = $"{fTemp}&#8457; is {userCTemp}&#8451;";
            }


            return View();
        }

    }//end class
}//end namespace